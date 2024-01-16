using ParkingApp.BLL.Interfaces;
using ParkingApp.Models.Entity;
using ParkingApp.Models.Enum;

namespace ParkingApp.BLL.Services
{
    public class ParkingService : IParkingService
    {
        public static List<ParkingSlot> Slots;

        public ParkingService()
        {
            Slots ??= InitializeParkingSlots();
        }

        public static List<ParkingSlot> InitializeParkingSlots()
        {
            var slots = new List<ParkingSlot>();
            for (int i = 1; i <= 100; i++)
            {
                if (i<50)
                {
                    slots.Add(new ParkingSlot()
                    {
                        Number = i,
                        SlotType = ParkingSlotType.Small,
                        Car = null
                    });
                }
                else if (i<80)
                {
                    slots.Add(new ParkingSlot()
                    {
                        Number = i,
                        SlotType = ParkingSlotType.Medium,
                        Car = null
                    });
                }
                else
                {
                    slots.Add(new ParkingSlot()
                    {
                        Number = i,
                        SlotType = ParkingSlotType.Large,
                        Car = null
                    });
                }
            }
            return slots;
        }

        public object ParkVehicle(Car car)
        {
            var parkingSlot = GetAppropriateParkingSlot(car.CarType);
            if (parkingSlot == null)
            {
                return new
                {
                    errorMsg = "Slot not available",
                    parkingStatus = Status.UnParked.ToString()
                };
            }
            parkingSlot.Car = car;
            Console.WriteLine($" {parkingSlot.Car} : {parkingSlot.Car.CarNumber} Parked at slot {parkingSlot.Number}");
            parkingSlot.SlotType = GetParkedSlotType(parkingSlot.Number);
            return new
            {
                slotNumber = parkingSlot.Number,
                vehicleType = car.CarType.ToString(),
                vehicleNumber = car.CarNumber,
                parkingStatus = Status.Parked.ToString()
            };
        }

        public string UnParkVehicle(int number)
        {
            var slot = Slots.FirstOrDefault(x => x.Number==number);
            if (slot == null || slot.Car == null)
            {
                return $"slot {number} is empty";
            }
            Console.WriteLine($" {slot.Car} : {slot.Car.CarNumber} Unparked from parking!");
            slot.Car = null;
            return $"Slot {number} released";
        }

        public ParkingSlot? GetParkingSlotStatus(int number)
        {
            var response = Slots.FirstOrDefault(x => x.Number == number);
            return response;
        }

        private static ParkingSlot? GetAppropriateParkingSlot(CarType carType)
        {
            return carType switch
            {
                CarType.LargeSUV => Slots.FirstOrDefault(x => x.Car == null && x.Number > 80),
                CarType.Sedan_CompactSUV => Slots.FirstOrDefault(x => x.Car == null && x.Number > 50),
                CarType.Hatchback => Slots.FirstOrDefault(x => x.Car == null),
                _ => throw new Exception("Vehicle not allowed"),
            };
        }
        private static ParkingSlotType GetParkedSlotType(int Number)
        {
            if (Number <0 || Number > 100)
                throw new Exception("Invalid Parking Slot Number Provided");
            if (Number>80) return ParkingSlotType.Large;
            if (Number>50) return ParkingSlotType.Medium;
            return ParkingSlotType.Small;
        }
    }
}
