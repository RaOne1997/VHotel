using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.Services;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICrudeServices<CountryDTO> _countryServices;
        private readonly ILogger<CountryDTO> _logger;

        public CountriesController(ICrudeServices<CountryDTO> countryServices, ILogger<CountryDTO> logger)
        {
            _countryServices = countryServices;
           _logger = logger;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> Getcountries()
        {
            try
            {
               return await _countryServices.GetAllAsync();

            }catch(Exception ex)
            {
                return BadRequest("contact to developer"+ex);
               
            }
         
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountryDTO(int id)
        {
            try
            {
                return await _countryServices.GetByIdAsync(id);

            }
            catch (Exception ex)
            {
                return BadRequest("contact to developer"+ex);

            }

        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCountryDTO(CountryDTO CountryDTO)
        {
            try
            {
                await _countryServices.UpdateAsync(CountryDTO);
                return Ok("Update");

            }
            catch (Exception ex)
            {
                return BadRequest("contact to developer"+ex);

            }

        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryDTO>> PostCountryDTO([FromForm] CountryDTO CountryDTO)
        {

            try
            {
              await  _countryServices.CreateAsync(CountryDTO);
                return CreatedAtAction("GetCountryDTO", new { id = CountryDTO.ID }, CountryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("contact to developer"+ex);

            }
         
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryDTO(int id)
        {
            try
            {
               await _countryServices.DeleteAsync(id);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest("contact to developer"+ex);

            }

        }

       
    }
}
