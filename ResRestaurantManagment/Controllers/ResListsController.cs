using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResRestaurantManagment.Data;

namespace ResRestaurantManagment.Controllers
{
    public class ResListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResList.Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResList == null)
            {
                return NotFound();
            }

            var resList = await _context.ResList
                .Include(r => r.User)
                .Include(r => r.Tables)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resList == null)
            {
                return NotFound();
            }

            return View(resList);
        }

        // GET: ResLists/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Email");
            return View();
        }

        // POST: ResLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ResDate,TableId,Description")] ResList resList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Email", resList.UserId);
            return View(resList);
        }

        // GET: ResLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResList == null)
            {
                return NotFound();
            }

            var resList = await _context.ResList.FindAsync(id);
            if (resList == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Email", resList.UserId);
            return View(resList);
        }

        // POST: ResLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ResDate,TableId,Description")] ResList resList)
        {
            if (id != resList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResListExists(resList.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Email", resList.UserId);
            return View(resList);
        }

        // GET: ResLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResList == null)
            {
                return NotFound();
            }

            var resList = await _context.ResList
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resList == null)
            {
                return NotFound();
            }

            return View(resList);
        }

        // POST: ResLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResList'  is null.");
            }
            var resList = await _context.ResList.FindAsync(id);
            if (resList != null)
            {
                _context.ResList.Remove(resList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResListExists(int id)
        {
          return _context.ResList.Any(e => e.Id == id);
        }
    }
}
