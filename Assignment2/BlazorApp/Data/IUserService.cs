using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
        bool IsEmailRegistered(string email);
        void RegisterUser(User user);
    }
}