using System.Collections.Generic;
using TodoTutorial1._0.Models;

namespace TodoTutorial1._0.Data
{
    public interface ITodoData
    {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
        void RemoveTodo(int todoId);
        void Update(Todo todo);
        Todo Get(int Id);
    }
}