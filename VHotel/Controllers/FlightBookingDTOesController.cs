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
    public class FlightBookingDTOesController : ControllerBase
    {
        private readonly ICrudeServices<FlightBookingDTO> _flightBookingservices;

        public FlightBookingDTOesController(ICrudeServices<FlightBookingDTO> flightBookingservices)
        {
            _flightBookingservices = flightBookingservices;
        }

        // GET: api/AmenuitiesDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightBookingDTO>>> GetAmenuitiesDTO()
        {
            try
            {
                var citys = await _flightBookingservices.GetAllAsync();
                if (citys.Count == 0)
                {

                    return Ok("NO record Found");
                }
                else
                    return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }
        }

        // GET: api/AmenuitiesDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightBookingDTO>> GetAmenuitiesDTO(int? id)
        {
            try
            {
                var citys = await _flightBookingservices.GetByIdAsync((int)id);
                return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }
        }

        // PUT: api/AmenuitiesDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAmenuitiesDTO(FlightBookingDTO flightBookingDTO)
        {

            try
            {
                await _flightBookingservices.UpdateAsync(flightBookingDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }


        }

        // POST: api/AmenuitiesDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightBookingDTO>> PostAmenuitiesDTO(FlightBookingDTO flightBookingDTO)
        {
            try
            {
                await _flightBookingservices.CreateAsync(flightBookingDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = flightBookingDTO.ID }, flightBookingDTO);

            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in Adding" + e);
            }


        }

        // DELETE: api/AmenuitiesDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenuitiesDTO(int? id)
        {
            try
            {
                await _flightBookingservices.DeleteAsync((int)id);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in Delete" + ex);
            }


        }



    }
}
