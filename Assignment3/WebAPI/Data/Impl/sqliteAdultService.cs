using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Data;
using WebApp.Models;

namespace BlazorApp.Data.Impl
{ 
    public class sqliteAdultService : IAdultData
    {

        private Adultcontext context;
        public sqliteAdultService(Adultcontext context)
        {
            this.context = context;
        }
        public async Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex)
        {
            var toReturn = context.Adults.ToList();
            var toRemove = new List<Adult>();

            if (id != null)
            {
                foreach (var adult in toReturn)
                {
                    if (adult.Id != id) toRemove.Add(adult);
                }
            }
            
            if (name != null)
            {
                foreach (var adult in toReturn)
                {
                    if (adult.FirstName + adult.LastName != name) toRemove.Add(adult);
                }
            }
            
            if (age != null)
            {
                foreach (var adult in toReturn)
                {
                    if (adult.Age != age) toRemove.Add(adult);
                }
            }
            
            if (sex != null)
            {
                foreach (var adult in toReturn)
                {
                    if (adult.Sex != sex) toRemove.Add(adult);
                }
            }
            foreach (var adult in toRemove) toReturn.Remove(adult);

            return toReturn;

        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            context.Adults.AddAsync(adult);
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult adult = context.Adults.Where(a => a.Id == adultId).First();
             context.Remove(adultId);
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            context.Adults.Update(adult);
            return adult;
        }
    }
}