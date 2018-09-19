using System;
using System.Collections.Generic;
using System.IO;

namespace Task1.Models
{
    /// <summary>
    /// Class repersent Teacher object
    /// </summary>
    /// <remarks>
    /// Derived from Person
    /// </remarks>
    public class Teacher : Person
    {
        /// <summary>
        /// Pointer to list of students
        /// </summary>
        public List<Student> Students { get; set; } = new List<Student>();

        /// <summary>
        /// The class default constructor.
        /// </summary>
        public Teacher() : base()
        {
        }

        /// <summary>
        /// The class constructor with parameters.
        /// </summary>
        /// <param name="id">person id</param>
        /// <param name="name">person name</param>
        /// <param name="age">person age</param>
        /// <param name="students">students of teacher</param>
        /// <remarks>Pass params to base class</remarks>
        public Teacher(int id, string name, int age, List<Student> students) : base(id, name, age)
        {
            Students = students;
        }

        /// <summary>
        /// The class constructor with parameters.
        /// </summary>
        /// <param name="id">person id</param>
        /// <param name="name">person name</param>
        /// <param name="age">person age</param>
        /// <param name="student">student of teacher</param>
        /// <remarks>Pass params to base class</remarks>
        public Teacher(int id, string name, int age, Student student) : base(id, name, age)
        {
            Students.Add(student);
        }

        /// <summary>
        /// Generate instance hashcode
        /// </summary>
        /// <remarks>Call base class method</remarks>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compare two objects
        /// </summary>
        /// <param name="obj">object with which to compare</param>
        /// <remarks>Call base class method</remarks>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Create string based on object properties
        /// </summary>
        public override string ToString()
        {
            string str = base.ToString();
            str += " students:";
            foreach (Student student in Students)
            {
                str += " " + student;
            }

            return str;
        }        
    }
}