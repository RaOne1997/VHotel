using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using staticclassmodel.DataAccess.Model.Masters;

namespace MakeMuTrip.Controllers
{
    public class FlightScheduleDTOesController : Controller
    {
        private readonly IFilightShedulServices _context;

        public FlightScheduleDTOesController(IFilightShedulServices context)
        {
            _context = context;
        }

        // GET: FlightScheduleDTOes
        public async Task<IActionResult> Index()
        {
            //return _context.GetallAsync != null ? 
            //            View(await _context.GetallAsync()) :
            //            Problem("Entity set 'MakeMyTripContext.FlightScheduleDTO'  is null.");
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.GetAllAsync == null)
            {
                return NotFound();
            }

            var flightScheduleDTO = await _context.GetByIdAsync(id);

            if (flightScheduleDTO == null)
            {
                return NotFound();
            }

            return View(flightScheduleDTO);
        }

        // GET: FlightScheduleDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightScheduleDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightScheduleDTO flightScheduleDTO)
        {
            if (ModelState.IsValid)
            {

                await _context.CreateAsync(flightScheduleDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(flightScheduleDTO);
        }

        // GET: FlightScheduleDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FlightScheduleDTO flightScheduleDTO)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateAsync(flightScheduleDTO);

                }
                catch (Exception ex)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(flightScheduleDTO);
        }


        [HttpPost]
        public async Task<ActionResult> SearchResults(string locationFrom, string locationTo, DateTime departureDate, DateTime returndate)
        {
            var list = await _context.SearchFlight(locationFrom, locationTo, departureDate);

            var lsflight = new FlightSearchResultViewModel
            {

                Flights = list,
            };


            return View(lsflight);
        }
        // GET: FlightScheduleDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.FlightScheduleDTO == null)
            //{
            //    return NotFound();
            //}

            //var flightScheduleDTO = await _context.FlightScheduleDTO
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (flightScheduleDTO == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: FlightScheduleDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            //if (_context.FlightScheduleDTO == null)
            //{
            //    return Problem("Entity set 'MakeMyTripContext.FlightScheduleDTO'  is null.");
            //}
            //var flightScheduleDTO = await _context.FlightScheduleDTO.FindAsync(id);
            //if (flightScheduleDTO != null)
            //{
            //    _context.FlightScheduleDTO.Remove(flightScheduleDTO);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
