using System;

namespace Back.Services.HelpfulClassesForTesting
{
    public class CourseDateGenerator
    {
        public static DateTime DateGenerator()
        {
            DateTime startDay = DateTime.UtcNow;
            Random generateDate = new Random();
            DateTime courseStartingDay = startDay
                .AddDays(generateDate.Next(2, 60));

            return courseStartingDay;
        }
    }
}