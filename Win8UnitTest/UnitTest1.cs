﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Win8UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NetCoreTest()
        {
            var type = WithEmit.Emitter.CreateTestType();
            var mi = type.GetDeclaredMethod("TestMethod");
            //var pis = mi.GetParameters();
            //var d = (Func<int, double, string>)mi.CreateDelegate(typeof(Func<int, double, string>), mi);
            //var result = d(123, 456.789);
            var result = (string)mi.Invoke(null, new object[] { 123, 456.789 });

            Assert.AreEqual("123-456.789", result);
        }
    }
}
