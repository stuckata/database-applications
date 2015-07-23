using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(50)]
        public int Name { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
