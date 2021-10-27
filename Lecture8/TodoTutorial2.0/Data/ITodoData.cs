using System.Collections.Generic;
using TodoTutorial2._0.Models;

namespace TodoTutorial2._0.Data
{
    public interface ITodoData
    {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
    }
}