using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models
{
    //this class is IEquatable to be compared by field and not
    //by reference in Distinct operations
    public class Student : IEquatable<Student>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public long RegistrationNumber { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name &&
                   Birthday == student.Birthday &&
                   RegistrationNumber == student.RegistrationNumber;
        }

        public bool Equals([AllowNull] Student other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Birthday == other.Birthday &&
                   RegistrationNumber == other.RegistrationNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Birthday, RegistrationNumber);
        }
    }
}
