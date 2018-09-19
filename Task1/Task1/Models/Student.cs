using System;

namespace Task1.Models
{
    /// <summary>
    /// Class repersent Student object
    /// </summary>
    /// <remarks>
    /// Derived from Person
    /// </remarks>
    public class Student : Person
    {
        /// <summary>
        /// Pointer to teacher object
        /// </summary>
        public Teacher Teacher { get; set; }

        /// <summary>
        /// The class default constructor.
        /// </summary>
        public Student() : base()
        {
        }

        /// <summary>
        /// The class constructor with parameters.
        /// </summary>
        /// <param name="id">person id</param>
        /// <param name="name">person name</param>
        /// <param name="age">person age</param>
        /// <param name="teacher">student teacher</param>
        /// <remarks>Pass params to base class</remarks>
        public Student(int id, string name, int age, Teacher teacher) : base(id, name, age)
        {
            Teacher = teacher;
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
        /// <remarks>Call base class method</remarks>
        public override string ToString()
        {
            return base.ToString() + " teacher:" + Teacher.Name;
        }
    }
}