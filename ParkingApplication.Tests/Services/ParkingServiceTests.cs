using NUnit.Framework;
using NUnit.Framework.Legacy;
using ParkingApp.BLL.Interfaces;
using ParkingApp.BLL.Services;
using ParkingApp.Models.Entity;
using ParkingApp.Models.Enum;

namespace ParkingApplication.Tests.Services
{
    [TestFixture]
    public class ParkingServiceTests
    {
        private IParkingService parkingService;
        [SetUp]
        public void SetUp()
        {
            parkingService = new ParkingService();
        }
        [Test]
        public void ParkVehicleService_ShouldParkInCorrectSlots()
        {
            var vehicle = new Car { CarNumber = "XX 00 XX 0000",CarType = CarType.Hatchback };

            var result = parkingService.ParkVehicle(vehicle);

            ClassicAssert.AreEqual(vehicle.CarNumber,ParkingService.Slots.FirstOrDefault(x => x.Car == vehicle).Car.CarNumber);
        }
    }
}
