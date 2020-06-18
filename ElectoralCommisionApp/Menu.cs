using System;
using System.Collections.Generic;
using System.Text;

namespace ElectoralCommisionApp
{
    public class Menu
    {
        public string MenuTitle { get; set; }
        public List<MenuItem> menuItems = new List<MenuItem>() { new MenuItem() { Action = ExitMenu, Title = "Exit" } };
        public static void ExitMenu()
        {
            Environment.Exit(0);
        }

        public void AddMenuItem(string title, Action action)
        {
            menuItems.Add(new MenuItem() { Action = action, Title = title });
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(MenuTitle);
                Console.WriteLine();
                foreach (var menuItem in menuItems)
                {
                    Console.WriteLine($"{menuItems.IndexOf(menuItem)}.{menuItem.Title}");
                }

                Console.WriteLine("Choose menu option");
                var userInput = Console.ReadLine();
                int pointedOption = -1;
                if (int.TryParse(userInput, out pointedOption) && menuItems.Count > pointedOption && pointedOption >= 0)
                {
                    menuItems[pointedOption].Action?.Invoke();
                }
            }
        }
    }
}
