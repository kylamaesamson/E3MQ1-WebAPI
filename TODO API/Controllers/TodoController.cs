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
    }
}
