/*
 * Created by SharpDevelop.
 * User: Nyingi
 * Date: 12-Jun-16
 * Time: 3:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FeatherTodo.Validation
{
	/// <summary>
	/// Description of DateValidations.
	/// </summary>
	public static class DateValidations
	{
		public static string NotPastDate(object obj)
		{
			DateTime date = GetDate(obj);
			if(date == default(DateTime))
			{
				return "A value for date must be supplied";
			}
			
			if(DateTime.Now > date)
			{
				return "Date cannot be in the past";
			}
			return "";
		}
		
		private static DateTime GetDate(object obj)
		{
			if(obj == null || string.IsNullOrEmpty(obj.ToString()))
			{
				return default(DateTime);
			}
			DateTime result;
			if(!DateTime.TryParse(obj.ToString(),out result))
			{
				return default(DateTime);
			}
			return result;
		}
		
		
	}
}
