using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    [Serializable, DataContract]
    public class Student {
        private Groups _group;
        private string _studentID;

        [DataMember]
        public Name Name { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public string StudentID { // DEBUG DON'T USE, public set for XML Serialization
            get => _studentID;
            set {
                //string pattern = @"[A-Z]{2}\d{6}";
                //Regex regex = new Regex(pattern);
                //Match match = regex.Match(value);
                //if (!match.Success)
                //    throw new FormatException("StudentID must have format AA000000.");
                //_studentID = match.Value;
                _studentID = value;
            }
        }

        [DataMember]
        public Courses Course { get; set; } // DEBUG DON'T USE, public set for XML Serialization

        [DataMember]
        public Groups Group {
            get => _group;
            set {
                //if (Math.Truncate((double)(Convert.ToInt32(value) / 100)) != Convert.ToInt32(Course))
                //    throw new FormatException("The group does not match the course.");
                _group = value;
            }
        }

        public Student() {

        }

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

        public string GetInformation() {
            return $"Name:   {Name}\n" +
                   $"Age:    {GetAge()} ({Birthday.ToShortDateString()})\n" +
                   $"ID:     {StudentID}\n" +
                   $"Course: {Course}\n" +
                   $"Group:  {Group}";
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

        public override string ToString() => $"{Name} - {Group} - {Course} Course";
    }
}
