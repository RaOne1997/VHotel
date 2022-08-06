using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakeMyTrip.Data;
using MakeMyTrip.VIewModel.dataviewModel;
using MakeMyTrip.Models.Services;

namespace MakeMyTrip.Controllers
{
    public class FlightScheduleDTOesController : Controller
    {
        private readonly IFlightScheduleServices _context;

        public FlightScheduleDTOesController(IFlightScheduleServices context)
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

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetallAsync == null)
            {
                return NotFound();
            }

            var flightScheduleDTO = await _context.GetbyID(id);
               
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
            
                await _context.CreatAsync(flightScheduleDTO);
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
                    _context.UpdateFlightbook(flightScheduleDTO);
             
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flightScheduleDTO);
        }


        [HttpPost]
        public async Task<ActionResult> SearchResults(string locationFrom, string locationTo, DateTime departureDate,DateTime returndate)
        {
           var list = await _context.SearchFlight(locationFrom, locationTo, departureDate, returndate);
           
            return View(list);
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
