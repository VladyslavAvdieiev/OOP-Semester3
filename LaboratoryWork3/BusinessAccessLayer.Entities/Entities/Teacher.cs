using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Entities
{
    [Serializable, DataContract]
    public class Teacher {
        [DataMember]
        public Name Name { get; set; }

        public Teacher() {

        }

        public Teacher(Name name) {
            Name = name;
        }

        public string GetInformation() {
            return $"Name:   {Name}\n";
        }

        public override string ToString() => $"{Name}";
    }
}
