using System;

namespace Back.Data.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime DateOdStart { get; set; }
    }
}