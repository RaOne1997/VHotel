using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.Services.Interface;
using VHotel.DataAccess.DTo;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICrudeServices<CustomersDTO> _airportServices;

        public CustomersController(ICrudeServices<CustomersDTO> airportServices)
        {
            _airportServices = airportServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersDTO>>> GetAmenuitiesDTO()
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
        public async Task<ActionResult<CustomersDTO>> GetAmenuitiesDTO(int? id)
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
        public async Task<IActionResult> PutAmenuitiesDTO([FromForm]CustomersDTO customersDTO)
        {

            try
            {
                await _airportServices.UpdateAsync(customersDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e);
            }


        }

        [HttpPost]
        public async Task<ActionResult<CustomersDTO>> PostAmenuitiesDTO([FromForm]CustomersDTO customersDTO)
        {
            try
            {
                await _airportServices.CreateAsync(customersDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = customersDTO.ID }, customersDTO);

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
