using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApp.Common.Config;

namespace TodoApp.Common.Models
{
    public class TodoContext : ITodoContext
    {
        private readonly IMongoDatabase _db;

        public TodoContext(IOptions<MongoDbConfig> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            _db = client.GetDatabase(config.Value.Database);
        }

        public IMongoCollection<Todo> Todos => _db.GetCollection<Todo>("Todos");
    }
}
