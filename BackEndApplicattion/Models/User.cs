using System.ComponentModel.DataAnnotations;

namespace BackEndApplicattion.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; } = default!;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = default!;
        public bool IsAdmin { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
        public bool IsDelete { get; set; } = default!;

        public User(string Name, string Email, string UserName, string Password, string Address, bool IsAdmin, bool IsActive, bool IsDelete)
        {
            this.Id = new Guid();
            this.Name = Name;
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
            this.Address = Address;
            this.IsActive = IsActive;
            this.IsAdmin = IsAdmin;
            this.IsDelete = IsDelete;
        }

    }
}
