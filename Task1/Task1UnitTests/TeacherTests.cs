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
    public class TeacherTests
    {
        /// <summary>
        /// Teacher equals Test
        /// </summary>
        [TestMethod]
        public void TeacherEqualsTest()
        {
            Teacher t1 = new Teacher(1, "aaa", 23, new List<Student>());
            Teacher t2 = new Teacher(1, "aaa", 23, new List<Student>());
            bool exp = t1.Equals(t2);
            Assert.IsTrue(exp);
        }

        /// <summary>
        /// Teacher to string Test
        /// </summary>
        [TestMethod]
        public void TeacherToStringTest()
        {
            Teacher t2 = new Teacher(1, "aaa", 23, new List<Student>());
            Student t = new Student(1, "aaa", 12, t2);
            Teacher t1 = new Teacher(1, "aaa", 23, t);
            t1.GetHashCode();
            string exp = t1.Name + " " + t1.Age + " years" + " students:";
            foreach (Student student in t1.Students)
            {
                exp += " " + student;
            }

            string res = t1.ToString();
            Assert.AreEqual(exp, res);
        }
    }
}
