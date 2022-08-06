
using MakeMyTrip.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MakeMyTrip.Controllers
{
    public class TestController : Controller
    {
        private readonly ITextSercides _roomServices;
        private readonly IBooksServices _bookServices;
        bool t = true;

        public TestController(ITextSercides roomServices, IBooksServices bookServices)
        {
            _roomServices = roomServices;
            _bookServices = bookServices;
        }
        public async Task<IActionResult> IndexAsync(string curinc = "INR")
        {
        
               
            if(t){
                ViewData["DepartmentRefId"] = new SelectList(_roomServices.dropdown(), "key", "value");
                t= false;

            }

         var book= await _bookServices.GetallAsyncbooks(".NET Framework",1);
            var list = await _roomServices.GetallAsync(curinc);



            return View(book);
        }
        public async Task<IActionResult> Bookbycat(string curinc ,int pagenumber)
        {
          
            var book = await _bookServices.GetallAsync();

            return View(book);
        }
        public async Task<IActionResult> BookBYID(int ID)
        {
            var book = await _bookServices.getbyid(ID);

            ViewBag.Privacy = ID;
            return View(book);
        }
    }
}
