namespace EducationOrganaizer.Classes
{
    public abstract class AbstractTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinksToAdditionalMaterials { get; set; }
        public string LinkToTesting { get; set; }
        public string Deadline { get; set; }
        public string SubTasks { get; set; }
        public string Type { get; set; }
        
    }
}