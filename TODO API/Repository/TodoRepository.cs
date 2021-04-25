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
        public async Task Delete(double ID)
        {
            var itemToDelete = await _context.Todos.FindAsync(ID);
            _context.Todos.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> Get(double id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task Update(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
