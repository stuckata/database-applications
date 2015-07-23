﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Resource> resources;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }     

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }
    }
}
