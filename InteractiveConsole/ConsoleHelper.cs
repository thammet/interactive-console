using System;

namespace InteractiveConsole
{
	public static class ConsoleHelper
	{
		public static void ClearSubConsole((int left, int top) originalCursorPosition)
		{
			var length = Console.CursorTop - originalCursorPosition.top;
			
			Console.SetCursorPosition(originalCursorPosition.left, originalCursorPosition.top);
			for (var i = 0; i < length; i++)
			{
				Console.WriteLine(new string(' ', Console.WindowWidth));
			}
			
			Console.SetCursorPosition(originalCursorPosition.left, originalCursorPosition.top);
		}
	}
}