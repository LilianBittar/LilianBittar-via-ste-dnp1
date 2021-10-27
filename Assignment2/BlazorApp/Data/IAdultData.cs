using System.Collections.Generic;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface IAdultData
    {
        IList<Adults> GetAdults();
        void AddAdult(Adults adult);
    }
}