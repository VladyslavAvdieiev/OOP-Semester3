using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class Student : IComparable {
        private string _studentID;

        public Name Name { get; private set; }

        public DateTime Birthday { get; set; }

        public string StudentID {
            get => _studentID;
            private set {
                string pattern = @"[A-Z]{2}\d{6}";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new FormatException("StudentID must have format AA000000.");
                _studentID = match.Value;
            }
        }

        public Courses Course { get; private set; }

        public Groups Group { get; private set; }
    
        public Student(Name name, DateTime birthday, string studentID, Courses course, Groups group) {
            Name = name;
            Birthday = birthday;
            StudentID = studentID;
            Course = course;
            Group = group;
        }

        public int GetAge() {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today.Month < Birthday.Month || (today.Month == Birthday.Month && today.Day < Birthday.Day))
                age--;
            return age;
        }

        public void MoveUp() {
            if (Course > Courses.NotAStudent && Course < Courses.Graduate) {
                Course++;
                if (Course < Courses.Graduate)
                    Group += 100;
                else
                    Group = Groups.Graduate;
            }
        }

        public void ChangeTheGroup(Groups group) {
            if (Math.Truncate((double)(Convert.ToInt32(group) / 100)) != Convert.ToInt32(Course))
                throw new FormatException("The group does not match the course");
            Group = group;
        }

        public string GetInformation() {
            return $"Name:   {Name}\n" +
                   $"Age:    {GetAge()} ({Birthday.ToShortDateString()})\n" +
                   $"ID:     {StudentID}\n" +
                   $"Course: {Course}\n" +
                   $"Group:  {Group}";
        }

        public int CompareTo(object obj) {
            if (!(obj is Student student))
                throw new FormatException("The type of the entry object is not a Student.");
            if (Group > student.Group)
                return 1;
            else if (Group < student.Group)
                return -1;
            return 0;
        }

        public override string ToString() {
            return $"{Name} - {Group} - {Course} Course";
            //return String.Format("{0, 40}{1, 20}{2, 20}", Name, Group, Course);
        }
    }
}
