using System;
using InteractiveConsole.Models;

namespace InteractiveConsole
{
	public static class MenuExtensions
	{
		public static Menu<string> AddOption(this Menu<string> menu, string option)
		{
			return menu.AddOption(option, option, null);
		}
		
		public static Menu<string> AddOption(this Menu<string> menu, string option, Action<string> callback)
		{
			return menu.AddOption(option, option, callback);
		}
		
		public static Menu<T> AddOption<T>(this Menu<T> menu, string option, T value)
		{
			return menu.AddOption(option, value, null);
		}
		
		public static Menu<T> AddOption<T>(this Menu<T> menu, string option, T value, Action<T> callback)
		{
			return menu.AddOption(new MenuOption<T>
			{
				Option = option,
				Value = value,
				Callback = callback
			});
		}
	}
}