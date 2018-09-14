using System;
using System.Collections.Generic;
using System.IO;
using Task1.Models;

namespace Task1
{
    public class Task
    {
        public List<string> ReadFromFile(string fileName)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        public List<Person> ParseLines(List<string> lines)
        {
            List<Person> persons = new List<Person>();
            foreach (string line in lines)
            {
                string[] words = line.Split(new[] { ' ' }, 2);
                Person person;
                if (words[0] == "student")
                {
                    person = new Student();
                }
                else if (words[0] == "teacher")
                {
                    person = new Teacher();
                }
                else
                {
                    throw new Exception("invalid data");
                }
                person.Input(words[1]);

                var a = person.ToString();
                persons.Add(person);
            }

            return persons;
        }

        public void DoTasks()
        {
            string fileName = "persons.txt";
            List<string> data = ReadFromFile(fileName);
            List<Person> persons = ParseLines(data);
        }
    }
}