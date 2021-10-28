using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoWebAPI_withoutBlazor
{
    class Program
    {
        private readonly HttpClient client;
        private string uri = "http://jsonplaceholder.typicode.com";

        public Program()
        {
            client = new HttpClient();
        }
        
        
        public async Task<IList<Todo>> GetTodosAsync(int? UserID, int? Id, bool? isCompleted)
        {

            string finalUri = $"{uri}/Todos";
            
            if (!(UserID == null && Id == null && isCompleted == null)) finalUri += "?";

            if (UserID != null) finalUri += $"userId={UserID}&";
            if (Id != null) finalUri += $"id={Id}&";
            if (isCompleted != null) finalUri += $"completed={isCompleted.ToString().ToLower()}";
            
            Console.WriteLine(finalUri);
            
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/todos?userId={UserID}&completed={isCompleted.ToString().ToLower()}");
            Console.WriteLine(responseMessage.StatusCode);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception("Error");
            
            string message = await responseMessage.Content.ReadAsStringAsync();
            
            List<Todo> result = JsonSerializer.Deserialize<List<Todo>>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
        }
        
        public async Task PostTodoAsync(Todo todo)
        {
            string todoAsJson = JsonSerializer.Serialize(todo);
            HttpContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/todos", content);
            Console.WriteLine(responseMessage.StatusCode);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error, {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }
        
        public async Task DeleteTodoAsync(int todoId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/todos/{todoId}");
            Console.WriteLine(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
        
        static async Task Main(string[] args)
        {
            var program = new Program();

            Todo todo = new Todo()
            {
                userId = 1,
                id = 2,
                completed = true,
                title = "miaw"
            };

            program.GetTodosAsync(null, null, null);
            program.GetTodosAsync(null, null, false);
            program.GetTodosAsync(1, null, true);

            program.PostTodoAsync(todo);
            
          

        }
    }
}