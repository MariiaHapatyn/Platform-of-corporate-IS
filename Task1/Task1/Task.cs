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
        /// <summary>
        /// Parse files to list of strings
        /// </summary>
        /// <param name="filename">file with information</param>
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

        /// <summary>
        /// Parse list of strings to list of objects
        /// </summary>
        /// <param name="lines">list of strings with properties for objects</param>
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
                    student.Teacher = teacher ?? throw new Exception("Teacher not found");
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

        /// <summary>
        /// Count students in collection
        /// </summary>
        /// <param name="persons">list of persons</param>
        public int CountStudents(List<Person> persons)
        {
            int studentsCounter;
            studentsCounter = persons.Where(p => p.GetType() == typeof(Student)).Count();

            return studentsCounter;
        }

        /// <summary>
        /// Count teachers in collection
        /// </summary>
        /// <param name="persons">list of persons</param>
        public int CountTeachers(List<Person> persons)
        {
            int teachersCounter;
            teachersCounter = persons.Where(p => p.GetType() == typeof(Teacher)).Count();

            return teachersCounter;
        }

        /// <summary>
        /// Demonstrate who equals method works
        /// </summary>
        /// <param name="persons">list of persons</param>
        /// <remarks>
        /// Crate collection wich contains only unique elements
        /// </remarks>
        public void DemonstrateEqualsWork(List<Person> persons)
        {
            // Distinct implicitly uses Equals()
            IEnumerable<Person> distinctPersons = persons.Distinct();
            for (int i = 0; i < distinctPersons.Count() - 1; i++)
            {
                if (distinctPersons.ElementAt(i).Equals(distinctPersons.ElementAt(i + 1)))
                {
                    throw new Exception("equals methods does not work properly");
                }
            }
        }



        public List<Person> CloneList(List<Person> persons)
        {
            Person[] clonedAll = new Person[persons.Count()];
            clonedAll = (Person[])persons.ToArray().Clone();

            return clonedAll.ToList();
        }

        public void Print(List<Person> persons, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Persons:");
                foreach (var person in persons)
                {
                    sw.WriteLine(person.ToString());
                }
            }
        }

        /// <summary>
        /// Exectutes all functions for the whole task
        /// </summary>
        public void DoTasks()
        {
            string inputfileName = "persons.txt";
            List<string> data;
            try
            {
                data = ReadFromFile(inputfileName);
            }
            catch (FileNotFoundException fileMissingException)
            {
                Console.WriteLine($"File missing! {fileMissingException.Message}");
                throw;
            }
            catch (FileLoadException fileIsEmptyException)
            {
                Console.WriteLine($"Something go wrong with file! {fileIsEmptyException.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            List<Person> persons = ParseLines(data);

            int amountOfSudents = CountStudents(persons);
            int amountOfTeachers = CountTeachers(persons);
            DemonstrateEqualsWork(persons);
            Console.WriteLine($"Amount of students: { amountOfSudents}");
            Console.WriteLine($"Amount of teachers: { amountOfTeachers}");

            string outputFileName = "cloned.txt";
            List<Person> cloned = CloneList(persons);
            Print(cloned, outputFileName);            
        }
    }
}