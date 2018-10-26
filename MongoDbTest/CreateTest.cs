using System;
using Domain;
using Xunit;
using Repository;

namespace MongoDbTest
{
    public class CreateTest
    {
        private IRepository _repository = new MongoDbRepository();

        [Fact]
        public void CreateCar()
        {
            var vehicle = NewCar();

            var newVehicle = _repository.Create(vehicle);

            Assert.NotNull(newVehicle);
        }

        [Fact]
        public void CreateBoat()
        {
            var vehicle = NewBoat();

            var newVehicle = _repository.Create(vehicle);

            Assert.NotNull(newVehicle);
        }

        public Car NewCar()
        {
            return new Car()
            {
                Make = "Car",
                CreateTime = DateTime.Now,
                Year = 2018,
                Wheels = 4
            };
        }
        
        public Boat NewBoat()
        {
            return new Boat()
            {
                Make = "Car",
                CreateTime = DateTime.Now,
                Year = 2018,
                Segment = "Segment"
            };
        }
    }
}
