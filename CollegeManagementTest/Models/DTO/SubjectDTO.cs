using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models.DTO
{
    public class SubjectDTO
    {
        public string Name { get; set; }

        public virtual IEnumerable<GradeDTO> Grades { get; set; }

        public virtual TeacherDTO Teacher { get; set; }
    }
}
