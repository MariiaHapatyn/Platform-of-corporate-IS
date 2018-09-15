using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Task1.Models;

namespace Task1
{
    public class Task
    {
        public List<string> ReadFromFile(string fileName)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
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
                    Student student = new Student();
                    student.Input(words[1]);
                    string[] parts = words[1].Split(' ');
                    int teacherId = int.Parse(parts[parts.Length - 1]);
                    var teacher = persons.SingleOrDefault(p => p.Id == teacherId) as Teacher;
                    if (teacher == null)
                    {
                        throw new Exception("Teacher not found");
                    }
                    student.Teacher = teacher;
                    teacher.Students.Add(student);
                    person = student;
                }
                else if (words[0] == "teacher")
                {
                    person = new Teacher();
                    person.Input(words[1]);
                }
                else
                {
                    throw new Exception("invalid data");
                }

                persons.Add(person);
            }

            return persons;
        }

        public int CountStudents(List<Person> persons)
        {
            int studentsCounter;
            studentsCounter = persons.Where(p => p.GetType() == typeof(Student)).Count();

            return studentsCounter;
        }

        public int CountTeachers(List<Person> persons)
        {
            int teachersCounter;
            teachersCounter = persons.Where(p => p.GetType() == typeof(Teacher)).Count();

            return teachersCounter;
        }

        public void DoTasks()
        {
            string fileName = "persons.txt";
            List<string> data = ReadFromFile(fileName);
            List<Person> persons = ParseLines(data);
            int amountOfSudents = CountStudents(persons);
            int amountOfTeachers = CountTeachers(persons);
        }
    }
}