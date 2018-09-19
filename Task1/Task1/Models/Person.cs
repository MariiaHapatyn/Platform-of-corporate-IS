using System;
using System.IO;

namespace Task1.Models
{
    /// <summary>
    /// Class repersent Person object
    /// </summary>
    /// <remarks>
    /// This is the base class for our hierarchy
    /// </remarks>
    public class Person
    {
        /// <summary>
        /// Store for the Id property.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Store for the Name property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Store for the Age property.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The class default constructor.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// The class constructor with parameters.
        /// </summary>
        /// <param name="id"> person id </param>
        /// <param name="name"> person name </param>
        /// <param name="age"> person age </param>
        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Generate instance hashcode
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }

        /// <summary>
        /// Compare two objects
        /// </summary>
        /// <param name="obj">object with which to compare</param>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Person person = (Person)obj;
            return this.Name == person.Name && this.Age == person.Age && this.Id == person.Id;
        }

        /// <summary>
        /// Create string based on object properties
        /// </summary>
        public override string ToString()
        {
            return Name + " " + Age + " years";
        }

        /// <summary>
        /// Parse string to appropriate fileds
        /// </summary>
        /// <param name="line">single line, represent oject properties which are sepereated with specific token</param>
        public virtual void Input(string line)
        {
            string[] words = line.Split(' ');
            Id = Convert.ToInt32(words[0]);
            Name = words[1];
            Age = Convert.ToInt32(words[2]);
        }

    }
}