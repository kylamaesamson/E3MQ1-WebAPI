using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_API.Models;

namespace TODO_API.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> Get();
        Task<Todo> Get(double id);
        Task<Todo> Create(Todo todo);
        Task Update(Todo todo);
        Task Delete(double ID);
    }
}
