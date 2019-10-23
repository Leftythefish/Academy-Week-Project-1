using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;
using Miniprojekti_1;

namespace UnitTestProjectEngine
{
    [TestClass]
    class UserInput
    {
        [TestMethod]
        public void InputTooLong()
        {
            string name = "This is a name that is way too long and includes too many characters";
            Program.CheckInput(name);
            string expected = "";
            Assert.AreEqual(expected, name);
        }
    }
}
