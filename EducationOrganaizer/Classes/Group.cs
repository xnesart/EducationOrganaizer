using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class Group
    {
        public string Name { get; set; }
        public List<Student> ListOfStudents { get; set; }
        public List<Lesson> ListOfLessons{ get; set; }
        public List<AbstractTask> ListOfTasks { get; set; }

        public Group(string name)
        {
            Name = name;
            ListOfStudents = new List<Student>();
            ListOfLessons = new List<Lesson>();
            ListOfTasks = new List<AbstractTask>();
        }

        public void CreateStudent()
        {
            
        }
        public void AddStudent(Student student)
        {
            ListOfStudents.Add(student);
        }

        public bool RemoveStudent(string fullName)
        {
            Student studentToRemove = ListOfStudents.Find(s => s.Name == fullName);
            if (studentToRemove != null)
            {
                ListOfStudents.Remove(studentToRemove);
                return true;
            }
            return false;
        }


    }
}