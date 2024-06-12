using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMVC.Data;
using LibraryMVC.Models;
using LibraryMVC.Data.Library.Data;

namespace LibraryMVC.Controllers
{
    public class LoanRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LoanRecords
        public async Task<IActionResult> Index()
        {
            var loanRecords = await _context.LoanRecords
                .Include(lr => lr.LibraryMember)
                .Include(lr => lr.BookItem)
                .ToListAsync();
            return View(loanRecords);
        }

        // GET: LoanRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanRecord = await _context.LoanRecords
                .Include(lr => lr.LibraryMember)
                .Include(lr => lr.BookItem)
                .FirstOrDefaultAsync(m => m.LibraryMemberId == id);
            if (loanRecord == null)
            {
                return NotFound();
            }

            return View(loanRecord);
        }

        // GET: LoanRecords/Create
        [HttpGet]
        public IActionResult Create()
        {
            var members = _context.LibraryMembers.ToList();
            ViewBag.LibraryMembers = members;

            var books = _context.BookItems.Where(b => b.Available == true).ToList();
            ViewBag.BookItems = books;

            return View();
        }

        // POST: LoanRecords/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanRecord loanRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanRecord);

                var selectedBook = await _context.BookItems.FindAsync(loanRecord.BookItemId);
                if (selectedBook != null)
                {
                    selectedBook.Available = false;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var members = _context.LibraryMembers.ToList();
            ViewBag.LibraryMembers = members;

            var books = _context.BookItems.Where(b => b.Available == true).ToList();
            ViewBag.BookItems = books;

            return View(loanRecord);
        }


        // GET: LoanRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanRecord = await _context.LoanRecords.FindAsync(id);
            if (loanRecord == null)
            {
                return NotFound();
            }

            var viewModel = new LoanRecordViewModel
            {
                LoanRecord = loanRecord,
                LibraryMembers = _context.LibraryMembers.ToList(),
                BookItems = _context.BookItems.ToList()
            };
            return View(viewModel);
        }

        // POST: LoanRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LoanRecordViewModel viewModel)
        {
            if (id != viewModel.LoanRecord.LoanRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.LoanRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanRecordExists(viewModel.LoanRecord.LoanRecordId))
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
            viewModel.LibraryMembers = _context.LibraryMembers.ToList();
            viewModel.BookItems = _context.BookItems.ToList();
            return View(viewModel);
        }

        // GET: LoanRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanRecord = await _context.LoanRecords
                .Include(lr => lr.LibraryMember)
                .Include(lr => lr.BookItem)
                .FirstOrDefaultAsync(m => m.LibraryMemberId == id);
            if (loanRecord == null)
            {
                return NotFound();
            }

            return View(loanRecord);
        }

        // POST: LoanRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanRecord = await _context.LoanRecords.FindAsync(id);
            _context.LoanRecords.Remove(loanRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanRecordExists(int id)
        {
            return _context.LoanRecords.Any(e => e.LoanRecordId == id);
        }
    }
}
