﻿using System;
using EducationOrganaizer.Classes;


namespace EducationOrganaizer
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      Classes.EducationOrganaizer educationOrganaizer = new Classes.EducationOrganaizer();


      while (true)
      {
        Console.WriteLine("Здравствуйте, выберите интересующую вас опцию");
        Console.WriteLine("Нажмите 1, чтобы создать или отредактировать группы");
        Console.WriteLine("Нажмите 2, чтобы удалить группу");
        Console.WriteLine("Нажмите 3, чтобы посмотреть список групп");
        Console.WriteLine("Нажмите 'x', чтобы выйти");
        var choice = Console.ReadLine();
        switch (choice)
        {
          case "1":
            educationOrganaizer.ShowAllJson();
            Console.WriteLine("Введите название группы");
            string groupName = Console.ReadLine();
            if (groupName == "r")
            {
              throw new ArgumentException("Название группы не должно быть 'r'");
            }

            Group groupFromRead = educationOrganaizer.ReadGroupFromBdOrCreateNewGroup(groupName);
            Group newGroup = new Group(groupName);
            if (groupFromRead != null)
            {
              newGroup = groupFromRead;
            }
            else
            {
              educationOrganaizer.AddGroupInListOfGroup(newGroup);
              educationOrganaizer.SaveToDb(newGroup);
            }

            while (true)
            {
              Console.WriteLine("Нажмите 1, чтобы редактировать список студентов");
              Console.WriteLine("Нажмите 2, чтобы редактировать список заданий");
              Console.WriteLine("Нажмите 3, чтобы редактировать список занятий");
              Console.WriteLine("Нажмите 4, чтобы вернуться назад");
              choice = Console.ReadLine();
              if (choice == "4")
              {
                break;
              }

              while (true)
              {
                switch (choice)
                {
                  case "1":
                    newGroup.DisplayStudents();
                    Console.WriteLine("1, чтобы добавить студента в группу");
                    Console.WriteLine("2, чтобы удалить студента из группы");
                    Console.WriteLine("3, чтобы добавить/удалить задание в список принятых заданий студента");
                    Console.WriteLine("4, чтобы вернуться назад");
                    while (true)
                    {
                      choice = Console.ReadLine();
                      switch (choice)
                      {
                        case "1":
                          Console.WriteLine("Введите полное имя");
                          string fullName = Console.ReadLine();
                          Console.WriteLine("Введите телефон");
                          string phone = Console.ReadLine();
                          Console.WriteLine("Введите почту");
                          string mail = Console.ReadLine();
                          Student student = new Student(fullName, phone, mail);
                          newGroup.AddStudent(student);
                          Console.WriteLine("Студент добавлен");

                          educationOrganaizer.SaveToDb(newGroup);

                          break;
                        case "2":
                          Console.WriteLine("Введите полное имя");
                          string fullNameofStudent = Console.ReadLine();
                          bool check = newGroup.RemoveStudent(fullNameofStudent);
                          if (check == true)
                          {
                            Console.WriteLine("студент удалён");
                            educationOrganaizer.SaveToDb(newGroup);
                          }
                          else
                          {
                            Console.WriteLine("студента удалить не удалось");
                          }

                          break;
                        case "3":
                          Console.WriteLine("Список студентов группы:");
                          newGroup.DisplayStudents();
                          Console.WriteLine("Введите имя студента");
                          string studentName = Console.ReadLine();
                          Student returnedStudent = newGroup.ReturnStudent(studentName);
                          if (returnedStudent != null)
                          {
                            Console.WriteLine("1, чтобы добавить задание в принятые");
                            Console.WriteLine("2, чтобы удалить задание из принятых");
                            Console.WriteLine("3, чтобы вернуться назад");
                            Console.WriteLine("4, чтобы посмотреть список задолженностей");
                            choice = Console.ReadLine();
                            if (choice == "3") break;
                            switch (choice)
                            {
                              case "1":
                                newGroup.DisplayAllTasks();
                                Console.WriteLine(
                                  "Введите название принятого задания или напишите 'r' чтобы вернуться назад");
                                choice = Console.ReadLine();
                                if (choice == "r") break;
                                returnedStudent.AddTaskToListOfAcceptedTasks(choice);
                                educationOrganaizer.SaveToDb(newGroup);
                                break;
                              case "2":
                                Console.WriteLine("Список принятых заданий");
                                returnedStudent.DisplayAcceptedTasks();
                                Console.WriteLine(
                                  "Введите название задания для удаления или напишите 'r' чтобы вернуться назад");
                                choice = Console.ReadLine();
                                if (choice == "r") break;
                                returnedStudent.RemoveTaskToListOfAcceptedTasks(choice);
                                educationOrganaizer.SaveToDb(newGroup);
                                break;
                              case "4":
                                newGroup.DisplayTaskStatusOfStudent(returnedStudent);
                                break;
                            }
                          }
                          else
                          {
                            Console.WriteLine("Студент не найден");
                            break;
                          }

                          break;
                        case "4":
                          break;
                      }

                      break;
                    }

                    break;
                  case "2":
                    Console.WriteLine("Выберите тип задания");
                    Console.WriteLine("1, Обычное задание");
                    Console.WriteLine("2, Тестирование");
                    Console.WriteLine("3, Проект");
                    Console.WriteLine("4, чтобы вернуться");
                    while (true)
                    {
                      choice = Console.ReadLine();
                      switch (choice)
                      {
                        case "1":
                          newGroup.DisplayRegularTasks();
                          Console.WriteLine("1, для добавления задания");
                          Console.WriteLine("2, для удаления задания");
                          Console.WriteLine("3, чтобы вернуться");
                          while (true)
                          {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                              case "1":
                                Console.WriteLine("Введите название задания");
                                string taskName = Console.ReadLine();
                                Console.WriteLine("Введите описание");
                                string description = Console.ReadLine();
                                Console.WriteLine("Введите дополнительные ссылки");
                                string links = Console.ReadLine();
                                Console.WriteLine("Введите дату сдачи задания");
                                string deadline = Console.ReadLine();
                                RegularTask regularTask = new RegularTask(taskName,
                                  description, links, deadline);

                                newGroup.AddRegularTask(regularTask);
                                educationOrganaizer.SaveToDb(newGroup);
                                Console.WriteLine("Задание добавлено");
                                break;
                              case "2":
                                Console.WriteLine(
                                  "Введите название задания или нажмите 'r', чтобы вернуться ");
                                string taskNameForDelete = Console.ReadLine();
                                if (taskNameForDelete == "r")
                                {
                                  break;
                                }

                                bool isDelete =
                                  newGroup.RemoveRegularTask(taskNameForDelete);
                                if (isDelete == false)
                                {
                                  Console.WriteLine("Задание удалить не удалось");
                                }

                                educationOrganaizer.SaveToDb(newGroup);
                                break;
                              case "3":
                                break;
                            }

                            break;
                          }

                          break;
                        case "2":
                          newGroup.DisplayTestings();
                          Console.WriteLine("1, для добавления тестирования");
                          Console.WriteLine("2, для удаления тестирования");
                          Console.WriteLine("3, вернуться назад");
                          choice = Console.ReadLine();
                          if (choice == "3")
                          {
                            break;
                          }

                          while (true)
                          {
                            switch (choice)
                            {
                              case "1":
                                Console.WriteLine(
                                  "Введите название тестирования или нажмите 'r', чтобы вернуться");
                                string testingName = Console.ReadLine();
                                if (testingName == "r")
                                {
                                  break;
                                }

                                Console.WriteLine("Введите ссылку на тестирование");
                                string links = Console.ReadLine();
                                Console.WriteLine("Введите дату сдачи тестирования");
                                string deadline = Console.ReadLine();
                                Testing testing = new Testing(testingName, links,
                                  deadline);
                                newGroup.AddTesting(testing);
                                educationOrganaizer.SaveToDb(newGroup);
                                break;
                              case "2":
                                Console.WriteLine(
                                  "Введите название тестирования или нажмите 'r', чтобы вернуться ");
                                string testingNameForDelete = Console.ReadLine();
                                if (testingNameForDelete == "r")
                                {
                                  break;
                                }

                                bool isDelete =
                                  newGroup.RemoveTesting(testingNameForDelete);
                                if (isDelete == false)
                                {
                                  Console.WriteLine(
                                    "Тестирование удалить не удалось");
                                }

                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "3":
                                break;
                            }

                            break;
                          }

                          break;
                        case "3":
                          newGroup.DisplayProjects();
                          Console.WriteLine("1, для добавления проекта");
                          Console.WriteLine("2, для удаления проекта");
                          Console.WriteLine("3, назад");

                          while (true)
                          {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                              case "1":
                                Console.WriteLine(
                                  "Введите название проекта или нажмите 'r', чтобы вернуться");
                                string projectName = Console.ReadLine();
                                if (projectName == "r")
                                {
                                  break;
                                }

                                Console.WriteLine("Введите описание проекта");
                                string description = Console.ReadLine();
                                Console.WriteLine("Введите дополнительные ссылки");
                                string links = Console.ReadLine();
                                Console.WriteLine("Введите подзадачи");
                                string subtasks = Console.ReadLine();
                                Console.WriteLine("Введите дату сдачи задания");
                                string deadline = Console.ReadLine();
                                Project project = new Project(projectName, description,
                                  links, deadline, subtasks);

                                newGroup.AddProject(project);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "2":
                                Console.WriteLine(
                                  "Введите название проекта или нажмите 'r' чтобы вернуться");
                                string projectNameForDelete = Console.ReadLine();
                                if (projectNameForDelete == "r")
                                {
                                  break;
                                }

                                bool isDelete =
                                  newGroup.RemoveProject(projectNameForDelete);
                                if (isDelete == false)
                                {
                                  Console.WriteLine("Проект удалить не удалось");
                                }

                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "3":
                                break;
                            }

                            break;
                          }

                          break;
                        case "4":

                          break;
                      }

                      break;
                    }

                    break;
                  case "3":

                    while (true)
                    {
                      Console.WriteLine("Выберите тип занятий");
                      Console.WriteLine("1, для создания семинара");
                      Console.WriteLine("2, для создания лекции");
                      Console.WriteLine("3, для создания другого типа занятий");
                      Console.WriteLine("4, чтобы вернуться назад");
                      choice = Console.ReadLine();
                      switch (choice)
                      {
                        case "1":
                          newGroup.DisplaySeminarsInGroup();
                          Console.WriteLine("1, для добавления семинара");
                          Console.WriteLine("2, для удаления семинара");
                          Console.WriteLine("3, вернуться назад");
                          while (true)
                          {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                              case "1":
                                Console.WriteLine("Введите дату занятия");
                                string dateOfSeminar = Console.ReadLine();
                                Console.WriteLine("Введите список тем занятия");
                                string listOfTopics = Console.ReadLine();
                                Console.WriteLine("Введите комментарии");
                                string seminarCommentary = Console.ReadLine();
                                Lesson lesson = new Lesson(dateOfSeminar, listOfTopics,
                                  seminarCommentary, LessonEnum.Consultation);
                                newGroup.AddSeminarToListOFSeminars(lesson);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "2":
                                Console.WriteLine("Введите тему семинара для удаления");
                                string seminarForDelete = Console.ReadLine();
                                Console.WriteLine("Введите дату семинара для удаления");
                                string seminarDateForDelete = Console.ReadLine();
                                newGroup.RemoveSeminarFromListOfSeminars(
                                  seminarForDelete,
                                  seminarDateForDelete);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "3":
                                break;
                            }

                            break;
                          }

                          break;
                        case "2":
                          newGroup.DisplayLecturesInGroup();
                          Console.WriteLine("1, для добавления лекции");
                          Console.WriteLine("2, для удаления лекции");
                          Console.WriteLine("3, вернуться назад");
                          while (true)
                          {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                              case "1":
                                Console.WriteLine("Введите дату занятия");
                                string dateOfLecture = Console.ReadLine();
                                Console.WriteLine("Введите список тем занятия");
                                string listOfTopics = Console.ReadLine();
                                Console.WriteLine("Введите комментарии");
                                string lectureCommentary = Console.ReadLine();
                                Lesson lesson = new Lesson(dateOfLecture, listOfTopics,
                                  lectureCommentary, LessonEnum.Lecture);
                                newGroup.AddLectureToListOFLectures(lesson);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "2":
                                Console.WriteLine("Введите тему лекции для удаления");
                                string lectureForDelete = Console.ReadLine();
                                Console.WriteLine("Введите дату лекции для удаления");
                                string lectureDateForDelete = Console.ReadLine();
                                newGroup.RemoveLectureFromListOfListOfLectures(
                                  lectureForDelete,
                                  lectureDateForDelete);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "3":
                                break;
                            }

                            break;
                          }

                          break;
                        case "3":
                          newGroup.DisplayListOfAnotherLessonsInGroup();
                          Console.WriteLine("1, для добавления другого типа занятий");
                          Console.WriteLine("2, для удаления другого типа занятий");
                          Console.WriteLine("3, вернуться назад");
                          while (true)
                          {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                              case "1":
                                Console.WriteLine("Введите дату занятия");
                                string dateOfAnotherLesson = Console.ReadLine();
                                Console.WriteLine("Введите список тем занятия");
                                string listOfTopics = Console.ReadLine();
                                Console.WriteLine("Введите комментарии");
                                string anotherLessonCommentary = Console.ReadLine();
                                Lesson lesson = new Lesson(dateOfAnotherLesson,
                                  listOfTopics,
                                  anotherLessonCommentary, LessonEnum.Other);
                                newGroup.AddAnotherLessonToListOfAnotherLessons(lesson);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "2":
                                Console.WriteLine("Введите тему занятия для удаления");
                                string anotherLessonTopicsForDelete =
                                  Console.ReadLine();
                                Console.WriteLine("Введите дату занятия для удаления");
                                string anotherLessonDateForDelete = Console.ReadLine();
                                newGroup.RemoveAnotherLessonFromListOfAnotherLessons(
                                  anotherLessonTopicsForDelete,
                                  anotherLessonDateForDelete);
                                educationOrganaizer.SaveToDb(newGroup);

                                break;
                              case "3":
                                break;
                            }

                            break;
                          }

                          break;
                        case "4":
                          break;
                      }

                      break;
                    }

                    break;
                }

                break;
              }
            }

            break;
          case "2":
            educationOrganaizer.ShowAllJson();
            Console.WriteLine("Нажмите 1, чтобы удалить группу");
            Console.WriteLine("Нажмите 2, чтобы вернуться назад");
            choice = Console.ReadLine();
            switch (choice)
            {
              case "1":
                educationOrganaizer.ShowAllJson();
                Console.WriteLine("Введите название группы, напишите 'r', чтобы вернуться назад");
                string groupNameForDelete = Console.ReadLine();
                if (groupNameForDelete == "r")
                {
                  break;
                }

                bool isDelete = educationOrganaizer.RemoveToDb(groupNameForDelete);
                if (isDelete == false)
                {
                  Console.WriteLine("Группу удалить не удалось");
                }

                break;
              case "2":
                break;
            }

            break;
          case "3":
            Console.WriteLine("Список групп:");
            educationOrganaizer.ShowAllJson();
            Console.WriteLine("//------------//");
            Console.WriteLine("Введите название группы для просмотра");
            choice = Console.ReadLine();
            Group group = educationOrganaizer.ReadGroupFromBd(choice);
            if (group == null)
            {
              Console.WriteLine("Группа не найдена");
              break;
            }
            else
            {
              Console.WriteLine($"{group.Name} - найдена");
              while (true)
              {
                Console.WriteLine("1, чтобы посмотреть список всех заданий");
                Console.WriteLine("2, чтобы посмотреть список обычных заданий");
                Console.WriteLine("3, чтобы посмотреть список тестирований");
                Console.WriteLine("4, чтобы посмотреть список проектов");
                Console.WriteLine("5, чтобы посмотреть список студентов");
                Console.WriteLine("6, чтобы посомтреть список занятий");
                Console.WriteLine("7, чтобы вернуться назад");
                choice = Console.ReadLine();
                if (choice == "7")
                {
                  break;
                }

                switch (choice)
                {
                  case "1":
                    group.DisplayAllTasks();
                    break;
                  case "2":
                    Console.WriteLine("Список обычных заданий:");
                    group.DisplayRegularTasks();
                    Console.WriteLine("1, чтобы проверить выполнение обычного задания у всех студентов");
                    Console.WriteLine("2, назад");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                      case "1":
                        Console.WriteLine("Введите название обычного задания для проверки, введите 'r', чтобы вернуться назад");
                        choice = Console.ReadLine();
                        if (choice == "r") break;
                        RegularTask regularTask = group.GetRegularTask(choice);
                        group.DisplayRegularTaskStatusOfAllStudents(regularTask);
                        break;
                      case "2":
                        break;
                    }
                    break;
                  case "3":
                    Console.WriteLine("Список тестирований:");
                    group.DisplayTestings();
                    Console.WriteLine("1, чтобы проверить выполнение тестирования у всех студентов");
                    Console.WriteLine("2, назад");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                      case "1":
                        Console.WriteLine("Введите название проекта для проверки, введите 'r', чтобы вернуться назад");
                        choice = Console.ReadLine();
                        if (choice == "r") break;
                        Testing testing = group.GetTesting(choice);
                        group.DisplayTestingStatusOfAllStudents(testing);
                        break;
                      case "2":
                        break;
                    }
                    break;
                  case "4":
                    Console.WriteLine("Список проектов:");
                    group.DisplayProjects();
                    Console.WriteLine("1, чтобы проверить выполнение проекта у всех студентов");
                    Console.WriteLine("2, назад");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                      case "1":
                        Console.WriteLine("Введите название проекта для проверки, введите 'r', чтобы вернуться назад");
                        choice = Console.ReadLine();
                        if (choice == "r") break;
                        Project project = group.GetProject(choice);
                        group.DisplayProjectStatusOfAllStudents(project);
                        break;
                      case "2":
                        break;
                    }

                    break;
                  case "5":
                    Console.WriteLine("Список студентов:");
                    group.DisplayStudents();

                    break;
                  case "6":
                    Console.WriteLine("1, посмотреть список лекций");
                    Console.WriteLine("2, посмотреть список семинаров");
                    Console.WriteLine("3, посмотреть список других занятий");
                    Console.WriteLine("4, вернуться назад");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                      case "1":
                        Console.WriteLine("Список лекций:");
                        group.DisplayLecturesInGroup();
                        break;
                      case "2":
                        Console.WriteLine("Список семинаров:");
                        group.DisplaySeminarsInGroup();
                        break;
                      case "3":
                        Console.WriteLine("Список других занятий:");
                        group.DisplayListOfAnotherLessonsInGroup();
                        break;
                      case "4":
                        break;
                    }

                    break;
                }
              }
            }

            break;
          case "x":

            return;
        }
      }
    }
  }
}