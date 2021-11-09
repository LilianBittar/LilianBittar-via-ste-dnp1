using System.Threading.Tasks;
using TodoDataBase.Models;

namespace TodoDataBase.Data {
    public interface IUserService {
        Task<User> ValidateUser(string userName, string passWord);
    }
}