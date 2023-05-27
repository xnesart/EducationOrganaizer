namespace EducationOrganaizer.Classes
{
    public class Student
    {
        public string Name { get; protected set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Student(string name, string phone, string mail)
        {
            Name = name;
            Phone = phone;
            Mail = mail;
        }
        
    }
}