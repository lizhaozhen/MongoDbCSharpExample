using System;
using System.Collections.Generic;
using Domain;

namespace Repository
{
    public interface IRepository
    {
        IEnumerable<Vehicle> Get();
        Vehicle Get(string id);
        void Delete(string id);
        Vehicle Create(Vehicle vehicle);
        Vehicle Put(Vehicle vehicle);
    }
}
