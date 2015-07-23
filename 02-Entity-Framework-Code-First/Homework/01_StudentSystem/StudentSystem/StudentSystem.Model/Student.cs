using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Student
    {
        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public int Name { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        private ICollection<Course> courses;

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

    }
}
