using System;
using System.Collections.Generic;

namespace Task1.Models
{
    public class Teacher : Person
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public Teacher() : base() { }

        public Teacher(int id, string name, int age, List<Student> students) : base(id, name, age)
        {
            Students = students;
        }

        public Teacher(int id, string name, int age, Student student) : base(id, name, age)
        {
            Students.Add(student);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

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