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
    public class AirportDTOesController : ControllerBase
    {
       
        private readonly ICrudeServices<AirportDTO> _airportServices;

        public AirportDTOesController(ICrudeServices<AirportDTO> airportServices)
        {
            _airportServices = airportServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportDTO>>> GetAmenuitiesDTO()
        {
            try
            {
                var citys = await _airportServices.GetAllAsync();
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
        public async Task<ActionResult<AirportDTO>> GetAmenuitiesDTO(int? id)
        {
            try
            {
                var citys = await _airportServices.GetByIdAsync((int)id);
                return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }
        }

       
        [HttpPut]
        public async Task<IActionResult> PutAmenuitiesDTO(AirportDTO AirportDTO)
        {

            try
            {
                await _airportServices.UpdateAsync(AirportDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }


        }

        [HttpPost]
        public async Task<ActionResult<AirportDTO>> PostAmenuitiesDTO(AirportDTO AirportDTO)
        {
            try
            {
                await _airportServices.CreateAsync(AirportDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = AirportDTO.ID }, AirportDTO);

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
                await _airportServices.DeleteAsync((int)id);
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
