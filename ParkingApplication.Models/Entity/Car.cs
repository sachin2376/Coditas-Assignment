using ParkingApp.Models.Enum;

namespace ParkingApp.Models.Entity
{
    public interface IVehicle
    {
        public CarType CarType { get; set; }
    }

    public class Car : IVehicle
    {
        public string CarNumber { get; set; }
        public CarType CarType { get; set; }
    }
}
