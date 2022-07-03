using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess;
using staticclassmodel.DataAccess.Model.Master;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMastersController : ControllerBase
    {
        private readonly VhotelsSQLContex _context;

        public CityMastersController(VhotelsSQLContex context)
        {
            _context = context;
        }

        // GET: api/CityMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityMaster>>> GetcityMasters()
        {
          if (_context.cityMasters == null)
          {
              return NotFound();
          }
            return await _context.cityMasters.Include("State")
                .OrderBy(x=>x.Id)
                .ToListAsync();
        }

        // GET: api/CityMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityMaster>> GetCityMaster(int id)
        {
          if (_context.cityMasters == null)
          {
              return NotFound();
          }
            var cityMaster = await _context.cityMasters
                .Include("State")
                .OrderBy(x => x.Id)
                .SingleAsync(x=>x.Id==id);

            if (cityMaster == null)
            {
                return NotFound();
            }

            return cityMaster;
        }

        // PUT: api/CityMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityMaster(int id, CityMaster cityMaster)
        {
            if (id != cityMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CityMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityMaster>> PostCityMaster(CityMasterdto cityMaster)
        {
          if (_context.cityMasters == null)
          {
              return Problem("Entity set 'VhotelsSQLContex.cityMasters'  is null.");
          }

            var city = new CityMaster
            {
                CityName = cityMaster.CityName,
                stateRefID = cityMaster.stateRefID

            };
            _context.cityMasters.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityMaster", new { id = city.Id }, cityMaster);
        }

        // DELETE: api/CityMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityMaster(int id)
        {
            if (_context.cityMasters == null)
            {
                return NotFound();
            }
            var cityMaster = await _context.cityMasters.FindAsync(id);
            if (cityMaster == null)
            {
                return NotFound();
            }

            _context.cityMasters.Remove(cityMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityMasterExists(int id)
        {
            return (_context.cityMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
