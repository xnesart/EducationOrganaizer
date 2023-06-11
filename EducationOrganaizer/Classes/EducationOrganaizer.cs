using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

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

        //работа с сохраненными файлами
        public void ShowAllJson()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            if (Directory.Exists(folderPath))
            {
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");
                foreach (var jsonFile in jsonFiles)
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(jsonFile));
                }
            }
        }
        public Group ReadGroupFromBdOrCreateNewGroup(string groupName)
        {
            if (File.Exists($"{groupName}.json"))
            {
                string json = File.ReadAllText($"{groupName}.json");
                Group groupForReturn = JsonConvert.DeserializeObject<Group>(json);
                return groupForReturn;
            }

            return new Group(groupName);
        }

        public Group ReadGroupFromBd(string groupName)
        {
            if (File.Exists($"{groupName}.json"))
            {
                string json = File.ReadAllText($"{groupName}.json");
                Group groupForReturn = JsonConvert.DeserializeObject<Group>(json);
                return groupForReturn;
            }

            return null;
        }

        public void SaveToDb(Group newGroup)
        {
            string json = JsonConvert.SerializeObject(newGroup, Formatting.Indented);
            File.WriteAllText($"{newGroup.Name}.json", json);
        }

        public bool RemoveToDb(string groupName)
        {
            string fileName = groupName + ".json";
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            bool isDelete = false;
            if (Directory.Exists(folderPath))
            {
                string filePath = Path.Combine(folderPath, fileName);

                if (File.Exists(filePath) && Path.GetExtension(filePath).Equals(".json", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        File.Delete(filePath);
                        Console.WriteLine($"группа '{groupName}' удалена.");
                        isDelete = true;
                        return isDelete;
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Возникла ошибка при удалении файла: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Файл группы не найден, ошибка");
                }
            }
            else
            {
                Console.WriteLine("Путь к файлам групп не найден, ошибка");
            }

            return isDelete;
        }
    }
}