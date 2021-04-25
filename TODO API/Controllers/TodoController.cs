using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO_API.Models;
using TODO_API.Repository;

namespace TODO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _todoRepository.Get();
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodos([FromBody] Todo todo)
        {
            var newTodo = await _todoRepository.Create(todo);
            return CreatedAtAction(nameof(GetTodos), new { ID = newTodo.ID }, newTodo);
        }

        [HttpPut]
        public async Task<ActionResult> PutTodos([FromBody] Todo todo)
        {
            await _todoRepository.Update(todo);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Todo todo)
        {
            var itemToDelete = await _todoRepository.Get(todo.ID);
            if (itemToDelete == null) return NotFound();

            await _todoRepository.Delete(itemToDelete.ID);
            return NoContent();
        }

    }
}
