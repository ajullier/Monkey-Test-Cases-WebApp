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
    public class ViewsController : Controller
    {
        private readonly TestCasesDbContext _context;

        public ViewsController(TestCasesDbContext context)
        {
            _context = context;
        }

        // GET: Views
        public async Task<IActionResult> Index()
        {
              return _context.Views != null ? 
                          View(await _context.Views.ToListAsync()) :
                          Problem("Entity set 'TestCasesDbContext.Views'  is null.");
        }

        // GET: Views/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Views == null)
            {
                return NotFound();
            }

            var view = await _context.Views
                .FirstOrDefaultAsync(m => m.Id == id);
            if (view == null)
            {
                return NotFound();
            }

            return View(view);
        }

        // GET: Views/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Views/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Navigation,Description,Id")] View view)
        {
            if (ModelState.IsValid)
            {
                _context.Add(view);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Views/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Views == null)
            {
                return NotFound();
            }

            var view = await _context.Views.FindAsync(id);
            if (view == null)
            {
                return NotFound();
            }
            return View(view);
        }

        // POST: Views/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Navigation,Description,Id")] View view)
        {
            if (id != view.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(view);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViewExists(view.Id))
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
            return View(view);
        }

        // GET: Views/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Views == null)
            {
                return NotFound();
            }

            var view = await _context.Views
                .FirstOrDefaultAsync(m => m.Id == id);
            if (view == null)
            {
                return NotFound();
            }

            return View(view);
        }

        // POST: Views/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Views == null)
            {
                return Problem("Entity set 'TestCasesDbContext.Views'  is null.");
            }
            var view = await _context.Views.FindAsync(id);
            if (view != null)
            {
                _context.Views.Remove(view);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViewExists(int id)
        {
          return (_context.Views?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
