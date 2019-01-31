using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Common.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoContext _context;

        public TodoRepository(ITodoContext context)
        {
            _context = context;
        }

        public async Task Create(Todo todoToCreate)
        {
            try
            {
                await _context.Todos.InsertOneAsync(todoToCreate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var filter = Builders<Todo>.Filter.Eq(x => x.Id, id);
                var deletedResult = await _context.Todos.DeleteOneAsync(filter);
                return deletedResult.IsAcknowledged && (deletedResult.DeletedCount > 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todos.Find(_ => true).ToListAsync();
        }

        public async Task<long> GetNextId()
        {
            return await _context.Todos.CountDocumentsAsync(new BsonDocument()) +1;
        }

        public async Task<Todo> GetTodo(long id)
        {
            try
            {
                var filter = Builders<Todo>.Filter.Eq(x => x.Id, id);
                return await _context.Todos.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Update(Todo todo)
        {
            try
            {
                var updatedResult = await _context.Todos.ReplaceOneAsync(filter: x => x.Id == todo.Id, replacement: todo);
                return updatedResult.IsAcknowledged && (updatedResult.ModifiedCount > 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
