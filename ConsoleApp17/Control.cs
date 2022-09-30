namespace ConsoleApp17
{
	static class Control
	{
		public static void MySetColor(ConsoleColor foreground, ConsoleColor background)
		{
			Console.ForegroundColor = foreground;
			Console.BackgroundColor = background;
		}

		public static bool Keyboard(ref int select, int count)
		{
			ConsoleKey keyboard = Console.ReadKey().Key;

			switch (keyboard)
			{
				case ConsoleKey.UpArrow:
					if (select == 0)
						select = count;
					select--;
					return true;
				case ConsoleKey.DownArrow:
					select++;
					select %= count;
					return true;
				case ConsoleKey.Enter:
					return false;
				case ConsoleKey.Tab:
					return false;
				default:
					return true;
			}
		}

		public static int GetSelect(string[] selections, string? text = null)
		{
			int select = default;
			int selectionsCount = selections.Length;

			bool check = true;
			while (check)
			{
				Console.Clear();
				if (text != null)
					Console.WriteLine(text);


				for (int i = 0; i < selectionsCount; i++)
				{

					if (i == select)
						MySetColor(ConsoleColor.Black, ConsoleColor.DarkYellow);


					Console.WriteLine($"\t\t\t\t\t{selections[i]}");
					Console.ResetColor();
				}

				check = Keyboard(ref select, selectionsCount);
			}

			return select;
		}

		public static CV GetSelectCv(List<CV> selections, string? text = null)
		{
			int selectionsCount = selections.Count;
			int select = default;

			if (selections == null)
			{
				return new CV();
			}

			bool check = true;
			while (check)
			{
				Console.Clear();
				if (text != null)
					Console.WriteLine(text);


				Console.WriteLine("\t\t\t\tPress Tab to go back");
				for (int i = 0; i < selectionsCount; i++)
				{

					if (i == select)
						MySetColor(ConsoleColor.Black, ConsoleColor.DarkYellow);

					Console.WriteLine($"\t\t\t\t\t{selections[i]}");
					foreach (string? comp in selections[i]?.Companies)
					{
						Console.WriteLine(comp);
					}

					Console.ResetColor();
				}

				check = Keyboard(ref select, selectionsCount);
			}

			return selections[select];


		}
	}
}
