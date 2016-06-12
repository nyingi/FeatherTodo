/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FeatherTodo.Validation
{
	/// <summary>
	/// Description of GeneralValidations.
	/// </summary>
	public static class GeneralValidations
	{
		public static string NotEmpty(object obj)
		{
			if(obj == null || string.IsNullOrEmpty(obj.ToString()))
			{
				return "A value must be provided for this field";
			}
			return "";
		}
	}
}
