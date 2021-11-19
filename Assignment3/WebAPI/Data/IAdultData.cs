using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApp.Models;

namespace WebAPI.Data
{
    public interface IAdultData
    {
         Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex);
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}