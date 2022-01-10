namespace InteractiveConsole
{
	public static class Prompt
	{
		public static bool Get(string question)
		{
			return new Menu<bool>()
				.AddOption("Yes", true)
				.AddOption("No", false)
				.Get(question, false);
		}
	}
}