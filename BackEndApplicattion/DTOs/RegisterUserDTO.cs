using System.ComponentModel.DataAnnotations;

namespace BackEndApplicattion.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        public string Address { get; set; } = default!;
    }
}
