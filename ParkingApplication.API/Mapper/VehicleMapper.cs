using AutoMapper;
using ParkingApp.Models.Dto;
using ParkingApp.Models.Entity;

namespace ParkingApp.API.Mapper
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper()
        {
            CreateMap<VehicleRequestDto, Car>();
            CreateMap<ParkingSlot, ParkingSlotResponseDto>()
                .ForMember(dest => dest.SlotType, opt => opt.MapFrom(x => x.SlotType.ToString()));
        }
    }
}
