using ParkingApp.Models.Dto;
using ParkingApp.Models.Entity;

namespace ParkingApp.BLL.Interfaces
{
    public interface IParkingService
    {
        object ParkVehicle(Car car);
        string UnParkVehicle(int number);
        ParkingSlot? GetParkingSlotStatus(int number);
    }
}
