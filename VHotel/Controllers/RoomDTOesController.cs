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
    public class RoomDTOesController : ControllerBase
    {
        private readonly IRoomServices _RoomServices;

        public RoomDTOesController(IRoomServices RoomServices)
        {
            _RoomServices = RoomServices;
        }

        // GET: api/RoomDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoomDTO()
        {

            return await _RoomServices.GetAllAsync();
        }

        // GET: api/RoomDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoomDTO(int id)
        {
            try
            {
                var roomDTO = await _RoomServices.GetByIdAsync(id);
                return roomDTO;
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }



        }

        // PUT: api/RoomDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomDTO(int id, RoomDTO roomDTO)
        {
            try
            {
                if (await _RoomServices.Exists(id))
                {
                    await _RoomServices.UpdateAsync(roomDTO);
                    return Ok("Update");
                }
                else
                {

                    return Ok("NO record Found");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }



        }

        // POST: api/RoomDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoomDTO([FromForm]RoomDTO roomDTO)
        {
            try
            {

                await _RoomServices.CreateAsync(roomDTO);
                return Ok("Insert");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/RoomDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomDTO(int id)
        {
            if (await _RoomServices.Exists(id))
            {
                await _RoomServices.DeleteAsync(id);
                return Ok("Deleted");
            }
            else
            {
                return BadRequest("No record Found");
            }


        }
    }
}

