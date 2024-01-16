using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.BLL.Interfaces;
using ParkingApp.Models.Dto;
using ParkingApp.Models.Entity;

namespace ParkingApp.API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class VehicleController(IParkingService securityGuard, IMapper mapper) : Controller
    {
        private readonly IParkingService _securityGuard = securityGuard;
        private readonly IMapper _mapper = mapper;

        [HttpPost("UnparkVehicle/{slotNumber:int}")]
        public IActionResult UnParkVehicle(int slotNumber)
        {
            var response = _securityGuard.UnParkVehicle(slotNumber);
            return Ok(response);
        }

        [HttpPost("ParkVehicle")]
        public IActionResult ParkVehicle([FromBody] VehicleRequestDto request)
        {
            var response = _securityGuard.ParkVehicle(_mapper.Map<Car>(request));
            return Ok(response);
        }

        [HttpGet("GetStatus/{number:int}")]
        public IActionResult GetParkingSlotStatus(int number)
        {
            var response = _securityGuard.GetParkingSlotStatus(number);
            if(response!=null)
            {
                return Ok(_mapper.Map<ParkingSlot,ParkingSlotResponseDto>(response));
            }
            return NotFound($"Invalid slot number! only 1 to 100 parking slots are available");
        }
    }
}
