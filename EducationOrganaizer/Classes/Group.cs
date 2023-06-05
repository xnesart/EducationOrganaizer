using System;
using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class Group
    {
        public string Name { get; set; }
        private List<Student> ListOfStudents { get; set; }
        public List<Lesson> ListOfLessons { get; set; }
        public List<AbstractTask> ListOfTasks { get; set; }

        private List<Lesson> ListOfSeminars { get; set; } = new List<Lesson>();
        private List<Lesson> ListOfLectures { get; set; } = new List<Lesson>();
        private List<Lesson> ListOfAnotherLessons { get; set; } = new List<Lesson>();
        private List<RegularTask> ListOfRegularTasks = new List<RegularTask>();
        private List<Project> ListOfProjects = new List<Project>();
        private List<Testing> ListOfTesting = new List<Testing>();

        public Group(string name)
        {
            Name = name;
            ListOfStudents = new List<Student>();
            ListOfLessons = new List<Lesson>();
            ListOfTasks = new List<AbstractTask>();
        }


        public void AddRegularTask(RegularTask regularTask)
        {
            ListOfRegularTasks.Add(regularTask);
        }

        public bool RemoveRegularTask(string name)
        {
            bool isDelete = false;
            foreach (var regularTask in ListOfRegularTasks)
            {
                if (regularTask.Name.Contains(name))
                {
                    ListOfRegularTasks.Remove(regularTask);
                    Console.WriteLine("Задание удалено");
                    isDelete = true;
                    return isDelete;
                }
            }

            return isDelete;
        }

        public void DisplayStudents()
        {
            foreach (var student in ListOfStudents)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Phone);
                Console.WriteLine(student.Mail);
                Console.WriteLine("/------------------/");
            }
        }

        public void DisplayRegularTasks()
        {
            foreach (var regTask in ListOfRegularTasks)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(regTask.Name);
                Console.WriteLine(regTask.Description);
                Console.WriteLine(regTask.Deadline);
                Console.WriteLine("/------------------/");
            }
        }

        public void DisplayProjects()
        {
            foreach (var project in ListOfProjects)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(project.Name);
                Console.WriteLine(project.Description);
                Console.WriteLine(project.SubTasks);
                Console.WriteLine(project.Deadline);
                Console.WriteLine("/------------------/");
            }
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


        public void AddProject(Project project)
        {
            ListOfProjects.Add(project);
        }

        public bool RemoveProject(string name)
        {
            bool isDelete = false;
            foreach (var project in ListOfProjects)
            {
                if (project.Name.Contains(name))
                {
                    ListOfProjects.Remove(project);
                    Console.WriteLine("Проект удален");
                    isDelete = true;
                    return isDelete;
                }
            }

            return isDelete;
        }

        public void AddTesting(Testing testing)
        {
            ListOfTesting.Add(testing);
        }

        public bool RemoveTesting(string name)
        {
            bool isDelete = false;
            foreach (var testing in ListOfTesting)
            {
                if (testing.Name.Contains(name))
                {
                    ListOfTesting.Remove(testing);
                    Console.WriteLine("Тестирование удалено");
                    isDelete = true;
                    return isDelete;
                }
            }

            return isDelete;
        }

        public void DisplayTestings()
        {
            foreach (var testings in ListOfTesting)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(testings.Name);
                Console.WriteLine(testings.LinkToTesting);
                Console.WriteLine(testings.Deadline);
                Console.WriteLine("/------------------/");
            }
        }

        public void DisplaySeminarsInGroup()
        {
            foreach (var seminar in ListOfSeminars)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(seminar.ListOfTopics);
                Console.WriteLine(seminar.Date);
                Console.WriteLine(seminar.CommentFromTeacher);
                Console.WriteLine("/------------------/");
            }
        }

        public void AddSeminarToListOFSeminars(Lesson lesson)
        {
            ListOfSeminars.Add(lesson);
            Console.WriteLine("семинар добавлен");
        }

        public bool RemoveSeminarFromListOfSeminars(string topic, string date)
        {
            bool isDelete = false;
            foreach (var lesson in ListOfSeminars)
            {
                if (lesson.ListOfTopics.Contains(topic))
                {
                    if (lesson.Date == date)
                    {
                        ListOfSeminars.Remove(lesson);
                        Console.WriteLine("семинар удалён");
                        isDelete = true;
                        return isDelete;
                    }
                }
                else
                {
                    Console.WriteLine("семинар не найден");
                }
            }

            return isDelete;
        }

        public void DisplayLecturesInGroup()
        {
            foreach (var lecture in ListOfLectures)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(lecture.ListOfTopics);
                Console.WriteLine(lecture.Date);
                Console.WriteLine(lecture.CommentFromTeacher);
                Console.WriteLine("/------------------/");
            }
        }

        public void AddLectureToListOFLectures(Lesson lesson)
        {
            ListOfLectures.Add(lesson);
            Console.WriteLine("Лекция добавлена");
        }

        public bool RemoveLectureFromListOfListOfLectures(string topic, string date)
        {
            bool isDelete = false;
            foreach (var lecture in ListOfLectures)
            {
                if (lecture.ListOfTopics.Contains(topic))
                {
                    if (lecture.Date == date)
                    {
                        ListOfLectures.Remove(lecture);
                        Console.WriteLine("лекция удалена");
                        isDelete = true;
                        return isDelete;
                    }
                }
                else
                {
                    Console.WriteLine("лекция не найдена");
                }
            }

            return isDelete;
        }

        public void DisplayListOfAnotherLessonsInGroup()
        {
            foreach (var anotherLesson in ListOfAnotherLessons)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(anotherLesson.ListOfTopics);
                Console.WriteLine(anotherLesson.Date);
                Console.WriteLine(anotherLesson.CommentFromTeacher);
                Console.WriteLine("/------------------/");
            }
        }

        public void AddAnotherLessonToListOfAnotherLessons(Lesson lesson)
        {
            ListOfAnotherLessons.Add(lesson);
            Console.WriteLine("Другой тип занятия добавлен");
        }

        public bool RemoveAnotherLessonFromListOfAnotherLessons(string topic, string date)
        {
            bool isDelete = false;
            foreach (var anotherLesson in ListOfAnotherLessons)
            {
                if (anotherLesson.ListOfTopics.Contains(topic))
                {
                    if (anotherLesson.Date == date)
                    {
                        ListOfLectures.Remove(anotherLesson);
                        Console.WriteLine("занятие удалено");
                        isDelete = true;
                        return isDelete;
                    }
                }
                else
                {
                    Console.WriteLine("занятие не найдено");
                }
            }

            return isDelete;
        }
    }
}