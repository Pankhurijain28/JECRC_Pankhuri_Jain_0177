using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL TASKS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        // ADD TASK
        [HttpPost]
        public async Task<ActionResult<TodoItem>> AddTodo(TodoItem todo)
        {
            if (string.IsNullOrEmpty(todo.TaskName))
                return BadRequest("Task name cannot be empty");

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
        }

        // DELETE TASK
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // UPDATE TASK
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, TodoItem updated)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            if (!string.IsNullOrEmpty(updated.TaskName))
                todo.TaskName = updated.TaskName;

            todo.IsCompleted = updated.IsCompleted;

            if (!string.IsNullOrEmpty(updated.Priority))
                todo.Priority = updated.Priority;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}