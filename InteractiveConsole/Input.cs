using System;

namespace InteractiveConsole
{
	public static class Input
	{
		public static string Get(string title)
		{
			var originalCursorPosition = Console.GetCursorPosition();

			Console.Write($"{title}: ");
			
			var input = Console.ReadLine();

			ConsoleHelper.ClearSubConsole(originalCursorPosition);
			
			return input;
		}
	}
}