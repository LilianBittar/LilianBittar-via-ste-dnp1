using Assignment1.Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        User ValisateUser(string userName, string Password);
        bool IsEmailRegistered(string email);
        void RegisterUser(User user);
    }
}