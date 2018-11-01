using System;
using LinkedStack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program {

        static void Main(string[] args) {

            #region Initialization
            Student student1 = new Student(new Name("Lupka", "Pupka", "Pupkin"),
                new DateTime(2000, 11, 1), "KB131151", Courses.Second, Groups.PI220);
            Student student2 = new Student(new Name("Pupka", "Lupka", "Lupkin"),
                new DateTime(2001, 12, 3), "KB105712", Courses.First, Groups.PI116);
            Student student3 = new Student(new Name("Lupka", "Lupka", "Pupkin"),
                new DateTime(1999, 4, 17), "KB130211", Courses.Second, Groups.PI218);
            Student student4 = new Student(new Name("Pupka", "Pupka", "Pupkin"),
                new DateTime(1996, 10, 9), "KB175911", Courses.Graduate, Groups.Graduate);
            Student student5 = new Student(new Name("Pupka", "Pupka", "Lupkin"),
                new DateTime(2000, 7, 12), "KB154160", Courses.Fourth, Groups.PI419);
            Student student6 = new Student(new Name("Lupka", "Lupka", "Lupkin"),
                new DateTime(2001, 2, 22), "KB119611", Courses.Second, Groups.PI220);
            #endregion

            #region General Task
            List<Student> students1 = new List<Student>() {
                student1, student2, student3,
                student4, student5, student6
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var val in students1)
                Console.WriteLine(val);
            Console.WriteLine();

            students1.Sort();

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var val in students1)
                Console.WriteLine(val);
            Console.WriteLine();
            #endregion

            #region Individual Task
            LinkedStack<Student> students2 = new LinkedStack<Student>();
            students2.Push(student1);
            students2.Push(student2);
            students2.Push(student3);
            students2.Push(student4);
            students2.Push(student5);
            students2.Push(student6);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var val in students2)
                Console.WriteLine(val);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Pop1: {students2.Pop()}");
            Console.WriteLine($"Pop2: {students2.Pop()}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var val in students2)
                Console.WriteLine(val);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Peek: {students2.Peek()}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var val in students2)
                Console.WriteLine(val);
            Console.WriteLine();
            #endregion

            Console.ReadLine();
        }
    }
}
