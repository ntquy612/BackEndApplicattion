namespace BackEndApplicattion.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string UserName) : base("User", UserName)
        {
        }
    }
}
