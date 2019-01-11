using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Tests
{
    public class TestObject {

        public int TestValue1 { get; set; }
        public string TestValue2 { get; set; }

        public TestObject(int testValue1, string testValue2) {
            TestValue1 = testValue1;
            TestValue2 = testValue2;
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            if (obj is TestObject testObject)
                return GetHashCode() == testObject.GetHashCode();
            throw new FormatException("Incoming object is not an 'TestObject' type.");
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public override string ToString() {
            return $"TestValue1:{TestValue1} - TestValue2:{TestValue2}";
        }
    }
}
