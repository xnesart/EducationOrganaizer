namespace EducationOrganaizer.Classes
{
    public class Testing
    {
        public string Name { get; set; }
        public string LinkToTesting { get; set; }
        public string Deadline { get; set; }

        public Testing(string name, string linkToTesting, string deadline)
        {
            Name = name;
            LinkToTesting = linkToTesting;
            Deadline = deadline;
        }
    }
}