using System;

namespace EducationOrganaizer.Classes
{
    public class RegularTask : AbstractTask
    {
        public RegularTask(string name, string description, string links, string deadline)
        {
            Name = name;
            Description = description;
            LinksToAdditionalMaterials = links;
            Deadline = deadline;
        }

        
    }
}