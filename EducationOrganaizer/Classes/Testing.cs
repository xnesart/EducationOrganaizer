namespace EducationOrganaizer.Classes
{
    public class Testing:AbstractTask
    {
        public Testing(string name, string linkToTesting, string deadline)
        {
            Name = name;
            LinkToTesting = linkToTesting;
            Deadline = deadline;
            Type = "тестирование";
        }
    }
}