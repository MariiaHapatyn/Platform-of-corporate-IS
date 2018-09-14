using System;

namespace Task1.Models
{
    public class Student : Person
    {
        public Teacher Teacher { get; set; }

        public Student() : base() { }

        public Student(int id, string name, int age, Teacher teacher) : base(id, name, age)
        {
            Teacher = teacher;
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
            return base.ToString() + " teacher:" + Teacher.Name;
        }

        public override void Input(string line)
        {
            string[] words = line.Split(';');
            base.Input(words[0]);
            string[] data = words[1].Split(' ');
            Teacher = new Teacher(Int32.Parse(data[0]), data[1], Int32.Parse(data[2]), this);
        }
    }
}