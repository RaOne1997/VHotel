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
    public class FlightScheduleDTOesController : ControllerBase
    {
      private readonly IFilightShedulServices _flightServices;
        //private readonly ICrudeServices<FlightScheduleDTO> _flightServices;

        public FlightScheduleDTOesController(IFilightShedulServices flightServices)
        {
            _flightServices = flightServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightScheduleDTO>>> GetAmenuitiesDTO()
        {
            try
            {
                var citys = await _flightServices.GetAllAsync();
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


        [HttpGet("{id}")]
        public async Task<ActionResult<FlightScheduleDTO>> GetAmenuitiesDTO(int? id)
        {
            try
            {
                var citys = await _flightServices.GetByIdAsync((int)id);
                return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutAmenuitiesDTO(FlightScheduleDTO flightScheduleDTO)
        {

            try
            {
                await _flightServices.UpdateAsync(flightScheduleDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }


        }

        [HttpPost]
        public async Task<ActionResult<FlightScheduleDTO>> PostAmenuitiesDTO(FlightScheduleDTO flightScheduleDTO)
        {
            try
            {
                await _flightServices.CreateAsync(flightScheduleDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = flightScheduleDTO.ID }, flightScheduleDTO);

            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in Adding" + e);
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenuitiesDTO(int? id)
        {
            try
            {
                await _flightServices.DeleteAsync((int)id);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in Delete" + ex);
            }


        }
        [HttpGet("{locationFrom}/{locationTo}/{date}")]
        public async Task<ActionResult<List<FlightScheduleDTO>>> GetFlight(string locationFrom, string locationTo, DateTime date)
        {
            var axp = await _flightServices.SearchFlight(locationFrom, locationTo, date);
            return axp;
        }

    }
}
