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

        public List<T> GetAll()
        {
            return GetTable().Find(Builders<T>.Filter.Empty).ToList();
        }

        public T GetById(string id)
        {
            return GetTable().Find(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefault();
        }

        public void Update(T tEntity)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(tEntity.Id));
            var update = Builders<T>.Update.Set("Name", "Ikramul haque chowehury");
            GetTable().UpdateOne(filter, update);
        }

        protected IMongoDatabase MongoDatabase
        {
            get { return Client.GetDatabase("MyAppDb"); }
        }

        public abstract IMongoCollection<T> GetTable();
    }
}
