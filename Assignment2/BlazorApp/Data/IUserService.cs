using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface IUserService
    {
        Task<User> ValisateUser(string userName, string Password);
       
        Task RegisterUser(User user);
    }
}