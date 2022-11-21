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
using VHotel.DataAccess.DTo;

namespace MakeMuTrip.Controllers
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
        public async Task<ActionResult<IEnumerable<AirportDTO>>> AirportList()
        {
            try
            {
                var citys = await _airportServices.GetAllAsync();
                if (citys.Count == 0)
                {

                    return Ok("NO record Found");
                }
                else
                    return citys;
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
        public async Task<ActionResult<ReturnResult>> PutAmenuitiesDTO([FromForm]AirportDTO AirportDTO)
        {

            try
            {

            
                await _airportServices.UpdateAsync(AirportDTO);
                return new ReturnResult { isOk=true,Result="update"};
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return new ReturnResult { isOk = false, Result = e.Message };
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
