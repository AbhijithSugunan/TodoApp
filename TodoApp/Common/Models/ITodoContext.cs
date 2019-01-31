using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Common.Models
{
    public interface ITodoContext
    {
        IMongoCollection<Todo> Todos { get; }
    }
}
