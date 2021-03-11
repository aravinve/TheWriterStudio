using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityService.Data;
using UtilityService.Models;

namespace UtilityService.Services
{
    public class TodoService : ITodoService
    {
        private readonly UtilityDBContext _context;

        public TodoService(UtilityDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodos()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItem(long todoId)
        {
            var todoItem = await _context.TodoItems.FindAsync(todoId);
            return todoItem;
        }

        public async Task<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await SaveChangesAsync();
            return todoItem;
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task PutTodoItem(long id, TodoItem todoItem)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            try
            {
                await SaveChangesAsync();
            } catch(DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await SaveChangesAsync();
            }
        }
    }
}
