/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using DashMvvm;
using FeatherTodo.Models;
using FeatherTodo.Services;

namespace FeatherTodo.ViewModels
{
	/// <summary>
	/// Description of TodoListingViewModel.
	/// </summary>
	internal class TodoListingViewModel : DashViewModel
	{
		public TodoListingViewModel()
		{
			RefreshTodos();
		}
		
		List<Todo> _listOfTodos;
		public List<Todo> ListOfTodos
		{
			get
			{
				return _listOfTodos;
			}
			set
			{
				SetField(ref _listOfTodos, value);
			}
		}
		
		public void RefreshTodos()
		{
			ListOfTodos = new TodoService().GetAll<Todo>();
		}
		
		public void Delete()
		{
			new TodoService().Delete(SelectedItem);
			RefreshTodos();
		}
		
		
		
		Todo _selectedItem;
		public Todo SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				SetField(ref _selectedItem, value);
				DeleteEnabled = value != null;
			}
		}
		
		bool _deleteEnabled;
		public bool DeleteEnabled
		{
			get
			{
				return _deleteEnabled;
			}
			set
			{
				SetField(ref _deleteEnabled, value);
			}
		}
	}
}
