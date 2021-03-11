using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtilityService.Models;
using UtilityService.Services;

namespace UtilityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoItemsController(TodoService todoService)
        {
            _todoService = todoService;
        }


        /// <summary>
        /// Get All Todo Items
        /// </summary>
        /// <returns> Todo Items </returns>
        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todos = await _todoService.GetAllTodos();
            return Ok(todos);
        }

        // GET: api/TodoItems/{id}
        /// <summary>
        /// Get Todo Item By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Todo Item By Id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _todoService.GetTodoItem(id);
            if(todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        // PUT: api/TodoItems/5
        /// <summary>
        /// Put Todo Item By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItem"></param>
        /// <returns> Todo Item By ID</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            await _todoService.PutTodoItem(id, todoItem);
            return NoContent();
        }

        // POST: api/TodoItems
        /// <summary>
        /// Post Todo Item By ID
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns> Post Item By Id </returns>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            var result = await _todoService.PostTodoItem(todoItem);
            return CreatedAtAction("GetTodoItem", new { id = result.Id }, result);
        }

        // DELETE: api/TodoItems/{id}
        /// <summary>
        /// Delete item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Delete Item By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
           await _todoService.DeleteTodoItem(id);
           return NoContent();

        }

    }
}
