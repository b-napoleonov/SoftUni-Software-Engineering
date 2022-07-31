using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeImportModel
    {
        [Required]
        [StringLength(40), MinLength(3)]
        [RegularExpression("[A-z0-9]+")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[\d]{3}-[\d]{3}-[\d]{4}")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
