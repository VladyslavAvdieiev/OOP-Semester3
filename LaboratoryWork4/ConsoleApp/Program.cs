using System;
using Events;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    delegate int[] Sort(int[] arr);

    class Program {

        static void Main(string[] args) {
            #region First Task
            Sort sortDel = new Sort(arr => {
                int counter = 0;
                for (int i = 1; i < arr.Length; i++)
                    for (int j = i; j > 0 && arr[j - 1] > arr[j]; j--) {
                        counter++;
                        int tmp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tmp;
                    }
                return arr;
            });
            sortDel(new int[] { 9, 8, 7, 1, 2, 3, 6, 5, 4, 0 });
            #endregion

            #region Second Task
            Car car = new Car(1000, 100);
            car.Refueled += (sender, e) => Console.WriteLine($"{e.Message} Fuel: {e.CurrentFuel}");
            car.RanOutOfFuel += (sender, e) => Console.WriteLine($"{e.Message} Fuel: {e.CurrentFuel}");
            car.StartedMoving += (sender, e) => Console.WriteLine($"{e.Message} Fuel: {e.CurrentFuel}");
            car.StoppedMoving += (sender, e) => Console.WriteLine($"{e.Message} Fuel: {e.CurrentFuel}");
            while (true)
                switch (Console.ReadKey().Key) {
                    case ConsoleKey.W:
                        Console.ForegroundColor = ConsoleColor.Green;
                        car.StartMoving();
                        break;
                    case ConsoleKey.S:
                        Console.ForegroundColor = ConsoleColor.Red;
                        car.StopMoving();
                        break;
                    case ConsoleKey.R:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        car.Refuel(1000);
                        break;
                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;
                }
            #endregion
        }
    }
}
