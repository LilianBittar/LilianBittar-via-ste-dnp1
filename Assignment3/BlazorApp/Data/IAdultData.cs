using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface IAdultData
    {
        Task <IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex);
        Task<Adult> AddAdultAsync(Adult adult);
    }
}