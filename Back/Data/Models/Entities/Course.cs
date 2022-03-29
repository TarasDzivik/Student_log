using Back.Services.HelpfulClassesForTesting;
using System;

namespace Back.Data.Models.Entities
{
    public class Course
    {
        // Генератор виключно для тестування і
        // створення рандомного часу початку курсів
        protected internal Course() =>
            DateOdStart = CourseDateGenerator.DateGenerator();

        public int Id { get; set; }

        public string Title { get; set; }
        public string Desctiption { get; set; }
        public byte[] TitleImagePath { get; set; }
        public DateTime DateOdStart { get; set; }
    }
}