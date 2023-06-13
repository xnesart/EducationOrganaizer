using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class Student
    {
        public string Name { get; protected set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        private List<AbstractTask> ListOfAcceptedTasks { get; set; } = new List<AbstractTask>();
        

        public Student(string name, string phone, string mail)
        {
            Name = name;
            Phone = phone;
            Mail = mail;
        }
        
    }
}