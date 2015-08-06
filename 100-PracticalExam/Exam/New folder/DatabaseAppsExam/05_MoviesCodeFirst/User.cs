using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_CodeFirstMovies
{
    public class User
    {
        private ICollection<Rating> ratings;
        private ICollection<Movie> movies;

        public User()
        {
            this.ratings = new HashSet<Rating>();
            this.movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Username should be at least 5 characters")]
        public string Username { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
