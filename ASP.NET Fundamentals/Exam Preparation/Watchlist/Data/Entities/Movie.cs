using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Entities
{
    public class Movie
    {
        public Movie()
        {
            this.UsersMovies = new List<UserMovie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        public IEnumerable<UserMovie> UsersMovies { get; set; }
    }
}

//•	Has Id – a unique integer, Primary Key
//•	Has Title – a string with min length 10 and max length 50 (required)
//•	Has Director – a string with min length 5 and max length 50 (required)
//•	Has ImageUrl – a string (required)
//•	Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//•	Has GenreId – an integer
//•	Has Genre – a Genre 
//•	Has UsersMovies – a collection of type UserMovie
