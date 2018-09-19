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
    public class StudentTests
    {
        /// <summary>
        /// Student equals Test
        /// </summary>
        [TestMethod]
        public void StudentEqualsTest()
        {
            Teacher t1 = new Teacher(1, "aaa", 23, new List<Student>());
            Student p1 = new Student(1, "aaa", 12, t1);
            Student p2 = new Student(1, "aaa", 12, t1);
            bool exp = p1.Equals(p2);
            Assert.IsTrue(exp);
        }

        /// <summary>
        /// Student to string Test
        /// </summary>
        [TestMethod]
        public void StudentToStringTest()
        {
            Teacher t1 = new Teacher(1, "aaa", 23, new List<Student>());
            Student p1 = new Student(1, "aaa", 12, t1);
            p1.GetHashCode();
            string exp = p1.Name + " " + p1.Age + " years" + " teacher:" + p1.Teacher.Name;
            string res = p1.ToString();
            Assert.AreEqual(exp, res);
        }
    }
}
