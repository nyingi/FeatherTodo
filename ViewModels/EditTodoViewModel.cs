/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FeatherMvvm;
using FeatherMvvm.Messaging;
using FeatherTodo.Models;
using FeatherTodo.Services;

namespace FeatherTodo.ViewModels
{
	/// <summary>
	/// Description of EditTodoViewModel.
	/// </summary>
	public class EditTodoViewModel : FeatherViewModel
	{
		public EditTodoViewModel()
		{
			Date = DateTime.Now;
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
		
		
	}
}
