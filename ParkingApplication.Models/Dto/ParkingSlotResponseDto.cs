using Newtonsoft.Json;
using ParkingApp.Models.Entity;

namespace ParkingApp.Models.Dto
{
    public class ParkingSlotResponseDto
    {
        [JsonProperty("parking_slot_type")]
        public string SlotType { get; set; }
        [JsonProperty("car")]
        public Car Car { get; set; }

        [JsonProperty("slot_number")]
        public int Number { get; set; }
    }
}
