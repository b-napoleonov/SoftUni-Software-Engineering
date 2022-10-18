using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
