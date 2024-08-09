using System.ComponentModel.DataAnnotations;

namespace BackEndApplicattion.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
