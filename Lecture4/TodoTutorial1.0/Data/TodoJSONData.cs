using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TodoTutorial1._0.Models;

namespace TodoTutorial1._0.Data
{
    public class TodoJSONData : ITodoData
    {

        private string todoFile = "todos.json";
        private IList<Todo> todos;

        public TodoJSONData()
        {
            if (!File.Exists(todoFile))
            {
                Seed();
                string todoAsJson = JsonSerializer.Serialize(todos);
                File.WriteAllText(todoFile, todoAsJson);
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                todos = JsonSerializer.Deserialize<List<Todo>>(content);
            }
        }
        
        
        public IList<Todo> GetTodos()
        {
            List<Todo> tmp = new List<Todo>(todos);
            return tmp;
        }

        public void AddTodo(Todo todo)
        {
            todos.Add(todo);
            string todoAsJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(todoFile, todoAsJson);
        }

        private void Seed()
        {
            Todo[] ts =
            {
                new Todo
                {
                    UserId = 1,
                    TodoId = 1,
                    Title = "Do dishes",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 1,
                    TodoId = 2,
                    Title = "walk the dog",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 2,
                    TodoId = 3,
                    Title = "Do dnp homework",
                    IsCompleted = true
                },
                new Todo
                {
                    UserId = 3,
                    TodoId = 4,
                    Title = "Eat breakfast",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 4,
                    TodoId = 5,
                    Title = "Mow lawn",
                    IsCompleted = true
                },
            };
            todos = ts.ToList();
        }
    }
}