using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    public class Student : Person, IStudy {
        private string _birthday;
        private string _studentID;
        private int _course;

        public string Birthday {
            get => _birthday;
            set {
                string pattern = @"(\d{2}\.\d{2}\.\d{4})|(\d{2}/\d{2}/\d{4})";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new FormatException("Birthday must have format 01.01.1996 or 01/01/1996.");
                _birthday = match.Value;
            }
        }

        public string StudentID {
            get => _studentID;
            set {
                string pattern = @"[A-Z]{2}\d{6}";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new FormatException("StudentID must have format AA000000.");
                _studentID = match.Value;
            }
        }

        public int Course {
            get => _course;
            set {
                if (value < 1 || value > 6)
                    throw new FormatException("Value of 'Course' must be from 1 to 6.");
                _course = value;
            }
        }

        public Student(string firstName, string middleName, string lastName, string birthday, string studentID, int course)
            : base(firstName, middleName, lastName) {
            StudentID = studentID;
            Course = course;
            Birthday = birthday;
        }

        public void Study() {
            throw new NotImplementedException();
        }

        public override string[] Disassemble() {
            return new string[] { GetType().Name,
                                "FirstName", FirstName,
                                "MiddleName", MiddleName,
                                "Lastname", LastName,
                                "Birthday", Birthday,
                                "StudentID", StudentID,
                                "Course", Course.ToString() };
        }
    }
}
