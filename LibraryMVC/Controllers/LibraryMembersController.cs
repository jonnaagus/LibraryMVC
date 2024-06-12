using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Data.Library.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMVC.Controllers
{
    public class LibraryMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibraryMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LibraryMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibraryMembers.ToListAsync());
        }

        // GET: LibraryMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryMember = await _context.LibraryMembers
                .Include(lm => lm.LoanRecords)
                    .ThenInclude(lr => lr.BookItem)
                .FirstOrDefaultAsync(m => m.LibraryMemberId == id);

            if (libraryMember == null)
            {
                return NotFound();
            }

            return View(libraryMember);
        }

        // GET: LibraryMember/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryMember/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibraryMemberId,FirstName,LastName,PhoneNumber,EmailAddress")] LibraryMember libraryMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryMember);
        }

        // GET: LibraryMembers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryMember = await _context.LibraryMembers.FindAsync(id);
            if (libraryMember == null)
            {
                return NotFound();
            }
            return View(libraryMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibraryMemberId,FirstName,LastName,PhoneNumber,EmailAddress")] LibraryMember libraryMember)
        {
            if (id != libraryMember.LibraryMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryMemberExists(libraryMember.LibraryMemberId))
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
            return View(libraryMember);
        }

        private bool LibraryMemberExists(int id)
        {
            return _context.LibraryMembers.Any(e => e.LibraryMemberId == id);
        }


        // GET: LibraryMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryMember = await _context.LibraryMembers
                .FirstOrDefaultAsync(m => m.LibraryMemberId == id);
            if (libraryMember == null)
            {
                return NotFound();
            }

            return View(libraryMember);
        }

        // POST: LibraryMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryMember = await _context.LibraryMembers.FindAsync(id);
            _context.LibraryMembers.Remove(libraryMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Custom method to get a member by ID and populate dropdown
        [HttpGet]
        public async Task<IActionResult> GetMemberById(int? id)
        {
            var allMembers = await _context.LibraryMembers.ToListAsync();
            ViewBag.AllMembers = allMembers;

            if (id == null)
            {
                return View();
            }

            var libraryMember = await _context.LibraryMembers.FindAsync(id);
            if (libraryMember == null)
            {
                return NotFound();
            }

            return View(libraryMember);
        }
    }
}
