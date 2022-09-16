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
    public class StateDTOesController : ControllerBase
    {
        private readonly IStateServices _StateServices;

        public StateDTOesController(IStateServices stateServices)
        {
            _StateServices = stateServices;
        }

        // GET: api/StateDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetStateDTO()
        {
            return await _StateServices.GetAllAsync();
        }

        // GET: api/StateDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateDTO>> GetStateDTO(int? id)
        {
            return await _StateServices.GetByIdAsync((int)id);
        }



        // GET: api/StateDTOes/5
        [HttpGet]
        [Route("GetStateBycont/{id}")]
        public async Task<ActionResult<List<StateDTO>>> GetStateBycont(int? id)
        {

            return await _StateServices.stateBYcont((int)id);
        }
        // PUT: api/StateDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStateDTO(StateDTO stateDTO)
        {
            try
            {
                await _StateServices.UpdateAsync(stateDTO);
                return Ok("Update");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/StateDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StateDTO>> PostStateDTO(StateDTO stateDTO)
        {
            if (ModelState.IsValid)
            {
                await _StateServices.CreateAsync(stateDTO);
                return RedirectToAction(nameof(Index));
            }
            return Ok(stateDTO);


        }

        // DELETE: api/StateDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateDTO(int id)
        {
            if(await _StateServices.Exists(id))
            {
                await _StateServices.DeleteAsync(id);
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }

     
    }
}
