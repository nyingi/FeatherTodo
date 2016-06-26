﻿/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FeatherMvvm.Attributes;

namespace FeatherTodo.Models
{
	/// <summary>
	/// Description of Todo.
	/// </summary>
	internal class Todo : ModelBase
	{
		public Todo()
		{
		}
		
		[ListViewColumnAttribute("Description",2)]
		public string Description { get; set; }
		
		[ListViewColumn("Date",1)]
		public DateTime Date { get; set; }
		
		public override string ToString()
		{
			return string.Format("{0} - {1}", Date.ToShortDateString(), Description);
		}
	}
}
