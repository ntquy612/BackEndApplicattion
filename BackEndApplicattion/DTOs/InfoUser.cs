namespace BackEndApplicattion.DTOs
{
    public class InfoUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public bool IsAdmin { get; set; } = default!;
        public bool IsActive { get; set; } = default!;

        public InfoUser(Guid Id, string Name, string Email, string UserName, string Address, bool IsAdmin, bool IsActive)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.UserName = UserName;
            this.Address = Address;
            this.IsActive = IsActive;
            this.IsAdmin = IsAdmin;
        }
    }
}
