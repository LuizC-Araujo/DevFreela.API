namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public UserViewModel()
        {
            
        }

        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
