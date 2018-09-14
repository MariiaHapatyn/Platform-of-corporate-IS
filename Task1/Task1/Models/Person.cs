using System;

namespace Task1.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

        public Person() { }

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Person person = (Person)obj;
            return (this.Name == person.Name && this.Age == person.Age);
        }

        public override string ToString()
        {
            return Name + " " + Age + " years";
        }

        public virtual void Input(string line)
        {
            string[] words = line.Split(' ');
            Id = Convert.ToInt32(words[0]);
            Name = words[1];
            Age = Convert.ToInt32(words[2]);
        }
    }
}