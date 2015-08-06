using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_CodeFirstMovies
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(0, 10, ErrorMessage = "Stars should be in range 0 to 10")]
        public int Stars { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }
    }
}
