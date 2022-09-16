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
    [Route("api/[controller]")]
    [ApiController]
    public class AmenuitiesDTOesController : ControllerBase
    {
        private readonly ICrudeServices<AmenuitiesDTO> _amenuitiesServices;

        public AmenuitiesDTOesController(ICrudeServices<AmenuitiesDTO> amenuitiesServices)
        {
            _amenuitiesServices = amenuitiesServices;
        }

        // GET: api/AmenuitiesDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenuitiesDTO>>> GetAmenuitiesDTO()
        {
            try
            {
                var citys = await _amenuitiesServices.GetAllAsync();
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
               return Problem("Error in GetAll"+e);
            }
        }

        // GET: api/AmenuitiesDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenuitiesDTO>> GetAmenuitiesDTO(int? id)
        {
            try
            {
                var citys = await _amenuitiesServices.GetByIdAsync((int)id);
                return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
               return Problem("Error in GetAll"+e);
            }
        }

        // PUT: api/AmenuitiesDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAmenuitiesDTO( AmenuitiesDTO amenuitiesDTO)
        {

            try
            {
                 await _amenuitiesServices.UpdateAsync(amenuitiesDTO);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
               return Problem("Error in GetAll"+e);
            }

            
        }

        // POST: api/AmenuitiesDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AmenuitiesDTO>> PostAmenuitiesDTO(AmenuitiesDTO amenuitiesDTO)
        {
            try
            {
                await _amenuitiesServices.CreateAsync(amenuitiesDTO);
                return CreatedAtAction("GetAmenuitiesDTO", new { id = amenuitiesDTO.ID }, amenuitiesDTO);
               
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in Adding"+e);
            }

         
        }

        // DELETE: api/AmenuitiesDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenuitiesDTO(int? id)
        {
            try
            {
                await _amenuitiesServices.DeleteAsync((int)id);
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
