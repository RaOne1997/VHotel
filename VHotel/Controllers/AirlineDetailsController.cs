using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.Services.Interface;
using MakeMuTrip.DataAccess.DTo;

namespace MakeMuTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineDetailsController : ControllerBase
    {
        private readonly ICrudeServices<AirlineDetailsDTO> _airlinrtServices;

        public AirlineDetailsController(ICrudeServices<AirlineDetailsDTO> airlinrServices)
        {
            _airlinrtServices = airlinrServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineDetailsDTO>>> GetAmenuitiesDTO()
        {
            try
            {
                var citys = await _airlinrtServices.GetAllAsync();
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
        public async Task<ActionResult<AirlineDetailsDTO>> GetAmenuitiesDTO(int? id)
        {
            try
            {
                var citys = await _airlinrtServices.GetByIdAsync((int)id);
                return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutAmenuitiesDTO([FromForm]AirlineDetailsDTO AirlineDetailsDTO)
        {

            try
            {
                await _airlinrtServices.UpdateAsync(AirlineDetailsDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }


        }

        [HttpPost]
        public async Task<ActionResult<AirlineDetailsDTO>> PostAmenuitiesDTO([FromForm] AirlineDetailsDTO AirlineDetailsDTO)
        {
            try
            {
                await _airlinrtServices.CreateAsync(AirlineDetailsDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = AirlineDetailsDTO.ID }, AirlineDetailsDTO);

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
                await _airlinrtServices.DeleteAsync((int)id);
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
