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
            Tasks tasks = new Tasks();
            Console.WriteLine("Нажмите 1, чтобы посмотреть список групп");
            Console.WriteLine("Нажмите 2, чтобы посмотреть список занятий");
            Console.WriteLine("Нажмите 3, чтобы войти в режим редактирования");
            Console.WriteLine("Нажмите 'x', чтобы выйти");
            var choice = Console.ReadLine();
            while (true)
            {
                switch (choice)
                {
                    case "1":
                        foreach (var group in Groups.ListOfGroups)
                        {
                            Console.WriteLine($"group");
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Нажмите 1  чтобы создать группу");
                        Console.WriteLine("Нажмите 2, чтобы добавить занятия в список занятий");
                        Console.WriteLine("Нажмите 3, чтобы добавить задания в список заданий");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Group newGroup = new Group();
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
                                        string fullName2 = Console.ReadLine();
                                        bool check = newGroup.RemoveStudent(fullName2);
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
                                                RegularTask task = new RegularTask(name,description,links,deadline);
                                                
                                                
                                                break;
                                            case "2":
                                                break;
                                            case "3":
                                                break;
                                        }
                                        break;
                                    case "2":
                                        break;
                                    case "3":
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