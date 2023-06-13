using System;
using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class Student
    {
        public string Name { get; protected set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public List<AbstractTask> ListOfAcceptedTasks { get; set; } = new List<AbstractTask>();
        

        public Student(string name, string phone, string mail)
        {
            Name = name;
            Phone = phone;
            Mail = mail;
        }

        public void DisplayAcceptedTasks()
        {
            foreach (var task in ListOfAcceptedTasks)
            {
                Console.WriteLine("/------------------/");
                Console.WriteLine(task.Name);
                Console.WriteLine(task.Type);
                Console.WriteLine("/------------------/");
            }
        }

        public void AddTaskToListOfAcceptedTasks(string taskName)
        {
            //здесь создается обычное задание чтобы добавить в список принятых заданий, на самом деле
            //оно может быть и проектом и тестированием, мне нужно только название задания,
            //так как сравнение будет только по названию
            string description = "";
            string links = "";
            string deadline = "";
            
            RegularTask regularTask = new RegularTask(taskName, description,links,deadline);
            ListOfAcceptedTasks.Add(regularTask);
            Console.WriteLine("Задание добавлено");
        }

        public bool RemoveTaskToListOfAcceptedTasks(string taskName)
        {
            foreach (var task in ListOfAcceptedTasks)
            {
                if (task.Name == taskName)
                {
                    ListOfAcceptedTasks.Remove(task);
                    Console.WriteLine("Задание удалено из списка");
                    return true;
                }
            }
            Console.WriteLine("Удалить задание не удалось");
            return false;
        }
        
    }
}