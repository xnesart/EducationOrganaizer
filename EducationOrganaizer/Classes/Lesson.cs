using System;
using System.Collections.Generic;

namespace EducationOrganaizer.Classes
{
    public class Lesson
    {
        public string Date { get; set; }
        public string ListOfTopics { get; set; }
        public string CommentFromTeacher { get; set; }
        public LessonEnum LessonType { get; set; }


        public Lesson
        (
            string date,
            string listOfTopics,
            string commentFromTeacher,
            LessonEnum lessonType
        )
        {
            Date = date;
            ListOfTopics = listOfTopics;
            CommentFromTeacher = commentFromTeacher;
            LessonType = lessonType;
        }
    }
}