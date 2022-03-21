using System;
using System.Collections.Generic;

namespace Back.Data.Models.Entities
{
    public class UserCourse
    {
        public Guid UserCourseId { get; set; }

        public Guid CurrentUserId { get; set; }
        public IList<User> Users { get; set; }

        public Guid CurrentCourseId { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
