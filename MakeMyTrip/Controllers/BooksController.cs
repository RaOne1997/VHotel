using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakeMyTrip.Data;
using MakeMyTrip.Models.Services;


namespace MakeMyTrip.Controllers
{
    public class BooksController : Controller
    {
        private readonly Context _context = new Context();
        private readonly IBooksServices _booksServices;

        public BooksController(IBooksServices booksServices)
        {
            _booksServices = booksServices;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return _context.books != null ?
                        View(await _context.books.ToListAsync()) :
                        Problem("Entity set 'Context.books'  is null.");
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Books books)
        {
            if (ModelState.IsValid)
            {

                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var books = await _context.books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("title,subtitle,isbn13,price,image,url,ID")] Books books)
        {
            if (id != books.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.books == null)
            {
                return Problem("Entity set 'Context.books'  is null.");
            }
            var books = await _context.books.FindAsync(id);
            if (books != null)
            {
                _context.books.Remove(books);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("Insertdata")]
        public async Task<IActionResult> Insertdata()
        {
            //await _booksServices.insertDetailsAsync();
            ViewData["DepartmentRefId"] = new SelectList(_booksServices.dropdown(), "key", "value");
            return View();
        }
        [HttpPost, ActionName("Insertdata")]
        public async Task<IActionResult> Insertdata(string subject, int pageno)
        {

            var result = new result();
 

            result.msg = await _booksServices.inserttodpAsync(subject, pageno);
            ViewData["DepartmentRefId"] = new SelectList(_booksServices.dropdown(), "key", "value");
            return View(result);
        }

        private bool BooksExists(int id)
        {
            return (_context.books?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }

    public class result
    {

        public string msg { get; set; } = "Hello";
    }
}
