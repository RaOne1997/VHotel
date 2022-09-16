using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDTOesController : ControllerBase
    {
        private readonly IHotelServices _hotelServices;

        public HotelDTOesController(IHotelServices hotelServices)
        {
            _hotelServices = hotelServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotelDTO()
        {

            var hotels = await _hotelServices.GetAllAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotelDTO(int? id)
        {
            var hotel = await _hotelServices.GetByIdAsync((int)id);

            return Ok(hotel);
        }

        [HttpPut]
        public async Task<IActionResult> PutHotelDTO([FromForm]HotelDTO hotelDTO)
        {
            await _hotelServices.UpdateAsync(hotelDTO);
            return Ok("Updated");
        }


        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotelDTO([FromForm]HotelDTO hotelDTO)
        {
            await _hotelServices.CreateAsync(hotelDTO);

            return CreatedAtAction("GetHotelDTO", new { id = hotelDTO.ID }, hotelDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDTO(int? id)
        {
            await _hotelServices.DeleteAsync((int)id);

            return Ok("Deleted");
        }


    }
}
