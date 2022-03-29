using System;

namespace Back.Data.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public byte[] TitleImagePath { get; set; }
        public DateTime DateOdStart { get; set; }
    }
}