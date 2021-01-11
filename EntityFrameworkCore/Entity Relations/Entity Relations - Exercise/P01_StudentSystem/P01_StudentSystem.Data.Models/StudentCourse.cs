
using System.Collections;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public StudentCourse()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
        }
        
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses  { get; set; }
    }
}
