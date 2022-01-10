using System;

namespace InteractiveConsole.Models
{
	public class MenuOption<T>
	{
		public string Option { get; set; }
		public T Value { get; set; }
		public Action<T> Callback { get; set; }

		public void Execute()
		{
			Callback(Value);
		}
	}
}