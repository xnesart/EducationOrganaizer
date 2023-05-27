using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class Tasks
    {
        public List<RegularTask> ListOfRegularTasks = new List<RegularTask>();
        public List<Project> ListOfProjects = new List<Project>();
        public List<Testing> ListOfTesting = new List<Testing>();
        

        public void AddRegularTask(RegularTask regularTask)
        {
            tasks.ListOfRegularTasks.Add(regularTask);
        }
        public bool RemoveRegularTask(RegularTask regularTask)
        {
            if (Tasks.ListOfRegularTasks.Contains(regularTask))
            {
                Tasks.ListOfRegularTasks.Remove(regularTask);
                Console.WriteLine("Задание удалено");
                return true;
            }
            else
            {
                Console.WriteLine("Задание не найдено");
                return false;
            }
        }
    }
    
}