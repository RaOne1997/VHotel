using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MakeMyTrip.VIewModel.dataviewModel;
using MakeMyTrip.Models.Services;

namespace MakeMyTrip.Controllers
{
    public class FlightBookingDTOesController : Controller
    {
        private readonly IRoomServices _roomServices;

        public FlightBookingDTOesController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }

        // GET: FlightBookingDTOes
        public async Task<IActionResult> Index()
        {
            return _roomServices.GetallAsync != null ?
                        View(await _roomServices.GetallAsync()) :
                        Problem("Entity set 'MakeMyTripContext.FlightBookingDTO'  is null.");
        }

        // GET: FlightBookingDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _roomServices.GetallAsync == null)
            {
                return NotFound();
            }

            var flightBookingDTO = await _roomServices.GetbyID(id);
                           if (flightBookingDTO == null)
            {
                return NotFound();
            }

            return View(flightBookingDTO);
        }

        // GET: FlightBookingDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightBookingDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightBookingDTO flightBookingDTO)
        {
            if (ModelState.IsValid)
            {
                await _roomServices.CreatAsync(flightBookingDTO);
               
            }
            return View(flightBookingDTO);
        }

        // GET: FlightBookingDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _roomServices.GetallAsync == null)
            {
                return NotFound();
            }

            var flightBookingDTO =  await _roomServices.GetbyID(id);
            if (flightBookingDTO == null)
            {
                return NotFound();
            }
            return View(flightBookingDTO);
        }

        // POST: FlightBookingDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FlightBookingDTO flightBookingDTO)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
                   await _roomServices.UpdateFlightbook(flightBookingDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!FlightBookingDTOExists(flightBookingDTO.ID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flightBookingDTO);
        }

        //// GET: FlightBookingDTOes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.FlightBookingDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    var flightBookingDTO = await _context.FlightBookingDTO
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (flightBookingDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(flightBookingDTO);
        //}

        //// POST: FlightBookingDTOes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int? id)
        //{
        //    if (_context.FlightBookingDTO == null)
        //    {
        //        return Problem("Entity set 'MakeMyTripContext.FlightBookingDTO'  is null.");
        //    }
        //    var flightBookingDTO = await _context.FlightBookingDTO.FindAsync(id);
        //    if (flightBookingDTO != null)
        //    {
        //        _context.FlightBookingDTO.Remove(flightBookingDTO);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FlightBookingDTOExists(int? id)
        //{
        //    return (_context.FlightBookingDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        //}
    }
}
