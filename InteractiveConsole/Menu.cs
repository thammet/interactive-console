using System;
using System.Collections.Generic;
using System.Linq;
using InteractiveConsole.Models;

namespace InteractiveConsole
{
	public class Menu<T>
	{
		private List<MenuOption<T>> _options = new List<MenuOption<T>>();

		public Menu<T> AddOption(MenuOption<T> option)
		{
			_options.Add(option);
			return this;
		}
		
		public Menu<T> RemoveOption(string option)
		{
			_options = _options.Where(o => o.Option != option).ToList();
			return this;
		}

		public void Display(string title, bool escapeToExit = false)
		{
			var option = GetSelection(title, escapeToExit);

			if (option?.Callback != null)
			{
				option.Execute();
			}
		}

		public T Get(string title, bool escapeToExit = false)
		{
			var option = GetSelection(title, escapeToExit);
			return option is null ? default(T) : option.Value;
		}

		private MenuOption<T> GetSelection(string title, bool escapeToExit)
		{
			if (!_options.Any())
			{
				throw new InvalidOperationException("No options added");
			}
			
			var index = 0;
			MenuOption<T> selection = null;
			var originalCursorPosition = Console.GetCursorPosition();
			
			while (selection is null)
			{
				Console.WriteLine(title);
				Console.WriteLine();
				
				for (var i = 0; i < _options.Count; i++)
				{
					WriteLine($"\t{_options[i].Option}", i == index ? ConsoleColor.Blue : Console.ForegroundColor);
				}

				if (escapeToExit)
				{
					Console.WriteLine();
					Console.WriteLine("Press 'escape' to exit");
				}

				var key = Console.ReadKey(true);

				switch (key.Key)
				{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W:
						index = Math.Max(0, index - 1);
						break;
					case ConsoleKey.DownArrow:
					case ConsoleKey.S:
						index = Math.Min(_options.Count - 1, index + 1);
						break;
					case ConsoleKey.Enter:
					case ConsoleKey.Spacebar:
						selection = _options[index];
						break;
				}
				
				ConsoleHelper.ClearSubConsole(originalCursorPosition);
				
				if (escapeToExit && key.Key == ConsoleKey.Escape)
				{
					break;
				}
			}
			
			return selection;
		}

		

		private void WriteLine(string text, ConsoleColor color)
		{
			var originalForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ForegroundColor = originalForegroundColor;
		}
	}
}