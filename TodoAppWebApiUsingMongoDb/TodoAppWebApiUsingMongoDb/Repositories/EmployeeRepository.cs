using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppWebApiUsingMongoDb.Models;

namespace TodoAppWebApiUsingMongoDb.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public override IMongoCollection<Employee> GetTable()
        {
            return MongoDatabase.GetCollection<Employee>("Employees");
        }
    }
}
