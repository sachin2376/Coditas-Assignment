using ParkingApp.BLL.Services;
using ParkingApp.Models.Entity;
using ParkingApp.Models.Enum;

namespace ParkingApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private ParkingService parkingService;

        [SetUp]
        public void SetUp()
        {
            parkingService = new ParkingService();
        }
        [Test]
        public void ParkVehicle_ShouldParkInCorrectSlots()
        {
            var car = new Car { CarNumber = "XX 00 XX 0000", CarType = CarType.Hatchback };

            var result = parkingService.ParkVehicle(car);

            Assert.AreEqual(car.CarNumber, ParkingService.Slots.FirstOrDefault(x => x.Car == car).Car.CarNumber);
        }

        [Test]
        public void ParkVehicle_ShouldNotParkVehicle_WhenSlotNotAvailable()
        {
            var car = new Car
            {
                CarNumber = "XXXX",
                CarType = CarType.Sedan_CompactSUV
            };
            ParkingService.Slots.ForEach(x => x.Car = new Car() { CarNumber = "XXXX", CarType = CarType.Hatchback });
            var result = parkingService.ParkVehicle(car);
            Assert.That(ParkingService.Slots.FirstOrDefault(x => x.Car == car), Is.Null);
        }

        [Test]
        public void UnparkVehicle_ShouldUnparkVehicleFromSlot()
        {
            var car = new Car { CarNumber = "XX 00 XX 0000", CarType = CarType.Hatchback };

            parkingService.ParkVehicle(car);
            var parkedSlotNumber = ParkingService.Slots.First(s => s.Car == car).Number;

            var result = parkingService.UnParkVehicle(parkedSlotNumber);
            Assert.That(ParkingService.Slots.First(s => s.Number == parkedSlotNumber).Car, Is.Null);
        }

        [Test]
        public void GetParkingSlotStatus_ShouldGetCorrectStatus()
        {
            var car = new Car { CarNumber = "XX 00 XX 0000", CarType = CarType.Hatchback };
            int slotNumber = 85;
            var parkingSlot = ParkingService.Slots.First(x => x.Number == slotNumber);
            parkingSlot.Car = car;
            parkingSlot.SlotType = ParkingSlotType.Large;

            var response = parkingService.GetParkingSlotStatus(slotNumber);
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(ParkingService.Slots.First(x => x.Number == slotNumber).Car.CarNumber, Is.EqualTo(car.CarNumber));
            });
        }
    }
}