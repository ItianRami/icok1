using System;
using System.Collections.Generic;
using System.Text;

namespace icok1.RecordsGenerator.Classes
{
    public static class ConsoleExtensions
    {
        public static void SetColor(ConsoleColor? backgroundColor = ConsoleColor.Black, ConsoleColor? foregroundColor = ConsoleColor.White, bool setEndlineine = false)
        {
            if (backgroundColor != null)
            {
                Console.BackgroundColor = backgroundColor.Value;
            }
            if (foregroundColor != null)
            {
                Console.ForegroundColor = foregroundColor.Value;
            }
            if (setEndlineine)
            {
                ConsoleExtensions.WriteSpaceLine();
            }
        }

        internal static void ShowWelcomeScreen()
        {
            SetColor(ConsoleColor.White, ConsoleColor.DarkBlue, true);
            Console.WriteLine(@"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("     _________     _______                        ");
            Console.WriteLine(@"     |        \   /       \    |\      /|   |     ");
            Console.WriteLine(@"     |        |   |        |   | \    / |   |     ");
            Console.WriteLine(@"     |________|   |________|   |  \  /  |   |     ");
            Console.WriteLine(@"     |\           |        |   |   \/   |   |     ");
            Console.WriteLine(@"     |  \         |        |   |        |   |     ");
            Console.WriteLine(@"     |    \       |        |   |        |   |     ");
            Console.WriteLine(@"     |      \     |        |   |        |   |     ");
            ConsoleExtensions.WriteSpaceLine();
            Console.WriteLine(@"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            ConsoleExtensions.WriteSpaceLine();
            Console.WriteLine(@"       Welcome in CosmosDb Record Generator       ");
            ConsoleExtensions.WriteSpaceLine();
            Console.ResetColor();

        }

        internal static string ShowMenu(bool showFirstOnly = false)
        {
            ConsoleExtensions.WriteSpaceLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1 - Clear Database");
            if (!showFirstOnly)
            {
                Console.WriteLine("2 - Generate Products");
                Console.WriteLine("3 - Generate Records");
            }
            Console.WriteLine("4 - Exit");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Choose from the Menu above and only enter the number.");
            var selectedMenuItem = Console.ReadKey().Key;
            Console.WriteLine("");

            var allowedMenuItems = new List<string> { "D1" };
            if (!showFirstOnly)
            {
                allowedMenuItems.AddRange(new List<string> { "D2", "D3" });
            }
            allowedMenuItems.Add("D4");
            if (!allowedMenuItems.Contains(selectedMenuItem.ToString()))
            {
                SetColor(ConsoleColor.Red);
                Console.WriteLine("Wrong Input");
                Console.ResetColor();
                return ShowMenu(showFirstOnly);
            }
            return selectedMenuItem.ToString();
        }

        internal static void WriteSpaceLine()
        {
            ConsoleExtensions.WriteSpaceLine();
        }
    }
}
