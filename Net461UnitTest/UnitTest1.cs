using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Net461UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Net461Test()
        {
            var type = WithEmit.Emitter.CreateTestType();
            var mi = type.GetDeclaredMethod("TestMethod");
            //var pis = mi.GetParameters();
            //var d = (Func<int, double, string>)mi.CreateDelegate(typeof(Func<int, double, string>), mi);
            //var result = d(123, 456.789);
            var result = (string)mi.Invoke(null, new object[] {123, 456.789});

            Assert.AreEqual("123-456.789", result);
        }
    }
}
