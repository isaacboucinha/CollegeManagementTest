using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models.DTO
{
    //this class is IEquatable to be compared by field and not
    //by reference in Distinct operations
    public class StudentDTO : IEquatable<StudentDTO>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public long RegistrationNumber { get; set; }

        public IEnumerable<GradeDTO> Grades { get; set; }

        public double GradeAverage { get; set; }

        public override bool Equals(object obj)
        {
            return obj is StudentDTO dTO &&
                   Name == dTO.Name &&
                   RegistrationNumber == dTO.RegistrationNumber;
        }

        public bool Equals([AllowNull] StudentDTO other)
        {
            return other != null &&
                   Name == other.Name &&
                   RegistrationNumber == other.RegistrationNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, RegistrationNumber);
        }
    }
}
