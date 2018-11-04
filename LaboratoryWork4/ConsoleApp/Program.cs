using System;
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

            #endregion
        }
    }
}
