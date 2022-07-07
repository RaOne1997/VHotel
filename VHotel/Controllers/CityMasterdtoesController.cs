using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;
using VHotel.Services;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMasterdtoesController : ControllerBase
    {
        private readonly ICityServices _cityServices;

        public CityMasterdtoesController(ICityServices  cityServices)
        {
            _cityServices = cityServices;
        }

        // GET: api/CityMasterdtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityMasterdto>>> GetCityMasterdto()
        {
            try
            {
                var citys = await _cityServices.GetAllAsync();
                return Ok(citys);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll");
            }


        }

        // GET: api/CityMasterdtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityMasterdto>> GetCityMasterdto(int id)
        {
            if(id == null)
        {
                return NotFound();
            }

            var department = await _cityServices.GetByIdAsync((int)id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/CityMasterdtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCityMasterdto(CityMasterdto cityMasterdto)
        {
            try
            {
                await _cityServices.UpdateAsync(cityMasterdto);
                return Ok("Update");
            }catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/CityMasterdtoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityMasterdto>> PostCityMasterdto([FromForm]CityMasterdto cityMasterdto)
        {
            if (ModelState.IsValid)
            {
                await _cityServices.CreateAsync(cityMasterdto);
                return RedirectToAction(nameof(Index));
            }
            return Ok(cityMasterdto);

        
        }

        // DELETE: api/CityMasterdtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityMasterdto(int id)
        {
            if (await _cityServices.Exists(id))
            {
                await _cityServices.DeleteAsync(id);
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }

       
    }
}
