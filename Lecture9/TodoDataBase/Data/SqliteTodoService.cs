using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoDataBase.Models;
using TodoDataBase.Persistence;

namespace TodoDataBase.Data {
    public class SqliteTodoService : ITodosService {

        private TodoContext TodoContext;

        public SqliteTodoService(TodoContext todoContext) {
            TodoContext = todoContext;
        }

        public async Task<IList<Todo>> GetTodosAsync() {
            return TodoContext.Todos.ToList();
        }

        public async Task<Todo> AddTodoAsync(Todo todo) {
            TodoContext.Todos.Add(todo);
            return todo;
        }

        public async Task RemoveTodoAsync(int todoId) {
            Todo todo = TodoContext.Todos.Where(todo => todo.TodoId == todoId).First();
            TodoContext.Todos.Remove(todo);
        }

        public async Task<Todo> UpdateAsync(Todo todo) {
            TodoContext.Todos.Update(todo);
            return todo;
        }
    }
}