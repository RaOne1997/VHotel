using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;
using VHotel.Services.Interface;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingDTOesController : ControllerBase
    {
        private readonly ICrudeServices<HotelBookingDTO>  _hotelbookingServices;

        public HotelBookingDTOesController(ICrudeServices<HotelBookingDTO> hotebookinglServices)
        {
            _hotelbookingServices = hotebookinglServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelBookingDTO>>> GetHotelBookingDTO()
        {

            var hotels = await _hotelbookingServices.GetAllAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelBookingDTO>> GetHotelBookingDTO(int? id)
        {
            var hotel = await _hotelbookingServices.GetByIdAsync((int)id);

            return Ok(hotel);
        }

        [HttpPut]
        public async Task<IActionResult> PutHotelBookingDTO(HotelBookingDTO hotelBookingDTO)
        {
            await _hotelbookingServices.UpdateAsync(hotelBookingDTO);
            return Ok("Updated");
        }


        [HttpPost]
        public async Task<ActionResult<HotelBookingDTO>> PostHotelBookingDTO(HotelBookingDTO hotelBookingDTO)
        {
            await _hotelbookingServices.CreateAsync(hotelBookingDTO);

            return CreatedAtAction("GetHotelBookingDTO", new { id = hotelBookingDTO.ID }, hotelBookingDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelBookingDTO(int? id)
        {
            await _hotelbookingServices.DeleteAsync((int)id);

            return Ok("Deleted");
        }

    }
}
