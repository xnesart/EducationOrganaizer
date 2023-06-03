using System;
using System.IO;
using System.Linq;
using EducationOrganaizer.Classes;


namespace EducationOrganaizer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Classes.EducationOrganaizer educationOrganaizer = new Classes.EducationOrganaizer();
            Console.WriteLine("Здравствуйте, выберите интересующую вас опцию");
            Console.WriteLine("Нажмите 1, чтобы создать или отредактировать группы");
            Console.WriteLine("Нажмите 2, чтобы посмотреть список групп");
            Console.WriteLine("Нажмите 'x', чтобы выйти");
            var choice = Console.ReadLine();

            while (true)
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите название группы");
                        string groupName = Console.ReadLine();
                        Group newGroup = new Group(groupName);
                        educationOrganaizer.AddGroupInListOfGroup(newGroup);

                        while (true)
                        {
                            Console.WriteLine("Нажмите 1, чтобы редактировать список студентов");
                            Console.WriteLine("Нажмите 2, чтобы редактировать список заданий");
                            Console.WriteLine("Нажмите 3, чтобы редактировать список занятий");
                            Console.WriteLine("Нажмите 4, чтобы вернуться назад");
                            choice = Console.ReadLine();
                            while (true)
                            {
                                switch (choice)
                                {
                                    case "1":
                                        Console.WriteLine("1, чтобы добавить студента в группу");
                                        Console.WriteLine("2, чтобы удалить студента из группы");
                                        while (true)
                                        {
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

                                                    // StreamWriter writer = new StreamWriter("group.txt");
                                                    // foreach (var item in newGroup.ListOfStudents)
                                                    // {
                                                    //     writer.WriteLine(item);
                                                    // }

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
                                        }

                                        break;
                                    case "2":
                                        Console.WriteLine("Выберите тип задания");
                                        Console.WriteLine("1, Обычное задание");
                                        Console.WriteLine("2, Тестирование");
                                        Console.WriteLine("3, Проект");
                                        Console.WriteLine("4, чтобы вернуться");
                                 

                                        while (true)
                                        {
                                            choice = Console.ReadLine();
                                            switch (choice)
                                            {
                                                case "1":
                                                    Console.WriteLine("1, для добавления задания");
                                                    Console.WriteLine("2, для удаления задания");
                                                    Console.WriteLine("3, чтобы вернуться");

                                                    while (true)
                                                    {
                                                        choice = Console.ReadLine();
                                                        switch (choice)
                                                        {
                                                            case "1":
                                                                Console.WriteLine("Введите название задания");
                                                                string taskName = Console.ReadLine();
                                                                Console.WriteLine("Введите описание");
                                                                string description = Console.ReadLine();
                                                                Console.WriteLine("Введите дополнительные ссылки");
                                                                string links = Console.ReadLine();
                                                                Console.WriteLine("Введите дату сдачи задания");
                                                                string deadline = Console.ReadLine();
                                                                RegularTask regularTask = new RegularTask(taskName,
                                                                    description, links, deadline);

                                                                newGroup.AddRegularTask(regularTask);
                                                                Console.WriteLine("Задание добавлено");
                                                                break;
                                                            case "2":
                                                                Console.WriteLine("Введите название задания или нажмите 'r', чтобы вернуться ");
                                                                string taskNameForDelete = Console.ReadLine();
                                                                if (taskNameForDelete == "r")
                                                                {
                                                                    break;
                                                                }
                                                                bool isDelete =
                                                                    newGroup.RemoveRegularTask(taskNameForDelete);
                                                                if (isDelete == false)
                                                                {
                                                                    Console.WriteLine("Задание удалить не удалось");
                                                                }

                                                                break;
                                                            case "3":
                                                                break;
                                                        }

                                                        break;
                                                    }

                                                    break;
                                                case "2":
                                                    Console.WriteLine("1, для добавления тестирования");
                                                    Console.WriteLine("2, для удаления тестирования");
                                                    while (true)
                                                    {
                                                        choice = Console.ReadLine();
                                                        switch (choice)
                                                        {
                                                            case "1":
                                                                Console.WriteLine("Введите название тестирования или нажмите 'r', чтобы вернуться");
                                                                string testingName = Console.ReadLine();
                                                                if (testingName == "r")
                                                                {
                                                                    break;
                                                                }
                                                                Console.WriteLine("Введите ссылку на тестирование");
                                                                string links = Console.ReadLine();
                                                                Console.WriteLine("Введите дату сдачи тестирования");
                                                                string deadline = Console.ReadLine();
                                                                Testing testing = new Testing(testingName, links,
                                                                    deadline);
                                                                newGroup.AddTesting(testing);
                                                                break;
                                                            case "2":
                                                                Console.WriteLine("Введите название тестирования или нажмите 'r', чтобы вернуться ");
                                                                string testingNameForDelete = Console.ReadLine();
                                                                if (testingNameForDelete == "r")
                                                                {
                                                                    break;
                                                                }
                                                                bool isDelete =
                                                                    newGroup.RemoveTesting(testingNameForDelete);
                                                                if (isDelete == false)
                                                                {
                                                                    Console.WriteLine(
                                                                        "Тестирование удалить не удалось");
                                                                }

                                                                break;
                                                        }

                                                        break;
                                                    }

                                                    break;
                                                case "3":
                                                    Console.WriteLine("1, для добавления проекта");
                                                    Console.WriteLine("2, для удаления проекта");
                                                    Console.WriteLine("3, назад");

                                                    while (true)
                                                    {
                                                        choice = Console.ReadLine();
                                                        switch (choice)
                                                        {
                                                            case "1":
                                                                Console.WriteLine("Введите название проекта или нажмите 'r', чтобы вернуться");
                                                                string projectName = Console.ReadLine();
                                                                if (projectName == "r")
                                                                {
                                                                    break;
                                                                }
                                                                Console.WriteLine("Введите описание проекта");
                                                                string description = Console.ReadLine();
                                                                Console.WriteLine("Введите дополнительные ссылки");
                                                                string links = Console.ReadLine();
                                                                Console.WriteLine("Введите подзадачи");
                                                                string subtasks = Console.ReadLine();
                                                                Console.WriteLine("Введите дату сдачи задания");
                                                                string deadline = Console.ReadLine();
                                                                Project project = new Project(projectName, description,
                                                                    links, deadline, subtasks);

                                                                newGroup.AddProject(project);
                                                                break;
                                                            case "2":
                                                                Console.WriteLine("Введите название проекта или нажмите 'r' чтобы вернуться");
                                                                string projectNameForDelete = Console.ReadLine();
                                                                if (projectNameForDelete == "r")
                                                                {
                                                                    break;
                                                                }
                                                                bool isDelete =
                                                                    newGroup.RemoveProject(projectNameForDelete);
                                                                if (isDelete == false)
                                                                {
                                                                    Console.WriteLine("Проект удалить не удалось");
                                                                }

                                                                break;
                                                            case "3":
                                                                return;
                                                        }
                                                    }

                                                    break;
                                                case "4":
                                                    break;
                                            }

                                            // Console.WriteLine("Выберите тип задания");
                                            // Console.WriteLine("1, Обычное задание");
                                            // Console.WriteLine("2, Тестирование");
                                            // Console.WriteLine("3, Проект");
                                            // Console.WriteLine("4, чтобы вернуться");
                                            break;
                                        }

                                        break;
                                }


                                break;
                            }
                        }

                        break;

                        break;
                    case "2":
                        educationOrganaizer.DisplayGroups();
                        Console.WriteLine("Введите название группы для просмотра");
                        string userAnswer = Console.ReadLine();
                        while (true)
                        {
                            Group group = educationOrganaizer.SearchGroup(userAnswer);
                            if (group == null)
                            {
                                Console.WriteLine("Группа не найдена");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"{group.Name} - найдена");
                                Console.WriteLine("1, чтобы посмотреть список обычных заданий");
                                Console.WriteLine("2, чтобы посмотреть список тестирований");
                                Console.WriteLine("3, чтобы посмотреть список проектов");
                                Console.WriteLine("4, чтобы посмотреть список студентов");
                                userAnswer = Console.ReadLine();
                                switch (userAnswer)
                                {
                                    case "1":
                                        group.DisplayRegularTasks();
                                        break;
                                    case "2":
                                        group.DisplayTestings();
                                        break;
                                    case "3":
                                        group.DisplayProjects();
                                        break;
                                    case "4":
                                        group.DisplayStudents();
                                        break;
                                }
                            }
                        }

                        break;

                    case "x":
                        return;
                }


                //функционал добавления группы

                //добавляем в группу студентов
            }
        }
    }
}