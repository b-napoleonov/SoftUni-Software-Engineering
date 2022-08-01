using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorImportModel
    {
        [Required]
        [StringLength(30), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30), MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<BooksDTO> Books { get; set; }
    }

    public class BooksDTO
    {
        public int? Id { get; set; }
    }
}
