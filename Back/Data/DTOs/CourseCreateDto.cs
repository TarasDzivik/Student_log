using System;

namespace Back.Data.DTOs
{
    public class CourseCreateDto
    {
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public byte[] TitleImagePath { get; set; }
    }
}