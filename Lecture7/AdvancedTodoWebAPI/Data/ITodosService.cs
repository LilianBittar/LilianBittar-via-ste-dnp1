using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedTodoWebAPI.Models;

namespace AdvancedTodoWebAPI.Data
{
    public interface ITodosService
    {
        Task<IList<Todo>> GetTodosAsync();
        Task<Todo>   AddTodoAsync(Todo todo);
        Task   RemoveTodoAsync(int todoId);
        Task<Todo>   UpdateAsync(Todo todo);
    }
}