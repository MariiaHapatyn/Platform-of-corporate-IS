using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Models;
using System.Collections.Generic;

namespace Task1UnitTests
{
    /// <summary>
    /// Class for testing models
    /// </summary>
    [TestClass]
    public class PersonTests
    {
        /// <summary>
        /// Person equals Test
        /// </summary>
        [TestMethod]
        public void PersonEqualsTest()
        {
            Person p1 = new Person(1, "aaa", 12);
            Person p2 = new Person(1, "aaa", 12);
            bool res = p1.Equals(p2);
            Assert.IsTrue(res);
        }

        /// <summary>
        /// Person to string Test
        /// </summary>
        [TestMethod]
        public void PersonToStringTest()
        {
            Person p1 = new Person(1, "aaa", 12);
            p1.GetHashCode();
            string exp = p1.Name + " " + p1.Age + " years";
            string res = p1.ToString();
            Assert.AreEqual(exp, res);
        }
    }
}
