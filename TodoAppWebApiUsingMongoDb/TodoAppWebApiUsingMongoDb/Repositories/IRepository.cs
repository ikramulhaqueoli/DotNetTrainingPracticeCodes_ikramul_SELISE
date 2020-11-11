using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppWebApiUsingMongoDb.Models;

namespace TodoAppWebApiUsingMongoDb.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T tEntity);
        void Delete(string id);
        void Update(T tEntity);
        T GetById(string id);
        List<T> GetAll();
        IMongoCollection<T> GetTable();
    }
}
