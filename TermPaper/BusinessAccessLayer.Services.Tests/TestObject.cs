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

        public override string ToString() {
            return $"TestValue1:{TestValue1} - TestValue2:{TestValue2}";
        }
    }
}
