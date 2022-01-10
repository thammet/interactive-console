using System;
using System.Collections.Generic;
using InteractiveConsole.Examples.Models;

namespace InteractiveConsole.Examples
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("This is an example on how to use Interactive Console");
			
			SimpleExample();
			Console.WriteLine();
			
			ExampleWithValue();
			Console.WriteLine();
			
			EscapeToExitExample();
			Console.WriteLine();

			PromptExample();
			Console.WriteLine();

			InputExample();
			Console.WriteLine();
		}

		private static void SimpleExample()
		{
			var breakfastSelection = new Menu<string>()
				.AddOption("Eggs")
				.AddOption("Biscuits")
				.AddOption("Bacon")
				.Get("Which breakfast food is the best?");
			
			Console.WriteLine($"The best breakfast food is: {breakfastSelection}");
		}

		private static void ExampleWithValue()
		{
			var cars = new List<Car>
			{
				new Car
				{
					Name = "Ford"
				},
				new Car
				{
					Name = "Tesla"
				},
				new Car
				{
					Name = "Toyota"
				}
			};

			var carMenu = new Menu<Car>();

			foreach (var car in cars)
			{
				carMenu = carMenu.AddOption(car.Name, car);
			}

			var carSelection = carMenu.Get("Which car is the best?");
			
			Console.WriteLine($"The best car is: {carSelection.Name}");
		}

		private static void PromptExample()
		{
			if (Prompt.Get("Do you like the rain?"))
			{
				Console.WriteLine("You do like the rain!");
			}
			else
			{
				Console.WriteLine("You don't like the rain!");
			}
		}

		private static void EscapeToExitExample()
		{
			var selection = new Menu<string>()
				.AddOption("A")
				.AddOption("B")
				.AddOption("C")
				.Get("Make a choice", true);

			if (selection is null)
			{
				Console.WriteLine("You pressed escape!");
			}
			else
			{
				Console.WriteLine("You didn't press escape!");
			}
		}

		private static void InputExample()
		{
			var name = Input.Get("Enter name");
			Console.WriteLine($"Your name is: {name}");
		}
	}
}