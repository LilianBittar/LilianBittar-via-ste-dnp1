using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (Adultcontext adultcontext = new Adultcontext())
            {
                if (!adultcontext.Adults.Any())
                {
                    Seed(adultcontext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
         private static void Seed(Adultcontext adultcontext){
             Adult adult = new Adult()
             {
                 Id = 1,
                 FirstName = "catman",
                 LastName = "Johnon",
                 Age = 12,
                 EyeColor = "Black",
                 Height = 120,
                 HairColor = "Black",
                 Sex = "man",
                 Weight = 21
             };
             adultcontext.Add(adult);
             Adult adult1 = new Adult()
             {
                 Id = 12,
                 FirstName = "Sally",
                 LastName = "Johnon",
                 Age = 10,
                 EyeColor = "Green",
                 Height = 13,
                 HairColor = "Brown",
                 Sex = "woman",
                 Weight = 20
             };
             adultcontext.Add(adult1);
             Adult adult3 = new Adult()
             {
                 Id = 11,
                 FirstName = "cato",
                 LastName = "John",
                 Age = 16,
                 EyeColor = "Blue",
                 Height = 11,
                 HairColor = "Black",
                 Sex = "man",
                 Weight = 111
             };
             adultcontext.Add(adult3);
             adultcontext.SaveChanges();
         }
         
      
    }
    
}