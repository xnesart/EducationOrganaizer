using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationOrganaizer.Classes
{
    public class EducationOrganaizer
    {
        public List<Group> ListOfGroups = new List<Group>();
        public void DisplayGroups()
        {
            foreach (var group in ListOfGroups)
            {
                Console.WriteLine($"{group.Name}");
            }
        }
        public void AddGroupInListOfGroup(Group group)
        {
            ListOfGroups.Add(group);
            Console.WriteLine("группа создана");
        }

        public Group SearchGroup(string name)
        {
            foreach (var group in ListOfGroups)
            {
                if (group.Name.Contains(name))
                {
                    return group;
                }
            }

            return null;
        }
        public bool RemoveGroup(string name)
        {
            bool isDelete = false;
            foreach (var group in ListOfGroups)
            {
                if (group.Name.Contains(name))
                {
                    ListOfGroups.Remove(group);
                    Console.WriteLine("Группа удалена");
                    isDelete = true;
                    return isDelete;
                }
            }

            return isDelete;
        }
        
    }
    
}