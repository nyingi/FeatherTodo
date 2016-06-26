/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 2:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using DashMvvm;
using FeatherTodo.Models;
using FeatherTodo.ViewModels;
using FeatherTodo.Views;

namespace FeatherTodo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	internal partial class TodoListingView : DashView<TodoListingViewModel>
	{
		void MessageBus_MessagePassed(object sender, DashMvvm.Messaging.MessageEventArgs e)
		{
			switch(e.MessageTag)
			{
				case Messages.RefreshTodosList:
					ViewModel.RefreshTodos();
					break;
			}
		}

		public TodoListingView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			MessageBus.MessagePassed += MessageBus_MessagePassed;
			DoBindings();
			lvTodos.GridLines = true;
			lvTodos.FullRowSelect = true;
			lvTodos.HideSelection = false;
		}
		
		private void DoBindings()
		{
			Binder.Bind(lvTodos, obj => obj.Columns, vm => vm.ListOfTodos);
			Binder.Bind(lvTodos, obj => obj.Items, vm => vm.ListOfTodos)
				.ViewItem.ItemSelectionChanged += (sender, e) => 
			{
				ViewModel.SelectedItem = e.Item.Tag as Todo;
			};
			Binder.Bind(btnDelete, btn => btn.Enabled, vm => vm.DeleteEnabled);
			Binder.Apply();
		}
		void BtnAddClick(object sender, EventArgs e)
		{
			new EditTodoView().ShowDialog();
		}
		void BtnDeleteClick(object sender, EventArgs e)
		{
			if(MessageBox.Show(string.Format("Delete '{0}'",ViewModel.SelectedItem.Description),"Delete?",MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return;
			}
			ViewModel.Delete();
			btnDelete.Enabled = false;
		}
	}
}
