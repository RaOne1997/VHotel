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
    public class FlightDTOesController : ControllerBase
    {
       private readonly ICrudeServices<FlightDTO> _flightServices;
        //private readonly ICrudeServices<> _flightServices;
   

        public FlightDTOesController(ICrudeServices<FlightDTO> flightServices)
        {
            _flightServices = flightServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> GetAmenuitiesDTO()
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
        public async Task<ActionResult<FlightDTO>> GetAmenuitiesDTO(int? id)
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
        public async Task<IActionResult> PutAmenuitiesDTO([FromForm] FlightDTO flightDTO)
        {

            try
            {
                await _flightServices.UpdateAsync(flightDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }


        }

        [HttpPost]
        public async Task<ActionResult<FlightDTO>> PostAmenuitiesDTO([FromForm] FlightDTO flightDTO)
        {
            try
            {
                await _flightServices.CreateAsync(flightDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = flightDTO.ID }, flightDTO);

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

     
     
    }
}
