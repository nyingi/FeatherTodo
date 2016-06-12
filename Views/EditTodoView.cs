/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using FeatherMvvm;
using FeatherTodo.Validation;
using FeatherTodo.ViewModels;

namespace FeatherTodo.Views
{
	/// <summary>
	/// Description of EditTodoView.
	/// </summary>
	public partial class EditTodoView : FeatherView<EditTodoViewModel>
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
			
			
			Binder.Apply();
		}

		void SubscribeEvents()
		{
			ValidationErrorOccured += (object sender, FeatherMvvm.Validation.ValidationErrorEventArgs e) => 
			{
				cmdSave.Enabled = false;
				MessageBox.Show(e.Error);
			};
			
			ViewIsValid += (sender, e) => cmdSave.Enabled = true;
		}
		
		void CmdSaveClick(object sender, EventArgs e)
		{
			ViewModel.Save();
			Close();
		}
	}
}
