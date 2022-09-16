using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.Services;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FlightBookingDTOesController : ControllerBase
    {
        private readonly IFlightBookingServices _flightBookingservices;

        public FlightBookingDTOesController(IFlightBookingServices flightBookingservices)
        {
            _flightBookingservices = flightBookingservices;
        }

        // GET: api/AmenuitiesDTOes
        [HttpGet]
        public async Task<ActionResult<FlightBookingDTO>> GetFlightBookingDTO()
        {
            try
            {
                var citys = await _flightBookingservices.getALlDec();
              
                    return citys;
            }
            catch (Exception e) { 
         
                return Problem("Error in GetAll" + e);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<FlightBookingDTO>>> GetFlightBookingAllDTO()
        {
            try
            {
                var citys = await _flightBookingservices.GetAllAsync();
            
                return citys;
            }
            catch (Exception e)
            {
               
                return Problem("Error in GetAll" + e);
            }
        }


        // GET: api/AmenuitiesDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightBookingDTO>> GetFlightBookingDTO(int? id)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingFlightDTO>> GetFlighO(int? id)
        {
            try
            {
                var citys = await _flightBookingservices.GetByIdSheduD((int)id);
                return citys;
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightBookingDTO>> GetFlightBookingShedul(int? id)
        {
            try
            {
                var citys = await _flightBookingservices.GetByIdShedulID((int)id);
                return citys;
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
        public async Task<IActionResult> PutFlightBookingDTO(FlightBookingInputDTO flightBookingDTO)
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
        public async Task<ActionResult<FlightBookingDTO>> PostFlightBookingDTO(FlightBookingInputDTO flightBookingDTO)
        {
            try
            {
                flightBookingDTO.BookingTimeStamp = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                await _flightBookingservices.CreateAsync(flightBookingDTO);
                return CreatedAtAction("GetFlightBookingDTO", new { id = flightBookingDTO.ID }, flightBookingDTO);

            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in Adding" + e);
            }


        }

        // DELETE: api/AmenuitiesDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightBookingDTO(int? id)
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
