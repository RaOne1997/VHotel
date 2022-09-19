using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.Services;

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VHotel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using VHotel.DataAccess.Model.security;
using VHotel.Services;
using Microsoft.AspNetCore.Authorization;

namespace MakeMuTrip.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountDTOController : ControllerBase
    {

        private readonly IAccountService _accountServices;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;

        private readonly IAuthTokenService _authTokenService;
        private readonly ILogger<AccountDTOController> _logger;

        public AccountDTOController(IAccountService accountServices,
               SignInManager<User> signInManager,
               UserManager<User> userManager,
               IAuthTokenService authTokenService,
               ILogger<AccountDTOController> logger,
               IMapper mapper)
        {
            _accountServices = accountServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _authTokenService = authTokenService;
            _logger = logger;


        }


        [HttpGet]
        public async Task<ActionResult<List<AccountDTO>>> logins()
        {
            var useraaa = await _accountServices.GetAllAsync();
            return useraaa;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<int>> logins(string id)
        {
            var useraaa = await _accountServices.getidBYname(id);
            return useraaa;
        }



        [HttpGet("{userID}/{Password}")]
        public async Task<ActionResult<int>> login(string userID, string Password)
        {
            try
            {
                var result = await _accountServices.login(userID, Password);
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

                await _accountServices.CreateAsync(accountDTO);
                return CreatedAtAction("logins", new { id = accountDTO.Email }, accountDTO);

            }
            catch (Exception e)
            {

                return Problem("Error in GetAll" + e + false);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return Ok(new RegistrationResponseDto { IsSuccessfulRegistration = result.Succeeded });
        }
        [HttpPost]
        public async Task<ActionResult<object>> Login(LoginViewModel user)
        {
            try
            {
                var authResponse = await _authTokenService.GetAuthTokenAsync(user);


                return authResponse;
            }
            catch (AuthFailedException e)
            {
                //_logger.LogError(e.Message);
                return StatusCode(400, e.Message);
            }
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);

            //    if (result.Succeeded)
            //    {
            //        var users = await _userManager.FindByNameAsync(user.Email);
            //        return users;
            //    }
            //    else
            //    {
            //        return NotFound();
            //    }
            //}


            //return false;
        }

        [HttpGet("{ID}")]

        public async Task<ActionResult<User>> getalluser(string ID)
        {
            var user = await _userManager.FindByIdAsync(ID);
            return Ok(user);

        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Logouts");
        }
    }

}
