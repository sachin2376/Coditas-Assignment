using ParkingApp.Models.Enum;

namespace ParkingApp.Models.Entity
{
    public class ParkingSlot
    {
        public ParkingSlotType SlotType { get; set; }
        public Car? Car { get; set; }
        public int Number { get; set; }
    }
}
