using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using EducationOrganaizer.Classes;
using Group = EducationOrganaizer.Classes.Group;

namespace EducationOrganaizer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, выберите интересующую вас опцию");
            Classes.EducationOrganaizer educationOrganaizer = new Classes.EducationOrganaizer();
            Console.WriteLine("Нажмите 1, чтобы посмотреть список групп");
            Console.WriteLine("Нажмите 2, чтобы посмотреть список занятий");
            Console.WriteLine("Нажмите 3, чтобы посмотреть список заданий");
            Console.WriteLine("Нажмите 4, чтобы войти в режим редактирования");
            Console.WriteLine("Нажмите 'x', чтобы выйти");
            var choice = Console.ReadLine();
            while (true)
            {
                switch (choice)
                {
                    case "1":
                        educationOrganaizer.DisplayGroups();
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Выберите тип задания");
                        Console.WriteLine("1 Обычное задание");
                        Console.WriteLine("2 Проект");
                        Console.WriteLine("3 Тестирование");
                        Console.WriteLine("4 Вернуться назад");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Список обычных заданий:");
                                educationOrganaizer.DisplayRegularTasks();
                                break;
                            case "2":
                                Console.WriteLine("Список проектов");
                                educationOrganaizer.DisplayProjects();
                                break;
                            case "3":
                                Console.WriteLine("Список тестирований");
                                educationOrganaizer.DisplayTestings();
                                break;
                            case "4":
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Нажмите 1  чтобы создать группу");
                        Console.WriteLine("Нажмите 2, чтобы редактировать список занятий");
                        Console.WriteLine("Нажмите 3, чтобы редактировать список заданий");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Введите название группы");
                                string groupName = Console.ReadLine();
                                Group newGroup = new Group(groupName);
                                educationOrganaizer.AddGroupInListOfGroup(newGroup);
                                Console.WriteLine("Нажмите 1, чтобы добавить студента в группу");
                                Console.WriteLine("Нажмите 2, чтобы удалить студента из группы");
                                Console.WriteLine("Нажмите 3, чтобы вернуться");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        Console.WriteLine("Введите полное имя");
                                        string fullName = Console.ReadLine();
                                        Console.WriteLine("Введите телефон");
                                        string phone = Console.ReadLine();
                                        Console.WriteLine("Введите почту");
                                        string mail = Console.ReadLine();
                                        Student student = new Student(fullName, phone, mail);
                                        newGroup.AddStudent(student);
                                        Console.WriteLine("Студент добавлен");

                                        StreamWriter writer = new StreamWriter("group.txt");
                                        foreach (var item in newGroup.ListOfStudents)
                                        {
                                            writer.WriteLine(item);
                                        }

                                        break;
                                    case "2":
                                        Console.WriteLine("Введите полное имя");
                                        string fullNameofStudent = Console.ReadLine();
                                        bool check = newGroup.RemoveStudent(fullNameofStudent);
                                        if (check == true)
                                        {
                                            Console.WriteLine("студент удалён");
                                        }
                                        else
                                        {
                                            Console.WriteLine("студента удалить не удалось");
                                        }

                                        break;
                                    case "3":
                                        break;
                                }

                                break;
                            case "2":
                                break;
                            case "3":
                                Console.WriteLine("Выберите тип задания");
                                Console.WriteLine("1 Обычное задание");
                                Console.WriteLine("2 Проект");
                                Console.WriteLine("3 Тестирование");
                                Console.WriteLine("4 Вернуться назад");
                                choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        Console.WriteLine("1 чтобы добавить обычное задание");
                                        Console.WriteLine("2 чтобы удалить обычное задание");
                                        Console.WriteLine("3 чтобы вернуться");
                                        choice = Console.ReadLine();
                                        switch (choice)
                                        {
                                            case "1":
                                                Console.WriteLine("Введите название задания");
                                                string name = Console.ReadLine();
                                                Console.WriteLine("Введите описание");
                                                string description = Console.ReadLine();
                                                Console.WriteLine("Введите ссылки на доп материалы");
                                                string links = Console.ReadLine();
                                                Console.WriteLine("Введите дедлайн");
                                                string deadline = Console.ReadLine();
                                                RegularTask task = new RegularTask(name, description, links, deadline);

                                                educationOrganaizer.AddRegularTask(task);
                                                break;
                                            case "2":
                                                Console.WriteLine("Введите название задания");
                                                string taskName = Console.ReadLine();
                                                educationOrganaizer.RemoveRegularTask(taskName);
                                                break;
                                            case "3":
                                                break;
                                        }

                                        break;
                                    case "2":
                                        Console.WriteLine("1 чтобы добавить проект");
                                        Console.WriteLine("2 чтобы удалить проект");
                                        Console.WriteLine("3 чтобы вернуться");
                                        choice = Console.ReadLine();
                                        switch (choice)
                                        {
                                            case "1":
                                                Console.WriteLine("Введите название проекта");
                                                string name = Console.ReadLine();
                                                Console.WriteLine("Введите описание");
                                                string description = Console.ReadLine();
                                                Console.WriteLine("Введите ссылки на доп материалы");
                                                string links = Console.ReadLine();
                                                Console.WriteLine("Введите дедлайн");
                                                string deadline = Console.ReadLine();
                                                Console.WriteLine("Введите подзадачи");
                                                string subtasks = Console.ReadLine();

                                                Project project = new Project(name,description,links,deadline,subtasks);
                                                educationOrganaizer.AddProject(project);
                                                break;
                                            case "2":
                                                Console.WriteLine("Введите название проекта");
                                                string nameOfProject = Console.ReadLine();

                                                educationOrganaizer.RemoveProject(nameOfProject);
                                                break;
                                            case "3":
                                                break;
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine("1 чтобы добавить тестирование");
                                        Console.WriteLine("2 чтобы удалить тестирование");
                                        Console.WriteLine("3 чтобы вернуться");
                                        choice = Console.ReadLine();
                                        switch (choice)
                                        {
                                            case "1":
                                                Console.WriteLine("Введите название тестирования");
                                                string name = Console.ReadLine();
                                                Console.WriteLine("Введите ссылки на задания");
                                                string links = Console.ReadLine();
                                                Console.WriteLine("Введите дедлайн");
                                                string deadline = Console.ReadLine();
                                                
                                                Testing testing = new Testing(name, links, deadline);
                                                educationOrganaizer.AddTesting(testing);
                                                break;
                                            case "2":
                                                Console.WriteLine("Введите название тестирования для удаления");
                                                
                                                string nameOfTesting = Console.ReadLine();
                                                educationOrganaizer.RemoveTesting(nameOfTesting);
                                                break;
                                            case "3":
                                                break;
                                        }
                                        break;
                                    case "4":
                                        break;
                                }

                                break;
                        }

                        break;
                    case "x":
                        return;
                }

                Console.WriteLine("Выберите действие");
                choice = Console.ReadLine();
            }


            //функционал добавления группы

            //добавляем в группу студентов
        }
    }
}