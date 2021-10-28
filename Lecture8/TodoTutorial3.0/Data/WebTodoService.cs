using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoTutorial3._0.Models;

namespace TodoTutorial3._0.Data
{
    public class WebTodoService : ITodoData
    {

        private string uri = "http://jsonplaceholder.typicode.com";

        private readonly HttpClient client;

        public WebTodoService()
        {
            client = new HttpClient();
        }
        
        
        public async Task<IList<Todo>> GetTodosAsync(int UserID, bool isCompleted)
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
    }
}