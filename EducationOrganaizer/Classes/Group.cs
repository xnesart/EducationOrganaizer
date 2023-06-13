using System;
using System.Collections.Generic;


namespace EducationOrganaizer.Classes
{
  public class Group
  {
    public string Name { get; set; }
    public List<Student> ListOfStudents { get; set; }
    public List<Lesson> ListOfLessons { get; set; }

    public List<AbstractTask> ListOfTasks { get; set; }

    //Списки занятий
    public List<Lesson> ListOfSeminars { get; set; } = new List<Lesson>();
    public List<Lesson> ListOfLectures { get; set; } = new List<Lesson>();

    public List<Lesson> ListOfAnotherLessons { get; set; } = new List<Lesson>();

    //Списки заданий
    public List<RegularTask> ListOfRegularTasks = new List<RegularTask>();
    public List<Project> ListOfProjects = new List<Project>();
    public List<Testing> ListOfTesting = new List<Testing>();
    public List<AbstractTask> ListOfAllTasks { get; set; } = new List<AbstractTask>();

    public Group(string name)
    {
      Name = name;
      ListOfStudents = new List<Student>();
      ListOfLessons = new List<Lesson>();
      ListOfTasks = new List<AbstractTask>();
    }

    public void DisplayAllTasks()
    {
      if (ListOfAllTasks.Count != null)
      {
        foreach (var task in ListOfAllTasks)
        {
          Console.WriteLine("/------------------/");
          Console.WriteLine(task.Name);
          Console.WriteLine(task.Type);
          Console.WriteLine(task.Description);
          Console.WriteLine(task.Deadline);
          Console.WriteLine("/------------------/");
        }
      }
    }
    //выводит статус проекта у всех студентов
    public void DisplayProjectStatusOfAllStudents(Project project)
    {
      if(project == null) return;
      bool matching = false;
      string taskName = "";
      foreach (var student in ListOfStudents)
      {
        foreach (var task in student.ListOfAcceptedTasks)
        {
          if (project.Name == task.Name)
          {
            matching = true;
            taskName = task.Name;
            break;
          }
        }

        if (matching == true)
        {
          Console.WriteLine($"у {student.Name} зачтен(о) {taskName}");
        }
        else
        {
          Console.WriteLine($"у {student.Name} задолженность {project.Name}");
        }

        matching = false;
      }
    }
    //выводит статус обычного задания у всех студентов
    public void DisplayRegularTaskStatusOfAllStudents(RegularTask regularTask)
    {
      if (regularTask == null)
      {
        return;
      }
      bool matching = false;
      string taskName = "";
      foreach (var student in ListOfStudents)
      {
        foreach (var task in student.ListOfAcceptedTasks)
        {
          if (regularTask.Name == task.Name)
          {
            matching = true;
            taskName = task.Name;
            break;
          }
        }

        if (matching == true)
        {
          Console.WriteLine($"у {student.Name} зачтен(о) {taskName}");
        }
        else
        {
          Console.WriteLine($"у {student.Name} задолженность {regularTask.Name}");
        }

        matching = false;
      }
    }
    //выводит статус тестирования у всех студентов
    public void DisplayTestingStatusOfAllStudents(Testing testing)
    {
      if(testing == null) return;
      bool matching = false;
      string taskName = "";
      foreach (var student in ListOfStudents)
      {
        foreach (var task in student.ListOfAcceptedTasks)
        {
          if (testing.Name == task.Name)
          {
            matching = true;
            taskName = task.Name;
            break;
          }
        }

        if (matching == true)
        {
          Console.WriteLine($"у {student.Name} зачтен(о) {taskName}");
        }
        else
        {
          Console.WriteLine($"у {student.Name} задолженность {testing.Name}");
        }

        matching = false;
      }
    }
    public void DisplayTaskStatusOfStudent(Student student)
    {
      if (student.ListOfAcceptedTasks.Count == 0)
      {
        Console.WriteLine("у студента нет принятых заданий");
      }
      else if (student.ListOfAcceptedTasks.Count == ListOfAllTasks.Count)
      {
        Console.WriteLine("у студента нет задолженностей");
      }
      else
      {
        CompareTasks(student);
      }
    }

    //сравнивает принятые задания с общим списком заданий у конкретного студента
    private void CompareTasks(Student student)
    {
      string[] allTaskStr = new string[ListOfAllTasks.Count];
      string[] allAcceptedStr = new string[student.ListOfAcceptedTasks.Count];
      int counter1 = 0;
      int counter2 = 0;
      foreach (var task in ListOfAllTasks)
      {
        allTaskStr[counter1] = $"{task.Name}";
        counter1++;
      }

      foreach (var studentTask in student.ListOfAcceptedTasks)
      {
        allAcceptedStr[counter2] = $"{studentTask.Name}";
        counter2++;
      }

      FindMissingElementOfArray(allTaskStr, allAcceptedStr);
    }

    private void FindMissingElementOfArray(string[] allTaskStr, string[] allAcceptedStr)
    {
      HashSet<string> set2 = new HashSet<string>(allAcceptedStr);
      List<string> missingElements = new List<string>();

      foreach (string element in allTaskStr)
      {
        if (!set2.Contains(element))
        {
          missingElements.Add(element);
        }
      }

      Console.WriteLine("Задолженность: " + string.Join(", ", missingElements));
    }

    //добавление заданий в общий список заданий группы
    private void AddRegularTaskToAllTasksList(RegularTask regularTask)
    {
      AbstractTask task = regularTask;
      ListOfAllTasks.Add(task);
    }

    private void AddTestingTaskToAllTaskList(Testing testing)
    {
      AbstractTask task = testing;
      ListOfAllTasks.Add(task);
    }

    private void AddProjectTaskToAllTaskList(Project project)
    {
      AbstractTask task = project;
      ListOfAllTasks.Add(task);
    }
    //добавление заданий в общий список заданий группы - конец

    //работа с заданиями 
    public void AddRegularTask(RegularTask regularTask)
    {
      ListOfRegularTasks.Add(regularTask);
      AddRegularTaskToAllTasksList(regularTask);
    }

    public RegularTask GetRegularTask(string regularTaskName)
    {
      foreach (var regularTask in ListOfRegularTasks)
      {
        if (regularTask.Name == regularTaskName)
        {
          return regularTask;
        }
      }

      return null;
    }
    public bool RemoveRegularTask(string name)
    {
      bool isDelete = false;
      foreach (var regularTask in ListOfRegularTasks)
      {
        if (regularTask.Name.Contains(name))
        {
          ListOfRegularTasks.Remove(regularTask);
          ListOfAllTasks.Remove(regularTask);
          Console.WriteLine("Задание удалено");
          isDelete = true;
          return isDelete;
        }
      }

      return isDelete;
    }

    public void DisplayStudents()
    {
      foreach (var student in ListOfStudents)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(student.Name);
        Console.WriteLine(student.Phone);
        Console.WriteLine(student.Mail);
        Console.WriteLine("/------------------/");
      }
    }

    public Student ReturnStudent(string name)
    {
      foreach (var student in ListOfStudents)
      {
        if (student.Name == name)
        {
          Console.WriteLine($"{student.Name} найден");
          return student;
        }
      }

      return null;
    }

    public void DisplayRegularTasks()
    {
      foreach (var regTask in ListOfRegularTasks)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(regTask.Name);
        Console.WriteLine(regTask.Description);
        Console.WriteLine(regTask.Deadline);
        Console.WriteLine("/------------------/");
      }
    }

    public void DisplayProjects()
    {
      foreach (var project in ListOfProjects)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(project.Name);
        Console.WriteLine(project.Description);
        Console.WriteLine(project.SubTasks);
        Console.WriteLine(project.Deadline);
        Console.WriteLine("/------------------/");
      }
    }

    public void AddStudent(Student student)
    {
      ListOfStudents.Add(student);
    }

    public bool RemoveStudent(string fullName)
    {
      Student studentToRemove = ListOfStudents.Find(s => s.Name == fullName);
      if (studentToRemove != null)
      {
        ListOfStudents.Remove(studentToRemove);
        return true;
      }

      return false;
    }


    public void AddProject(Project project)
    {
      ListOfProjects.Add(project);
      AddProjectTaskToAllTaskList(project);
    }

    public Project GetProject(string projectName)
    {
      foreach (var project in ListOfProjects)
      {
        if (project.Name == projectName)
        {
          return project;
        }
      }

      return null;
    }
    public bool RemoveProject(string name)
    {
      bool isDelete = false;
      foreach (var project in ListOfProjects)
      {
        if (project.Name.Contains(name))
        {
          ListOfProjects.Remove(project);
          ListOfAllTasks.Remove(project);
          Console.WriteLine("Проект удален");
          isDelete = true;
          return isDelete;
        }
      }

      return isDelete;
    }

    public void AddTesting(Testing testing)
    {
      ListOfTesting.Add(testing);
      AddTestingTaskToAllTaskList(testing);
    }
    
    public Testing GetTesting(string testingName)
    {
      foreach (var testing in ListOfTesting)
      {
        if (testing.Name == testingName)
        {
          return testing;
        }
      }

      return null;
    }

    public bool RemoveTesting(string name)
    {
      bool isDelete = false;
      foreach (var testing in ListOfTesting)
      {
        if (testing.Name.Contains(name))
        {
          ListOfTesting.Remove(testing);
          ListOfAllTasks.Remove(testing);
          Console.WriteLine("Тестирование удалено");
          isDelete = true;
          return isDelete;
        }
      }

      return isDelete;
    }

    public void DisplayTestings()
    {
      foreach (var testings in ListOfTesting)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(testings.Name);
        Console.WriteLine(testings.LinkToTesting);
        Console.WriteLine(testings.Deadline);
        Console.WriteLine("/------------------/");
      }
    }

    //работа с заданиями конец
    public void DisplaySeminarsInGroup()
    {
      foreach (var seminar in ListOfSeminars)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(seminar.ListOfTopics);
        Console.WriteLine(seminar.Date);
        Console.WriteLine(seminar.CommentFromTeacher);
        Console.WriteLine("/------------------/");
      }
    }

    public void AddSeminarToListOFSeminars(Lesson lesson)
    {
      ListOfSeminars.Add(lesson);
      Console.WriteLine("семинар добавлен");
    }

    public bool RemoveSeminarFromListOfSeminars(string topic, string date)
    {
      bool isDelete = false;
      foreach (var lesson in ListOfSeminars)
      {
        if (lesson.ListOfTopics.Contains(topic))
        {
          if (lesson.Date == date)
          {
            ListOfSeminars.Remove(lesson);
            Console.WriteLine("семинар удалён");
            isDelete = true;
            return isDelete;
          }
        }
        else
        {
          Console.WriteLine("семинар не найден");
        }
      }

      return isDelete;
    }

    public void DisplayLecturesInGroup()
    {
      foreach (var lecture in ListOfLectures)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(lecture.ListOfTopics);
        Console.WriteLine(lecture.Date);
        Console.WriteLine(lecture.CommentFromTeacher);
        Console.WriteLine("/------------------/");
      }
    }

    public void AddLectureToListOFLectures(Lesson lesson)
    {
      ListOfLectures.Add(lesson);
      Console.WriteLine("Лекция добавлена");
    }

    public bool RemoveLectureFromListOfListOfLectures(string topic, string date)
    {
      bool isDelete = false;
      foreach (var lecture in ListOfLectures)
      {
        if (lecture.ListOfTopics.Contains(topic))
        {
          if (lecture.Date == date)
          {
            ListOfLectures.Remove(lecture);
            Console.WriteLine("лекция удалена");
            isDelete = true;
            return isDelete;
          }
        }
        else
        {
          Console.WriteLine("лекция не найдена");
        }
      }

      return isDelete;
    }

    public void DisplayListOfAnotherLessonsInGroup()
    {
      foreach (var anotherLesson in ListOfAnotherLessons)
      {
        Console.WriteLine("/------------------/");
        Console.WriteLine(anotherLesson.ListOfTopics);
        Console.WriteLine(anotherLesson.Date);
        Console.WriteLine(anotherLesson.CommentFromTeacher);
        Console.WriteLine("/------------------/");
      }
    }

    public void AddAnotherLessonToListOfAnotherLessons(Lesson lesson)
    {
      ListOfAnotherLessons.Add(lesson);
      Console.WriteLine("Другой тип занятия добавлен");
    }

    public bool RemoveAnotherLessonFromListOfAnotherLessons(string topic, string date)
    {
      bool isDelete = false;
      foreach (var anotherLesson in ListOfAnotherLessons)
      {
        if (anotherLesson.ListOfTopics.Contains(topic))
        {
          if (anotherLesson.Date == date)
          {
            ListOfLectures.Remove(anotherLesson);
            Console.WriteLine("занятие удалено");
            isDelete = true;
            return isDelete;
          }
        }
        else
        {
          Console.WriteLine("занятие не найдено");
        }
      }

      return isDelete;
    }
  }
}