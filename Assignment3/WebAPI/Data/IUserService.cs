
using WebApp.Models;

namespace WebAPI.Data
{
    public interface IUserService
    {
        User ValisateUser(string userName, string Password);
        bool IsEmailRegistered(string email);
        void RegisterUser(User user);
    }
}