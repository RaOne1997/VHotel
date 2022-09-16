using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.TransactionData;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCustomerDetailDTOesController : ControllerBase
    {

        private readonly ICrudeServices<HotelCustomerDetailDTO> _hotelCustomerDetailServices;

        public HotelCustomerDetailDTOesController(ICrudeServices<HotelCustomerDetailDTO> hotelCustomerDetailServices)
        {
            _hotelCustomerDetailServices = hotelCustomerDetailServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelCustomerDetailDTO>>> GetHotelBookingDTO()
        {

            var hotels = await _hotelCustomerDetailServices.GetAllAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelCustomerDetailDTO>> GetHotelBookingDTO(int? id)
        {
            var hotel = await _hotelCustomerDetailServices.GetByIdAsync((int)id);

            return Ok(hotel);
        }

        [HttpPut]
        public async Task<IActionResult> PutHotelBookingDTO(HotelCustomerDetailDTO hotelHotelCustomerDetailDTO)
        {
            await _hotelCustomerDetailServices.UpdateAsync(hotelHotelCustomerDetailDTO);
            return Ok("Updated");
        }


        [HttpPost]
        public async Task<ActionResult<HotelCustomerDetailDTO>> PostHotelBookingDTO(HotelCustomerDetailDTO hotelHotelCustomerDetailDTO)
        {
            await _hotelCustomerDetailServices.CreateAsync(hotelHotelCustomerDetailDTO);

            return CreatedAtAction("GetHotelBookingDTO", new { id = hotelHotelCustomerDetailDTO.ID }, hotelHotelCustomerDetailDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelBookingDTO(int? id)
        {
            await _hotelCustomerDetailServices.DeleteAsync((int)id);

            return Ok("Deleted");
        }

    }
}
