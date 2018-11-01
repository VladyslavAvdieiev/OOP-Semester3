using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    public class Teacher : Person, IStudy, ITeach {
        public Teacher(string firstName, string middleName, string lastName)
            : base(firstName, middleName, lastName) { }

        public void Study() {
            throw new NotImplementedException();
        }

        public void Teach() {
            throw new NotImplementedException();
        }

        public override string[] Disassemble() {
            return new string[] { GetType().Name,
                                "FirstName", FirstName,
                                "MiddleName", MiddleName,
                                "Lastname", LastName };
        }
    }
}
