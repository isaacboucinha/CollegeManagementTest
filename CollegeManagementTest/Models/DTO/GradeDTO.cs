using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models.DTO
{
    public class GradeDTO
    {
        public int Value { get; set; }

        public virtual StudentDTO Student { get; set; }
        public virtual SubjectDTO Subject { get; set; }

    }
}
