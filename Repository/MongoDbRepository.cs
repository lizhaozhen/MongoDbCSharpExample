using System;
using System.Collections.Generic;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository
{
    public class MongoDbRepository : IRepository
    {
        protected static readonly MongoClient client = new MongoClient("mongodb://localhost:27017");

        public Vehicle Create(Vehicle vehicle)
        {
            var database = client.GetDatabase("MiniCarSales");
            var collection = database.GetCollection<Vehicle>("Vehicles");
            collection.InsertOne(vehicle);
            return vehicle;
        }

        public void Delete(string id)
        {
            var database = client.GetDatabase("MiniCarSales");
            var collection = database.GetCollection<Vehicle>("Vehicles");

            var objectId = new ObjectId(id);
            var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, objectId);

            collection.DeleteOne(filter);
        }

        public IEnumerable<Vehicle> Get()
        {
            var database = client.GetDatabase("MiniCarSales");
            var collection = database.GetCollection<Vehicle>("Vehicles");
            
            return collection.Find(x => true).ToList();
        }

        public Vehicle Get(string id)
        {
            var database = client.GetDatabase("MiniCarSales");
            var collection = database.GetCollection<Vehicle>("Vehicles");

            var objectId = new ObjectId(id);
            var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, objectId);

            return collection.Find(filter).FirstOrDefault();
        }

        public Vehicle Put(Vehicle vehicle)
        {
            var database = client.GetDatabase("MiniCarSales");
            var collection = database.GetCollection<Vehicle>("Vehicles");

            var objectId = vehicle.Id;
            var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, objectId);

            collection.ReplaceOne(filter, vehicle);
            return vehicle;
        }
    }
}
