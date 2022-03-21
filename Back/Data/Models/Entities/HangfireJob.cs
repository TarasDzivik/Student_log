using System;

namespace Back.Data.Models.Entities
{
    public class HangfireJob
    {
        public Guid Id { get; set; }

        public DateTime MonthNotification { get; set; }
        public DateTime WeekNotification { get; set; }
        public DateTime DayNotification { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}