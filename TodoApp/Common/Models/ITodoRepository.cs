using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Common.Models
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodos();

        Task<Todo> GetTodo(long id);

        Task Create(Todo todoToCreate);

        Task<bool> Update(Todo todo);

        Task<bool> Delete(long id);

        Task<long> GetNextId();
    }
}
