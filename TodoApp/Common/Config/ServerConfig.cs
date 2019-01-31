using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Common.Config
{
    public class ServerConfig
    {
        public MongoDbConfig MongoConfig { get; set; } = new MongoDbConfig();

    }
}
