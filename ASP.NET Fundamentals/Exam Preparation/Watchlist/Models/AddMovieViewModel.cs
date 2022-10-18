using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Entities;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        public AddMovieViewModel()
        {
            this.Genres = new List<Genre>();
        }

        [Required]
        [StringLength(50), MinLength(10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50), MinLength(5)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.00", "10.00", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}
