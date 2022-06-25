using HotelBooking.Models.DTO;
using HotelBooking.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomServices _roomServices;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomServices roomServices, ILogger<RoomController> logger)
        {
            _roomServices = roomServices;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var room = await _roomServices.GetallAsync();
            return View(room);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var room = await _roomServices.GetbyID(id);
            return View(room);
        }


        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Room rooms)
        {

          

            var room = await _roomServices.CreatAsync(rooms);
            if (room)
            {



                ViewData["Message"] = $"Room saved  {rooms.RoomNumber} ";
                return View();
            }
            else
            {
                ViewData["Message"] = $"Fail to save {rooms.RoomNumber} ";
                return View();
            }



        }






        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                ViewData["ErrorMessage"] = $"Location Id {id} missing in parameter";
                return View();
            }

            try
            {
                var locationDto = await _roomServices.GetbyID(id);
                return View(locationDto);
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = $"Location Id {id} not found";
                _logger.LogError(e, "Error Getting Location By Id");

                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocationAsync(int? id)
        {
            if (id == null)
            {
                ViewData["ErrorMessage"] = $"Location Id {id} missing in parameter";
                return View("Delete");
            }

            try
            {
                await _roomServices.DeleteAsync((int)id);
                ViewData["SuccessMessage"] = "Location Deleted Successfully";
                return View("Delete");
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = $"Location Id {id} not found";
                _logger.LogError(e, "Error Getting Location By Id");

                return View("Delete");
            }
        }
    }
}
