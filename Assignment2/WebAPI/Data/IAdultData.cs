using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebAPI.Data
{
    public interface IAdultData
    {
         Task <List<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex);
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}