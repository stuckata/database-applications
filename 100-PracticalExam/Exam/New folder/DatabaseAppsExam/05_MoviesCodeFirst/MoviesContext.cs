namespace _05_MoviesCodeFirst
{
    using _05_CodeFirstMovies;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("MoviesContext.config")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}