using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
