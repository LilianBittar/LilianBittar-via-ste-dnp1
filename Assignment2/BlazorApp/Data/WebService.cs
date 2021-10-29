using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorApp.Models;


namespace BlazorApp.Data
{
    public class WebService : IAdultData, IUserService
    {

        private string uri = "http://jsonplaceholder.typicode.com";

        private readonly HttpClient client;

        public WebService()
        {
            client = new HttpClient();
        }
        
        
        public async Task<IList<Adult>> GetAdultAsync(int UserID, bool isCompleted)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/todos?userId={UserID}&completed={isCompleted.ToString().ToLower()}");
            
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Error");
            
            
            string message = await responseMessage.Content.ReadAsStringAsync();
            
            List<Todo> result = JsonSerializer.Deserialize<List<Todo>>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
        }

        public async Task AddTodoAsync(Todo todo)
        {
            string todoAsJson = JsonSerializer.Serialize(todo);
            HttpContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/todos", content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task RemoveTodoAsync(int todoId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/todos/{todoId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task UpdateAsync(Todo todo)
        {
            string todoAsJson = JsonSerializer.Serialize(todo);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/todos/{todo.TodoId}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            };
        }

       

        public void AddAdult(Adult adult)
        {
            throw new NotImplementedException();
        }

        public User ValisateUser(string userName, string Password)
        {
            throw new NotImplementedException();
        }

        Task IUserService.RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailRegistered(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.ValisateUser(string userName, string Password)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/adul")
                GetAsync($"{uri}/todos?userId={UserID}&completed={isCompleted.ToString().ToLower()}");
            throw new NotImplementedException();
        }

        public Task<Adult> AddAdultAsync(Adult adult)
        {
            throw new NotImplementedException();
        }
    }
}