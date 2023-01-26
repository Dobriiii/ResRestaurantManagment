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
    public class ResTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResTables
        public async Task<IActionResult> Index()
        {
              return View(await _context.ResTable.ToListAsync());
        }

        // GET: ResTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResTable == null)
            {
                return NotFound();
            }

            var resTable = await _context.ResTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resTable == null)
            {
                return NotFound();
            }

            return View(resTable);
        }

        // GET: ResTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Table,Slots,IsSmoking")] ResTable resTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resTable);
        }

        // GET: ResTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResTable == null)
            {
                return NotFound();
            }

            var resTable = await _context.ResTable.FindAsync(id);
            if (resTable == null)
            {
                return NotFound();
            }
            return View(resTable);
        }

        // POST: ResTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Table,Slots,IsSmoking")] ResTable resTable)
        {
            if (id != resTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResTableExists(resTable.Id))
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
            return View(resTable);
        }

        // GET: ResTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResTable == null)
            {
                return NotFound();
            }

            var resTable = await _context.ResTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resTable == null)
            {
                return NotFound();
            }

            return View(resTable);
        }

        // POST: ResTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResTable == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResTable'  is null.");
            }
            var resTable = await _context.ResTable.FindAsync(id);
            if (resTable != null)
            {
                _context.ResTable.Remove(resTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResTableExists(int id)
        {
          return _context.ResTable.Any(e => e.Id == id);
        }
    }
}
