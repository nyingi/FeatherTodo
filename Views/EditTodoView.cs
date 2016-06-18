﻿/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using DashMvvm;
using FeatherTodo.Validation;
using FeatherTodo.ViewModels;

namespace FeatherTodo.Views
{
	/// <summary>
	/// Description of EditTodoView.
	/// </summary>
	public partial class EditTodoView : DashView<EditTodoViewModel>
	{
		public EditTodoView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			ConfigureValidation();
			DoBindings();
			SubscribeEvents();
			
		}
		
		private void ConfigureValidation()
		{
			AddValidation(txtDescription, GeneralValidations.NotEmpty);
			AddValidation(dtpDate, DateValidations.NotPastDate);
		}
		
		private void DoBindings()
		{
			Binder.Bind(txtDescription, txt => txt.Text, vm => vm.Description);
			Binder.Bind(dtpDate, dtp => dtp.Value, vm => vm.Date);
			Binder.Bind(cboCategory, cbo => cbo.Items, vm => vm.Categories);
			
			
			Binder.Apply();
		}

		ErrorProvider _errorProvider;
		private ErrorProvider ErrorProvider
		{
			get
			{
				if(_errorProvider == null)
				{
					_errorProvider = new ErrorProvider();
					_errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
				}
				return _errorProvider;
			}
		}
		
		void SubscribeEvents()
		{
			ControlValidated += (sender,  e) => 
			{
				cmdSave.Enabled = false;
				ErrorProvider.SetError(e.ValidatableObject as Control, e.Error);
			};
			
			ViewIsValid += (sender, e) => cmdSave.Enabled = true;
		}
		
		void CmdSaveClick(object sender, EventArgs e)
		{
			ViewModel.Save();
			Close();
		}
		void CmdCancelClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
