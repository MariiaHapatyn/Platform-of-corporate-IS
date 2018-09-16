using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Models;
using System.Collections.Generic;

namespace Task1UnitTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void PersonEqualsTest()
        {
            Person p1 = new Person(1, "aaa", 12);
            Person p2 = new Person(1, "aaa", 12);
            bool res=p1.Equals(p2);
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void PersonToStringTest()
        {
            Person p1 = new Person(1, "aaa", 12);
            p1.GetHashCode();
            string exp = p1.Name + " " + p1.Age + " years";
            string res = p1.ToString();
            Assert.AreEqual(exp, res);
        }
        [TestMethod]
        public void StudentEqualsTest()
        {
            Teacher t1 = new Teacher(1,"aaa",23,new List<Student>());
            Student p1 = new Student(1, "aaa", 12,t1);
            Student p2 = new Student(1, "aaa", 12,t1);
            bool exp = p1.Equals(p2);
            Assert.IsTrue(exp);
        }
        [TestMethod]
        public void StudentToStringTest()
        {
            Teacher t1 = new Teacher(1, "aaa", 23, new List<Student>());
            Student p1 = new Student(1, "aaa", 12, t1);
            p1.GetHashCode();
            string exp = p1.Name + " " + p1.Age + " years"+ " teacher:" + p1.Teacher.Name;
            string res = p1.ToString();
            Assert.AreEqual(exp, res);
        }
        [TestMethod]
        public void TeacherEqualsTest()
        {
            Teacher t1 = new Teacher(1, "aaa", 23, new List<Student>());
            Teacher t2 = new Teacher(1, "aaa", 23, new List<Student>());
            bool exp = t1.Equals(t2);
            Assert.IsTrue(exp);
        }
        [TestMethod]
        public void TeacherToStringTest()
        {
            Teacher t2 = new Teacher(1, "aaa", 23, new List<Student>());
            Student t = new Student(1, "aaa", 12, t2);
;           Teacher t1 = new Teacher(1, "aaa", 23, t);
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
