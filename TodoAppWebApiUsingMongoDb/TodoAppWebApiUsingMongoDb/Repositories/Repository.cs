using Betfair_API_NG.TO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppWebApiUsingMongoDb.Models;

namespace TodoAppWebApiUsingMongoDb.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        public MongoClient Client { get { return new MongoClient("mongodb://localhost"); } }

        public void Add(T tEntity)
        {
            GetTable().InsertOne(tEntity);
        }

        public void Delete(string id)
        {
           GetTable().DeleteOne(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)));
        }

        bool Exists(string id)
        {
            var _database = Client.GetDatabase("MyAppDb");
            var _table = _database.GetCollection<Employee>("Employees");
            var _queryable = _table.AsQueryable();
            return _queryable.Any(u => u.Id == id);
        }

        public List<T> GetAll()
        {
            return GetTable().Find(Builders<T>.Filter.Empty).ToList();
        }

        public T GetById(string id)
        {
            return GetTable().Find(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefault();
        }

        public void Replace(T tEntity)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(tEntity.Id));
            GetTable().ReplaceOne(filter, tEntity);
        }
        
        protected IMongoDatabase MongoDatabase
        {
            get { return Client.GetDatabase("MyAppDb"); }
        }

        public abstract IMongoCollection<T> GetTable();
    }
}
