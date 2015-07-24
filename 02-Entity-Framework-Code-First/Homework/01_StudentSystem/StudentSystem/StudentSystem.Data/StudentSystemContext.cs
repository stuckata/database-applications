namespace StudentSystem.Data
{
    using StudentSystem.Model;
    using System.Data.Entity;


    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }
    }
}