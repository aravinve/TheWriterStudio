using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityService.Models;

namespace UtilityService.Services
{
    interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodos();

        Task<TodoItem> GetTodoItem(long todoId);

        Task PutTodoItem(long id, TodoItem todoItem);

        Task<TodoItem> PostTodoItem(TodoItem todoItem);

        Task DeleteTodoItem(long id);
    }
}
