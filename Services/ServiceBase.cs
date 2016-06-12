/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 5:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using FeatherTodo.Models;

namespace FeatherTodo.Services
{
	/// <summary>
	/// Description of ServiceBase.
	/// </summary>
	internal abstract class ServiceBase
	{
				
		private string SaveDir
		{
			get
			{
				string saveDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
				                 + @"\FeatherTodo";
				if(!Directory.Exists(saveDir))
				{
					Directory.CreateDirectory(saveDir);
				}
				return saveDir;
			}
		}
		
		private string GetModelDir<TModel>() where TModel : new()
		{
			var model = new TModel();
			string filename = SaveDir + @"\" + model.GetType().Name + @"\";
			return filename;
		}
		
		public void Save<TModel>(TModel model) where TModel : ModelBase , new()
		{
			string filename = GetModelDir<TModel>() + model.Id + ".json";
			if(!Directory.Exists(Path.GetDirectoryName(filename)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(filename));
			}
			if(File.Exists(filename))
			{
				File.Delete(filename);
			}
			File.WriteAllText(filename,JsonConvert.SerializeObject(model,Formatting.Indented));
		}
		
		public List<TModel> GetAll<TModel>() where TModel : new()
		{
			string modelsDir = Path.GetDirectoryName(GetModelDir<TModel>());
			List<TModel> models = new List<TModel>();
			foreach(string modelFile in Directory.GetFiles(modelsDir))
			{
				TModel model = JsonConvert.DeserializeObject<TModel>(File.ReadAllText(modelFile));
				models.Add(model);
			}
			return models;
		}
		
		public void Delete<TModel>(TModel model) where TModel : ModelBase , new()
		{
			string modelsDir = Path.GetDirectoryName(GetModelDir<TModel>());
			string file = string.Format(@"{0}\{1}.json",modelsDir,model.Id);
			if(File.Exists(file))
			{
				File.Delete(file);
			}
		}
	}
}
