using System.Collections.Generic;
using System.Threading.Tasks;
using TodoTutorial3._0.Models;


namespace TodoTutorial3._0.Data
{
    public interface ITodoData
    {
        Task<IList<Todo>> GetTodosAsync(int UserID, bool isCompleted);
        Task AddTodoAsync(Todo todo);
        Task RemoveTodoAsync(int todoId);
        Task UpdateAsync(Todo todo);
       
    }
}