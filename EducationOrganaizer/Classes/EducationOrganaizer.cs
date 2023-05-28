using System;
using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class EducationOrganaizer
    {
        public List<Group> ListOfGroups = new List<Group>();
        public List<RegularTask> ListOfRegularTasks = new List<RegularTask>();
        public List<Project> ListOfProjects = new List<Project>();
        public List<Testing> ListOfTesting = new List<Testing>();

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

        public void AddGroupInListOfGroup(Group group)
        {
            ListOfGroups.Add(group);
            Console.WriteLine("группа создана");
        }
        public void DisplayGroups()
        {
            foreach (var group in ListOfGroups)
            {
                Console.WriteLine($"{group.Name}");
            }
        }
    }
}