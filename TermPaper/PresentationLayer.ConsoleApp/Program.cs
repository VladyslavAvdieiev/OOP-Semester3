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

        private static IDataAccessor<Ingredient> ingredientDataAccessor;
        private static IDataAccessor<Dish> dishDataAccessor;
        private static IDataAccessor<Menu> menuDataAccessor;
        private static IDataAccessor<Order> orderDataAccessor;

        static void Main(string[] args) {
            ingredientDataAccessor = new XmlSerializerService<Ingredient>();
            dishDataAccessor = new XmlSerializerService<Dish>();
            menuDataAccessor = new XmlSerializerService<Menu>();
            orderDataAccessor = new XmlSerializerService<Order>();

            ingredientDataAccessor.Read();
            dishDataAccessor.Read();
            menuDataAccessor.Read();
            orderDataAccessor.Read();

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
            Console.ForegroundColor = ConsoleColor.White;

            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Select(ADDITION);
                    break;
                case ConsoleKey.D2:
                    Select(MODIFICATION);
                    break;
                case ConsoleKey.D3:
                    Select(OVERVIEW);
                    break;
                case ConsoleKey.D4:
                    Select(SEARCH);
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
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static void Select(int mode) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Ingredients");
            Console.WriteLine("2. Dishes");
            Console.WriteLine("3. Menus");
            Console.WriteLine("4. Orders");
            Console.WriteLine("ESC. Back");
            Console.ForegroundColor = ConsoleColor.White;

            int value = -1;
            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    value = ING;
                    break;
                case ConsoleKey.D2:
                    value = DISH;
                    break;
                case ConsoleKey.D3:
                    value = MENU;
                    break;
                case ConsoleKey.D4:
                    value = ORDER;
                    break;
                case ConsoleKey.Escape:
                    DisplayMainMenu();
                    break;
                default:
                    PrintError("[Error]: Command does not exist. Press any key to continue...");
                    Select(mode);
                    break;
            }

            switch (mode) {
                case ADDITION:
                    /*call the add method with value*/
                    break;
                case MODIFICATION:
                    /*call the modify method with value*/
                    break;
                case OVERVIEW:
                    /*call the view method with value*/
                    break;
                case SEARCH:
                    /*call the search method with value*/
                    break;
            }
        }
    }
}
