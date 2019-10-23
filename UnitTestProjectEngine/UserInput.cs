using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;
using Miniprojekti_1;

namespace UnitTestProjectEngine
{
    [TestClass]
    public class UserInput
    {
        [TestMethod]
        public void InputOK()
        {
            string input = "Joan";
            string name = Program.CheckInput(input);
            string expected = "Joan";
            Assert.AreEqual(expected, name);
        }

        [TestMethod]
        public void InputTooLong()
        {
            string input = "This name is way too long and contains too many characters";
            string name = Program.CheckInput(input);
            string expected = "";
            Assert.AreEqual(expected, name);
        }
    }
}
