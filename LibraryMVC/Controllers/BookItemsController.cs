using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Data.Library.Data;

namespace LibraryMVC.Controllers
{
    public class BookItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookItems.ToListAsync());
        }

        // GET: BookItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookItem = await _context.BookItems
                .FirstOrDefaultAsync(m => m.BookItemId == id);
            if (bookItem == null)
            {
                return NotFound();
            }

            return View(bookItem);
        }

        // GET: BookItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookItemId,Title,Writer,PublicationDate,Available")] BookItem bookItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookItem);
        }

        // GET: BookItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookItem = await _context.BookItems.FindAsync(id);
            if (bookItem == null)
            {
                return NotFound();
            }
            return View(bookItem);
        }

        // POST: BookItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookItemId,Title,Writer,PublicationDate,Available")] BookItem bookItem)
        {
            if (id != bookItem.BookItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookItemExists(bookItem.BookItemId))
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
            return View(bookItem);
        }

        // GET: BookItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookItem = await _context.BookItems
                .FirstOrDefaultAsync(m => m.BookItemId == id);
            if (bookItem == null)
            {
                return NotFound();
            }

            return View(bookItem);
        }

        // POST: BookItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookItem = await _context.BookItems.FindAsync(id);
            _context.BookItems.Remove(bookItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookItemExists(int id)
        {
            return _context.BookItems.Any(e => e.BookItemId == id);
        }
    }
}
