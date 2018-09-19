using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Models;
using Task1;
using System.Collections.Generic;

namespace Task1UnitTests
{
    /// <summary>
    /// Class for testing tasks
    /// </summary>
    [TestClass]
    public class TaskTests
    {
        /// <summary>
        /// Read from file Test
        /// </summary>
        [TestMethod]
        public void ReadFromFileTest()
        {
            Task t = new Task();
            List<string> l = t.ReadFromFile("persons.txt");
        }

        /// <summary>
        /// Read from file exception Test
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void ReadFromFileExceptionTest()
        {
            Task t = new Task();
            List<string> l = t.ReadFromFile("p.txt");
        }

        /// <summary>
        /// Count students Test
        /// </summary>
        [TestMethod]
        public void CountStudentsTest()
        {
            Task t = new Task();
            List<string> data = t.ReadFromFile("persons.txt");
            List<Person> persons = t.ParseLines(data);
            int amountOfStudents = t.CountStudents(persons);
            int exp = 3;
            Assert.AreEqual(amountOfStudents, exp);
        }

        /// <summary>
        /// Count teachers Test
        /// </summary>
        [TestMethod]
        public void CountTeachersTest()
        {
            Task t = new Task();
            List<string> data = t.ReadFromFile("persons.txt");
            List<Person> persons = t.ParseLines(data);
            int amountOfTeachers = t.CountTeachers(persons);
            int exp = 3;
            Assert.AreEqual(amountOfTeachers, exp);
        }

        /// <summary>
        /// Count teachers Test
        /// </summary>
        [TestMethod]
        public void CloneTest()
        {
            Task t = new Task();
            List<string> data = t.ReadFromFile("persons.txt");
            List<Person> persons = t.ParseLines(data);
            List<Person> cloned = t.CloneList(persons);
            CollectionAssert.AreEqual(persons, cloned);
        }

        /// <summary>
        /// Do tasks Test
        /// </summary>
        [TestMethod]
        public void DoTasksTest()
        {
            Task t = new Task();
            t.DoTasks();
        }
    }
}