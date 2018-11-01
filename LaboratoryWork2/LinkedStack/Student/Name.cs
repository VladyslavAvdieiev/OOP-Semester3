using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class Name {
        private string _firstName;
        private string _middleName;
        private string _lastName;

        public string FirstName {
            get => _firstName;
            set {
                string pattern = @"([a-z]|[A-Z])+";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new FormatException("First name must have only letters.");
                _firstName = match.Value;
            }
        }

        public string MiddleName {
            get => _middleName;
            set {
                string pattern = @"([a-z]|[A-Z])+";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new FormatException("Middle name must have only letters.");
                _middleName = match.Value;
            }
        }

        public string LastName {
            get => _lastName;
            set {
                string pattern = @"([a-z]|[A-Z])+";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);
                if (!match.Success)
                    throw new FormatException("Last name must have only letters.");
                _lastName = match.Value;
            }
        }

        public Name(string firstName, string middleName, string lastName) {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public override string ToString() {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
