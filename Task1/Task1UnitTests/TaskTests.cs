using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Models;
using Task1;
using System.Collections.Generic;

namespace Task1UnitTests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void ReadFromFileTest()
        {
            Task t = new Task();
            List<string> l = t.ReadFromFile("persons.txt");
        }
        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void ReadFromFileExceptionTest()
        {
            Task t = new Task();
            List<string> l = t.ReadFromFile("p.txt");
        }
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
        [TestMethod]
        public void DoTasksTest()
        {
            Task t = new Task();
            t.DoTasks();
        }
    }
}