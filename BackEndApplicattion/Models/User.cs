namespace BackEndApplicattion.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string UserName { get; set; } = default!;
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
