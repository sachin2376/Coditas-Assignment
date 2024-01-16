using ParkingApp.Models.Enum;

namespace ParkingApp.Models.Dto
{
    public class VehicleRequestDto
    {
        public CarType CarType { get; set; }
        public string CarNumber { get; set; }
    }
}
