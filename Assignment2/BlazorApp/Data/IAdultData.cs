using System.Collections;
using System.Collections.Generic;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public interface IAdultData
    {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
    }
}