using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_CodeFirstMovies
{
    public class Movie
    {
        private ICollection<User> users;
        private ICollection<Rating> ratings;

        public Movie()
        {
            this.users = new HashSet<User>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        public string Isbn { get; set; }

        [MinLength(2, ErrorMessage = "Title should be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Title should be less than 100 characters")]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
