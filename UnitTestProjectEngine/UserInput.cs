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
    }
}