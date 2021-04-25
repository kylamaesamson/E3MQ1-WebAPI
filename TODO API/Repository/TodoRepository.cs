using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_API.Models;

namespace TODO_API.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<Todo> Create(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }
        public Task Delete(double ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> Get(double id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public Task Update(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
