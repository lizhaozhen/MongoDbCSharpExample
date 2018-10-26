using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Car), typeof(Boat))]
    public abstract class Vehicle
    {
        public ObjectId Id {get;set;}
        public string Make {get;set;}
        public int Year { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
