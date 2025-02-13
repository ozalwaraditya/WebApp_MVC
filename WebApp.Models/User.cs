using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class User
    {
        [Key] // Treat as it a primary key
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")] // We can customize the name from this to display it on the input label
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters")]
        public required string Password { get; set; }
    }
}
