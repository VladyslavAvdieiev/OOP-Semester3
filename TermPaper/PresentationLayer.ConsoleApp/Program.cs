using System;
using BusinessAccessLayer.Entities;
using BusinessAccessLayer.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ConsoleApp
{
    class Program {
        #region Constants
        private const int ING = 0;
        private const int DISH = 1;
        private const int MENU = 2;
        private const int ORDER = 3;

        private const int ADDITION = 0;
        private const int MODIFICATION = 1;
        private const int OVERVIEW = 2;
        private const int SEARCH = 3;
        #endregion

        private static IDataAccessor<List<Ingredient>> ingredientDataAccessor;
        private static IDataAccessor<List<Dish>> dishDataAccessor;
        private static IDataAccessor<List<Menu>> menuDataAccessor;
        private static IDataAccessor<List<Order>> orderDataAccessor;

        static void Main(string[] args) {
            ingredientDataAccessor = new XmlSerializerService<List<Ingredient>>();
            dishDataAccessor = new XmlSerializerService<List<Dish>>();
            menuDataAccessor = new XmlSerializerService<List<Menu>>();
            orderDataAccessor = new XmlSerializerService<List<Order>>();

            DisplayMainMenu();
        }

        private static void DisplayMainMenu() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Add...");
            Console.WriteLine("2. Modify...");
            Console.WriteLine("3. View...");    
            Console.WriteLine("4. Search...");
            Console.WriteLine("ESC. Exit");
            Console.ForegroundColor = ConsoleColor.Gray;

            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.WriteLine("'1. Add' was pressed");
                    Console.ReadLine();
                    DisplayMainMenu();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("'2. Modify' was pressed");
                    Console.ReadLine();
                    DisplayMainMenu();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("'3. View' was pressed");
                    Console.ReadLine();
                    DisplayMainMenu();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("'4. Search' was pressed");
                    Console.ReadLine();
                    DisplayMainMenu();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    PrintError("[Error]: Command does not exist. Press any key to continue...");
                    DisplayMainMenu();
                    break;
            }
        }

        private static void PrintError(string errorMessage) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
    }
}
