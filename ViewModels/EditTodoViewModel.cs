/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using DashMvvm;
using FeatherMvvm.Attributes;
using FeatherTodo.Models;
using FeatherTodo.Services;

namespace FeatherTodo.ViewModels
{
	/// <summary>
	/// Description of EditTodoViewModel.
	/// </summary>
	public class EditTodoViewModel : DashViewModel
	{
		private const String CategoryWork = "Work";
		private const String CategoryPlay = "Play";
		private const String CategoryOther = "Other";
		
		public EditTodoViewModel()
		{
			Date = DateTime.Now;
			SelectedCategory = CategoryWork;
		}
		
		string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				SetField(ref _description, value);
			}
		}
		
		DateTime _date;
		public DateTime Date
		{
			get
			{
				return _date;
			}
			set
			{
				SetField(ref _date, value);
			}
		}
		
		public void Save()
		{
			Todo todo = new Todo
			{
				Description = Description,
				Date = Date,
				Id = Guid.NewGuid()
			};
			new TodoService().Save(todo);
			MessageBus.SendMessage(Messages.RefreshTodosList);
		}
		
		[SelectedListItemPropertyName("SelectedCategory")]
		public List<string> Categories
		{
			get
			{
				return new List<string>
				{
					CategoryOther, CategoryPlay, CategoryWork
				};
			}
		}
		
		string _selectedCategory;
		public string SelectedCategory
		{
			get
			{
				return _selectedCategory;
			}
			set
			{
				SetField(ref _selectedCategory,value);
			}
		}
		
		
	}
}
