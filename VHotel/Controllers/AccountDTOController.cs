using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VHotel.DataAccess.DTo;
using VHotel.DataAccess.Model.Master;
using VHotel.Services;
using VHotel.Services.Interface;

namespace VHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDTOController : ControllerBase
    {

        private readonly IAccountService _airlinrtServices;

        public AccountDTOController(IAccountService airlinrServices)
        {
            _airlinrtServices = airlinrServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAmenuitiesDTO()
        {
            try
            {
                var citys = await _airlinrtServices.GetAllAsync();
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


        
        [HttpGet("{userID}/{Password}")]
        public async Task<ActionResult<AccountDTO>> login(string userID,string Password)
        {
            try
            {
                var result   = await  _airlinrtServices.login(userID, Password);
                if (result != null)
                {

                    return result;
                }
                else
                    return result;
                    
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e + false);
            }
        }


        [HttpPost]
        public async Task<ActionResult<AccountDTO>> CreatreAsync(AccountDTO accountDTO)
        {
            try
            {
                
                await _airlinrtServices.CreateAsync(accountDTO);
                return CreatedAtAction("login", new { ID=accountDTO.ID, userID = accountDTO.UserName , Password=accountDTO.Password }, accountDTO);

            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error in GetAll");
                return Problem("Error in GetAll" + e + false);
            }
        }
    }
}
