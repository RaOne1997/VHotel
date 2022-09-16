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
    public class HotelAmenitiesLinkDTOesController : ControllerBase
    {
        private readonly ICrudeServices<HotelAmenitiesLinkDTO> _crudeservices;

        public HotelAmenitiesLinkDTOesController(ICrudeServices<HotelAmenitiesLinkDTO> crudeservices)
        {
            _crudeservices = crudeservices;
        }

        // GET: api/HotelAmenitiesLinkDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelAmenitiesLinkDTO>>> GetHotelAmenitiesLinkDTO()
        {
          try
            {
               var HotelAmenitiesLink=  await _crudeservices.GetAllAsync();
                if (HotelAmenitiesLink.Count == 0)
                {
                    return BadRequest("No record Found");
                }
                return Ok(HotelAmenitiesLink);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/HotelAmenitiesLinkDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelAmenitiesLinkDTO>> GetHotelAmenitiesLinkDTO(int? id)
        {
            try
            {
                var HotelAmenitiesLink = await _crudeservices.GetByIdAsync((int)id);
                if (HotelAmenitiesLink==null)
                {
                    return BadRequest("No record Found");
                }
                return Ok(HotelAmenitiesLink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/HotelAmenitiesLinkDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutHotelAmenitiesLinkDTO(HotelAmenitiesLinkDTO hotelAmenitiesLinkDTO)
        {
            try
            {
                await _crudeservices.UpdateAsync(hotelAmenitiesLinkDTO);
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/HotelAmenitiesLinkDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAmenitiesLinkDTO>> PostHotelAmenitiesLinkDTO(HotelAmenitiesLinkDTO hotelAmenitiesLinkDTO)
        {
            try
            {
                await _crudeservices.CreateAsync(hotelAmenitiesLinkDTO);

                return CreatedAtAction("GetHotelAmenitiesLinkDTO", new { id = hotelAmenitiesLinkDTO.ID }, hotelAmenitiesLinkDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/HotelAmenitiesLinkDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAmenitiesLinkDTO(int? id)
        {
            try
            {
                if(await _crudeservices.Exists((int)id))
                {
                    await _crudeservices.DeleteAsync((int)id);
                    return Ok("Deleted");
                }
                return BadRequest("NO record Found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
        }

        
    }
}
