using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCases.Models;

namespace TestCases.Controllers
{
    public class BusinessUnitsController : Controller
    {
        private readonly TestCasesDbContext _context;

        public BusinessUnitsController(TestCasesDbContext context)
        {
            _context = context;
        }

        // GET: BusinessUnits
        public async Task<IActionResult> Index()
        {
              return _context.BusinessUnits != null ? 
                          View(await _context.BusinessUnits.ToListAsync()) :
                          Problem("Entity set 'TestCasesDbContext.BusinessUnits'  is null.");
        }

        // GET: BusinessUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessUnits == null)
            {
                return NotFound();
            }

            var businessUnit = await _context.BusinessUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessUnit == null)
            {
                return NotFound();
            }

            return View(businessUnit);
        }

        // GET: BusinessUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Id")] BusinessUnit businessUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessUnit);
        }

        // GET: BusinessUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessUnits == null)
            {
                return NotFound();
            }

            var businessUnit = await _context.BusinessUnits.FindAsync(id);
            if (businessUnit == null)
            {
                return NotFound();
            }
            return View(businessUnit);
        }

        // POST: BusinessUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,Id")] BusinessUnit businessUnit)
        {
            if (id != businessUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessUnitExists(businessUnit.Id))
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
            return View(businessUnit);
        }

        // GET: BusinessUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessUnits == null)
            {
                return NotFound();
            }

            var businessUnit = await _context.BusinessUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessUnit == null)
            {
                return NotFound();
            }

            return View(businessUnit);
        }

        // POST: BusinessUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessUnits == null)
            {
                return Problem("Entity set 'TestCasesDbContext.BusinessUnits'  is null.");
            }
            var businessUnit = await _context.BusinessUnits.FindAsync(id);
            if (businessUnit != null)
            {
                _context.BusinessUnits.Remove(businessUnit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessUnitExists(int id)
        {
          return (_context.BusinessUnits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
