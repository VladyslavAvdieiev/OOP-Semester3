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
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[ 1 ] Add...");
            Console.WriteLine("[ 2 ] Modify...");
            Console.WriteLine("[ 3 ] View...");    
            Console.WriteLine("[ 4 ] Search...");
            Console.WriteLine("[ESC] Exit");
            Console.ForegroundColor = ConsoleColor.Black;

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
                    PrintError("Command does not exist. Press 'Enter' to continue...");
                    DisplayMainMenu();
                    break;
            }
        }

        private static void PrintError(string errorMessage) {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[ERR] {errorMessage}");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }

        private static void CleanConsole(int cursorTop, int rows) {
            string filler = new string(' ', 120);
            Console.SetCursorPosition(0, cursorTop);
            for (int i = 0; i < rows; i++)
                Console.Write(filler);
        }

        private static void SaveData(int value) {
            switch (value) {
                case ING:
                    ingredientDataAccessor.Clear();
                    ingredientDataAccessor.Write();
                    break;
                case DISH:
                    dishDataAccessor.Clear();
                    dishDataAccessor.Write();
                    break;
                case MENU:
                    menuDataAccessor.Clear();
                    menuDataAccessor.Write();
                    break;
                case ORDER:
                    orderDataAccessor.Clear();
                    orderDataAccessor.Write();
                    break;
            }
        }

        private static void Select(int mode) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[ 1 ] Ingredients");
            Console.WriteLine("[ 2 ] Dishes");
            Console.WriteLine("[ 3 ] Menus");
            Console.WriteLine("[ 4 ] Orders");
            Console.WriteLine("[ESC] Back");
            Console.ForegroundColor = ConsoleColor.Black;

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
                    PrintError("Command does not exist. Press 'Enter' to continue...");
                    Select(mode);
                    break;
            }

            switch (mode) {
                case ADDITION:
                    Add(value);
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

        private static void Add(int value) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[ 1 ] Add new");
            Console.WriteLine("[ 2 ] Save changes");
            Console.WriteLine("[ESC] Back");
            Console.ForegroundColor = ConsoleColor.Black;

            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    switch (value) {
                        case ING:
                            ingredientDataAccessor.Data.Add(new Ingredient());
                            Console.SetCursorPosition(0, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("New ingredient was created. Set settings:");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            try {
                                Console.Write("Name: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                ingredientDataAccessor.Data[ingredientDataAccessor.Data.Count - 1].Name = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Cost: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                ingredientDataAccessor.Data[ingredientDataAccessor.Data.Count - 1].Cost = Convert.ToDouble(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Weight: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                ingredientDataAccessor.Data[ingredientDataAccessor.Data.Count - 1].Weight = Convert.ToDouble(Console.ReadLine());

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("New ingredient was added successfully. Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                PrintError($"{e.Message} Created ingredient was deleted. Press 'Enter' to continue...");
                                ingredientDataAccessor.Data.RemoveAt(ingredientDataAccessor.Data.Count - 1);
                            }
                            break;
                        case DISH:
                            dishDataAccessor.Data.Add(new Dish());
                            Console.SetCursorPosition(0, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("New dish was created. Set settings:");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            try {
                                Console.Write("Name: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                dishDataAccessor.Data[dishDataAccessor.Data.Count - 1].Name = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Description: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                dishDataAccessor.Data[dishDataAccessor.Data.Count - 1].Description = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Cost: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                dishDataAccessor.Data[dishDataAccessor.Data.Count - 1].Cost = Convert.ToDouble(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Time: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                dishDataAccessor.Data[dishDataAccessor.Data.Count - 1].Time = Convert.ToDouble(Console.ReadLine());

                                Console.SetCursorPosition(0, Console.CursorTop + 2);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                for (int i = 0; i < ingredientDataAccessor.Data.Count; i++)
                                    Console.WriteLine($"{i}. {ingredientDataAccessor.Data[i]}");

                                Console.SetCursorPosition(0, 9);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Index of ingredient (-1 to stop): ");
                                Console.ForegroundColor = ConsoleColor.White;

                                int cursorLeft = Console.CursorLeft;
                                int cursorTop = Console.CursorTop;
                                int index = int.Parse(Console.ReadLine());
                                while (index != -1) {
                                    dishDataAccessor.Data[dishDataAccessor.Data.Count - 1].Ingredients.Add(ingredientDataAccessor.Data[index]);
                                    cursorLeft += index.ToString().Length;
                                    Console.SetCursorPosition(cursorLeft++, cursorTop);
                                    Console.Write(',');
                                    index = int.Parse(Console.ReadLine());
                                }

                                CleanConsole(Console.CursorTop + 1, ingredientDataAccessor.Data.Count);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(0, Console.CursorTop - ingredientDataAccessor.Data.Count - 1);
                                Console.Write("New dish was added successfully. Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                CleanConsole(Console.CursorTop + 1, ingredientDataAccessor.Data.Count);
                                Console.SetCursorPosition(0, 10);
                                PrintError($"{e.Message} Created dish was deleted. Press 'Enter' to continue...");
                                dishDataAccessor.Data.RemoveAt(dishDataAccessor.Data.Count - 1);
                            }
                            break;
                        case MENU:
                            menuDataAccessor.Data.Add(new Menu());
                            Console.SetCursorPosition(0, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("New menu was created. Set settings:");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            try {
                                Console.Write("Name: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                menuDataAccessor.Data[menuDataAccessor.Data.Count - 1].Name = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Description: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                menuDataAccessor.Data[menuDataAccessor.Data.Count - 1].Description = Console.ReadLine();

                                Console.SetCursorPosition(0, Console.CursorTop + 2);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                for (int i = 0; i < dishDataAccessor.Data.Count; i++)
                                    Console.WriteLine($"{i}. {dishDataAccessor.Data[i]}");

                                Console.SetCursorPosition(0, 7);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Index of dish (-1 to stop): ");
                                Console.ForegroundColor = ConsoleColor.White;

                                int cursorLeft = Console.CursorLeft;
                                int cursorTop = Console.CursorTop;
                                int index = int.Parse(Console.ReadLine());
                                while (index != -1) {
                                    menuDataAccessor.Data[menuDataAccessor.Data.Count - 1].Dishes.Add(dishDataAccessor.Data[index]);
                                    cursorLeft += index.ToString().Length;
                                    Console.SetCursorPosition(cursorLeft++, cursorTop);
                                    Console.Write(',');
                                    index = int.Parse(Console.ReadLine());
                                }

                                CleanConsole(Console.CursorTop + 1, dishDataAccessor.Data.Count);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(0, Console.CursorTop - dishDataAccessor.Data.Count - 1);
                                Console.Write("New menu was added successfully. Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                CleanConsole(Console.CursorTop + 1, dishDataAccessor.Data.Count);
                                Console.SetCursorPosition(0, 8);
                                PrintError($"{e.Message} Created menu was deleted. Press 'Enter' to continue...");
                                menuDataAccessor.Data.RemoveAt(menuDataAccessor.Data.Count - 1);
                            }
                            break;
                        case ORDER:
                            orderDataAccessor.Data.Add(new Order());
                            Console.SetCursorPosition(0, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("New order was created. Set settings:");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            try {
                                Console.Write("TableNumber: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                orderDataAccessor.Data[orderDataAccessor.Data.Count - 1].TableNumber = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Cost: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                orderDataAccessor.Data[orderDataAccessor.Data.Count - 1].Cost = Convert.ToDouble(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Remark: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                orderDataAccessor.Data[orderDataAccessor.Data.Count - 1].Remark = Console.ReadLine();

                                Console.SetCursorPosition(0, Console.CursorTop + 2);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                for (int i = 0; i < dishDataAccessor.Data.Count; i++)
                                    Console.WriteLine($"{i}. {dishDataAccessor.Data[i]}");

                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Index of dish (-1 to stop): ");
                                Console.ForegroundColor = ConsoleColor.White;

                                int cursorLeft = Console.CursorLeft;
                                int cursorTop = Console.CursorTop;
                                int index = int.Parse(Console.ReadLine());
                                while (index != -1) {
                                    orderDataAccessor.Data[orderDataAccessor.Data.Count - 1].Dishes.Add(dishDataAccessor.Data[index]);
                                    cursorLeft += index.ToString().Length;
                                    Console.SetCursorPosition(cursorLeft++, cursorTop);
                                    Console.Write(',');
                                    index = int.Parse(Console.ReadLine());
                                }
                                
                                CleanConsole(Console.CursorTop + 1, dishDataAccessor.Data.Count);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(0, Console.CursorTop - dishDataAccessor.Data.Count - 1);
                                Console.Write("New order was added successfully. Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                CleanConsole(Console.CursorTop + 1, dishDataAccessor.Data.Count);
                                Console.SetCursorPosition(0, 9);
                                PrintError($"{e.Message} Created order was deleted. Press 'Enter' to continue...");
                                orderDataAccessor.Data.RemoveAt(orderDataAccessor.Data.Count - 1);
                            }
                            break;
                    }
                    Add(value);
                    break;
                case ConsoleKey.D2:
                    SaveData(value);
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Data saved successfully. Press 'Enter' to continue...");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ReadLine();
                    Add(value);
                    break;
                case ConsoleKey.Escape:
                    Select(ADDITION);
                    break;
                default:
                    PrintError("Command does not exist. Press 'Enter' to continue...");
                    Add(value);
                    break;
            }
        }

        private static void View(int value) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[ 1 ] Details about...");
            Console.WriteLine("[ESC] Back");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Objects ");
            Console.ForegroundColor = ConsoleColor.Green;
            switch (value) {
                case ING:
                    Console.Write(ingredientDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    for (int i = 0; i < ingredientDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {ingredientDataAccessor.Data[i]}");
                    break;
                case DISH:
                    Console.Write(dishDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    for (int i = 0; i < dishDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {dishDataAccessor.Data[i]}");
                    break;
                case MENU:
                    Console.Write(menuDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    for (int i = 0; i < menuDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {menuDataAccessor.Data[i]}");
                    break;
                case ORDER:
                    Console.Write(orderDataAccessor.Data.Count);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(":");
                    for (int i = 0; i < orderDataAccessor.Data.Count; i++)
                        Console.WriteLine($"{i}. {orderDataAccessor.Data[i]}");
                    break;
            }

            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Black;
            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int index;
                    switch (value) {
                        case ING:
                            Console.Write("Index of ingredient: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            index = int.Parse(Console.ReadLine());
                            CleanConsole(Console.CursorTop, ingredientDataAccessor.Data.Count + 1);
                            Console.SetCursorPosition(0, 3);
                            try {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"\nInformation about ingredient at ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(index);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(" index:");
                                Console.WriteLine($"Name: {ingredientDataAccessor.Data[index].Name}");
                                Console.WriteLine($"Cost: {ingredientDataAccessor.Data[index].Cost}");
                                Console.WriteLine($"Weight: {ingredientDataAccessor.Data[index].Weight}");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                PrintError($"{e.Message}. Press 'Enter' to continue...");
                            }
                            break;
                        case DISH:
                            Console.Write("Index of dish: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            index = int.Parse(Console.ReadLine());
                            CleanConsole(Console.CursorTop, dishDataAccessor.Data.Count + 1);
                            Console.SetCursorPosition(0, 3);
                            try {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"\nInformation about dish at ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(index);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(" index:");
                                Console.WriteLine($"Name: {dishDataAccessor.Data[index].Name}");
                                Console.WriteLine($"Description: {dishDataAccessor.Data[index].Description}");
                                Console.WriteLine($"Cost: {dishDataAccessor.Data[index].Cost}");
                                Console.WriteLine($"Weight: {dishDataAccessor.Data[index].Weight}");
                                Console.WriteLine($"Time: {dishDataAccessor.Data[index].Time}");
                                Console.WriteLine("\nIngredients:");
                                foreach (Ingredient ingredient in dishDataAccessor.Data[index].Ingredients)
                                    Console.WriteLine(ingredient);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                PrintError($"{e.Message}. Press 'Enter' to continue...");
                            }
                            break;
                        case MENU:
                            Console.Write("Index of menu: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            index = int.Parse(Console.ReadLine());
                            CleanConsole(Console.CursorTop, menuDataAccessor.Data.Count + 1);
                            Console.SetCursorPosition(0, 3);
                            try {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"\nInformation about menu at ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(index);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(" index:");
                                Console.WriteLine($"Name: {menuDataAccessor.Data[index].Name}");
                                Console.WriteLine($"Description: {menuDataAccessor.Data[index].Description}");
                                Console.WriteLine("\nDishes:");
                                foreach (Dish dish in menuDataAccessor.Data[index].Dishes)
                                    Console.WriteLine(dish);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                PrintError($"{e.Message}. Press 'Enter' to continue...");
                            }
                            break;
                        case ORDER:
                            Console.Write("Index of order: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            index = int.Parse(Console.ReadLine());
                            CleanConsole(Console.CursorTop, orderDataAccessor.Data.Count + 1);
                            Console.SetCursorPosition(0, 3);
                            try {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"\nInformation about order at ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(index);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(" index:");
                                Console.WriteLine($"Date: {orderDataAccessor.Data[index].Date}");
                                Console.WriteLine($"TableNumber: {orderDataAccessor.Data[index].TableNumber}");
                                Console.WriteLine($"Cost: {orderDataAccessor.Data[index].Cost}");
                                Console.WriteLine($"Remark: {orderDataAccessor.Data[index].Remark}");
                                Console.WriteLine("\nDishes:");
                                foreach (Dish dish in orderDataAccessor.Data[index].Dishes)
                                    Console.WriteLine(dish);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Press 'Enter' to continue...");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.ReadLine();
                            }
                            catch (Exception e) {
                                PrintError($"{e.Message}. Press 'Enter' to continue...");
                            }
                            break;
                    }
                    View(value);
                    break;
                case ConsoleKey.Escape:
                    Select(OVERVIEW);
                    break;
                default:
                    PrintError("Command does not exist. Press 'Enter' to continue...");
                    View(value);
                    break;
            }
        }

        private static void Search(int value) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[ 1 ] Search");
            Console.WriteLine("[ESC] Back");
            Console.ForegroundColor = ConsoleColor.Black;

            switch (Console.ReadKey().Key) {
                case ConsoleKey.D1:
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter keyword: ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string key = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Matches ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (value) {
                        case ING:
                            List<Ingredient> ingredients = DataSearchService<Ingredient>.FindAllByKey(ingredientDataAccessor, key);
                            Console.Write(ingredients.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            foreach (Ingredient ingredient in ingredients)
                                Console.WriteLine(ingredient);
                            break;
                        case DISH:
                            List<Dish> dishes = DataSearchService<Dish>.FindAllByKey(dishDataAccessor, key);
                            Console.Write(dishes.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            foreach (Dish dish in dishes)
                                Console.WriteLine(dish);
                            break;
                        case MENU:
                            List<Menu> menus = DataSearchService<Menu>.FindAllByKey(menuDataAccessor, key);
                            Console.Write(menus.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            foreach (Menu menu in menus)
                                Console.WriteLine(menu);
                            break;
                        case ORDER:
                            List<Order> orders = DataSearchService<Order>.FindAllByKey(orderDataAccessor, key);
                            Console.Write(orders.Count);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(":");
                            foreach (Order order in orders)
                                Console.WriteLine(order);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Press 'Enter' to continue...");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ReadLine();
                    Search(value);
                    break;
                case ConsoleKey.Escape:
                    Select(SEARCH);
                    break;
                default:
                    PrintError("Command does not exist. Press 'Enter' to continue...");
                    Search(value);
                    break;
            }
        }
    }
}
