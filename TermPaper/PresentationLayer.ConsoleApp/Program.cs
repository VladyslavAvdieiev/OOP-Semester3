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
                    View(value);
                    break;
                case SEARCH:
                    Search(value);
                    break;
            }
        }

        private static void View(int value) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Details");
            Console.WriteLine("ESC. Back");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"\nObjects ");
            switch (value) {
                case ING:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(ingredientDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < ingredientDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {ingredientDataAccessor.Data[i]}");
                    break;
                case DISH:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(dishDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < dishDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {dishDataAccessor.Data[i]}");
                    break;
                case MENU:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(menuDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < menuDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {menuDataAccessor.Data[i]}");
                    break;
                case ORDER:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(orderDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < orderDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {orderDataAccessor.Data[i]}");
                    break;
            }

            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.SetCursorPosition(0, 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Does not work yet...");
                    Console.ReadLine();
                    View(value);
                    break;
                case ConsoleKey.Escape:
                    Select(OVERVIEW);
                    break;
                default:
                    PrintError("[Error]: Command does not exist. Press any key to continue...");
                    View(value);
                    break;
            }
        }

        private static void Search(int value) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Search");
            Console.WriteLine("ESC. Back");
            Console.ForegroundColor = ConsoleColor.White;

            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(0, 2);
                    Console.Write("Enter keyword: ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string key = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"\nMatches ");
                    switch (value) {
                        case ING:
                            List<Ingredient> ingredients = DataSearchService<Ingredient>.FindAllByKey(ingredientDataAccessor, key);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(ingredients.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (Ingredient ingredient in ingredients)
                                Console.WriteLine(ingredient);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nPress any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Search(value);
                            break;
                        case DISH:
                            List<Dish> dishes = DataSearchService<Dish>.FindAllByKey(dishDataAccessor, key);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(dishes.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (Dish dish in dishes)
                                Console.WriteLine(dish);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nPress any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Search(value);
                            break;
                        case MENU:
                            List<Menu> menus = DataSearchService<Menu>.FindAllByKey(menuDataAccessor, key);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(menus.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (Menu menu in menus)
                                Console.WriteLine(menu);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nPress any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Search(value);
                            break;
                        case ORDER:
                            List<Order> orders = DataSearchService<Order>.FindAllByKey(orderDataAccessor, key);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(orders.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (Order order in orders)
                                Console.WriteLine(order);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nPress any key to continue...");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Search(value);
                            break;
                    }
                    break;
                case ConsoleKey.Escape:
                    Select(SEARCH);
                    break;
                default:
                    PrintError("[Error]: Command does not exist. Press any key to continue...");
                    Search(value);
                    break;
            }
        }
    }
}
