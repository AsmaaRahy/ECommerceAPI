using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTO
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
    }
}
