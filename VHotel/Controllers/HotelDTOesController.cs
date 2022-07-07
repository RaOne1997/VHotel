using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDTOesController : ControllerBase
    {
        private readonly VhotelsSQLContex _context;

        public HotelDTOesController(VhotelsSQLContex context)
        {
            _context = context;
        }

        // GET: api/HotelDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotelDTO()
        {
            return null;
            //return await _context.ToListAsync();
        }

        // GET: api/HotelDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotelDTO(int? id)
        {
        

            return null;
        }

        // PUT: api/HotelDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelDTO(int? id, HotelDTO hotelDTO)
        {
            if (id != hotelDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                
            }

            return NoContent();
        }

        // POST: api/HotelDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotelDTO(HotelDTO hotelDTO)
        {
      

            return CreatedAtAction("GetHotelDTO", new { id = hotelDTO.ID }, hotelDTO);
        }

        // DELETE: api/HotelDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDTO(int? id)
        {
            

            return NoContent();
        }

      
    }
}
