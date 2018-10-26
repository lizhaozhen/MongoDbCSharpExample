using System;
using System.Linq;
using Domain;
using Repository;
using Xunit;

namespace MongoDbTest
{
    public class GetTest
    {
        private IRepository _repository = new MongoDbRepository();

        [Fact]
        public void GetCarById()
        {
            var vehicle = _repository.Get("5bd252dd94928c1ec82ab469");

            Assert.NotNull(vehicle);
            Assert.True(vehicle.GetType() == typeof(Car));
        }

        [Fact]
        public void GetBoatById()
        {
            var vehicle = _repository.Get("5bd253bfdd7fe022f6a871f5");

            Assert.NotNull(vehicle);
            Assert.True(vehicle.GetType() == typeof(Boat));
        }

        [Fact]
        public void Gets()
        {
            var vehicles = _repository.Get();

            Assert.True(vehicles.ToList().Count > 0);
        }
    }
}
