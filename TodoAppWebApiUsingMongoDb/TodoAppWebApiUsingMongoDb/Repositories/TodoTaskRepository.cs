using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppWebApiUsingMongoDb.Models;

namespace TodoAppWebApiUsingMongoDb.Repositories
{
    public class TodoTaskRepository : Repository<TodoTask>
    {
        public override IMongoCollection<TodoTask> GetTable()
        {
            return MongoDatabase.GetCollection<TodoTask>("TodoTasks");
        }
    }
}
