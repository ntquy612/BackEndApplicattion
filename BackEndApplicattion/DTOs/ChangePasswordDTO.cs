using System.ComponentModel.DataAnnotations;

namespace BackEndApplicattion.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string NewPassword { get; set; } = default!;
        [Required]
        public bool IsAuthentication { get; set; } = default!;
    }
}
