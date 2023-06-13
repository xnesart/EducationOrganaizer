namespace EducationOrganaizer.Classes
{
    public class Project:AbstractTask
    {
        public Project(string name, string description, string links, string deadline, string subTasks)
        {
            Name = name;
            Description = description;
            LinksToAdditionalMaterials = links;
            Deadline = deadline;
            SubTasks = subTasks;
            Type = "проект";
        }
    }
}