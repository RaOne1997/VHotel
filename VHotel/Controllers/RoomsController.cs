using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly VhotelsSQLContex _context;

        public RoomsController(VhotelsSQLContex context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> Getrooms()
        {
          if (_context.rooms == null)
          {
              return NotFound();
          }
            return await _context.rooms
                .Include("type")
                .ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
          if (_context.rooms == null)
          {
              return NotFound();
          }
         
            var room = await _context.rooms.Include("type").SingleAsync(x=>x.ID==id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<Room>> PostRoom([FromForm] RoomDTO roomdto)
        {
          if (_context.rooms == null)
          {
              return Problem("Entity set 'VhotelsSQLContex.rooms'  is null.");
          }

            await using var memoryStream = new MemoryStream();
            await roomdto.RoomImage.CopyToAsync(memoryStream);
            memoryStream.ToArray();

            var room = new Room
            {
                RoomNumber = roomdto.RoomNumber,
                RoomTypeRefID = roomdto.RoomTypeRefID,
                RoomImage = memoryStream.ToArray(),
                RoomLevel = roomdto.RoomLevel,
                Description = roomdto.Description,


            };
            
            _context.rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.rooms == null)
            {
                return NotFound();
            }
            var room = await _context.rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return (_context.rooms?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
