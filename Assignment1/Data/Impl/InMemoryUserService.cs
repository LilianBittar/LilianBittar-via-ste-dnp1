using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment1.Models;

namespace Assignment1.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private string usersFile = "usersFile.json";
        
        private IList<User> users { get;  }

        public InMemoryUserService()
        {
            users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
            
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            var jsonUsers = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (var outputFile = new StreamWriter(usersFile, false))
            {
                outputFile.Write(jsonUsers);
            }
        }

        public User ValisateUser(string Email, string Password)
        {
            User first = users.FirstOrDefault(user => user.Email.Equals(Email));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
        
        public bool IsEmailRegistered(string email) {
            foreach (var user in users) if (user.Email.Equals(email)) return true;
            return false;
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
            SaveChanges();
        }
        
    }
}