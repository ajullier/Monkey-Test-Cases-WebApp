using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCases.Models;

namespace TestCases.Controllers
{
    public class TestCasesController : Controller
    {
        private readonly TestCasesDbContext _context;

        public TestCasesController(TestCasesDbContext context)
        {
            _context = context;
        }

        // GET: TestCases
        public async Task<IActionResult> Index()
        {
            List<State> States = _context.States.ToList();
            States.Add(new State
            {
                Description = "All",
                Id = 0
            });

            List<View> Views = _context.Views.ToList();
            Views.Add(new View
            {
                Description = "All",
                Id = 0
            });
            
            var testCasesDbContext = _context.TestCases.Include(t => t.State).Include(t => t.View).ToList();
            
            string descriptionFilter = this.ControllerContext.HttpContext.Request.Query["descriptionFilter"];
            int idFilter = Convert.ToInt16(this.ControllerContext.HttpContext.Request.Query["idFilter"]);
            ViewData["Description"] = descriptionFilter;
            ViewData["Id"] = idFilter;

            if (descriptionFilter is not null)
            {
                testCasesDbContext = testCasesDbContext.Where(item => item.Description.Contains(descriptionFilter)).ToList();
            }

            if (idFilter > 0)
            {
                testCasesDbContext = testCasesDbContext.Where(item => item.Id.Equals(idFilter)).ToList();
            }

            int viewFilter = Convert.ToInt16(this.ControllerContext.HttpContext.Request.Query["viewFilter"]);
            if (viewFilter != 0)
            {
                testCasesDbContext = testCasesDbContext.Where(item => item.ViewID.Equals(viewFilter)).ToList();
                ViewData["ViewID"] = new SelectList(Views, "Id", "Description", viewFilter);

            }
            else
            {
                ViewData["ViewID"] = new SelectList(Views, "Id", "Description", 0);
            }

            int stateFilter = Convert.ToInt16(this.ControllerContext.HttpContext.Request.Query["stateFilter"]);
            if (stateFilter != 0)
            {
                testCasesDbContext = testCasesDbContext.Where(item => item.StateID.Equals(stateFilter)).ToList();
                ViewData["StateID"] = new SelectList(States, "Id", "Description", stateFilter);
            }
            else
            {
                ViewData["StateID"] = new SelectList(States, "Id", "Description", 0);
            }


            return View(testCasesDbContext);
        }

        // GET: TestCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestCases == null)
            {
                return NotFound();
            }

            var testCase = await _context.TestCases
                .Include(t => t.State)
                .Include(t => t.View)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testCase == null)
            {
                return NotFound();
            }

            return View(testCase);
        }

        // GET: TestCases/Create
        public IActionResult Create()
        {
            ViewData["StateID"] = new SelectList(_context.States, "Id", "Description");
            ViewData["ViewID"] = new SelectList(_context.Views, "Id", "Description");
            TestCase testCase = new TestCase();
            return View(testCase);
        }

        // POST: TestCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateID,ViewID,DataSet,Steps,StepsCounter,Automated,Comments,Description,Id")] TestCase testCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateID"] = new SelectList(_context.States, "Id", "Description", testCase.StateID);
            ViewData["ViewID"] = new SelectList(_context.Views, "Id", "Description", testCase.ViewID);
            return View(testCase);
        }

        // GET: TestCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestCases == null)
            {
                return NotFound();
            }

            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase == null)
            {
                return NotFound();
            }
            ViewData["StateID"] = new SelectList(_context.States, "Id", "Description", testCase.StateID);
            ViewData["ViewID"] = new SelectList(_context.Views, "Id", "Description", testCase.ViewID);
            return View(testCase);
        }

        // POST: TestCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateID,ViewID,DataSet,Steps,StepsCounter,Automated,Comments,Description,Id")] TestCase testCase)
        {
            if (id != testCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCaseExists(testCase.Id))
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
            ViewData["StateID"] = new SelectList(_context.States, "Id", "Description", testCase.StateID);
            ViewData["ViewID"] = new SelectList(_context.Views, "Id", "Description", testCase.ViewID);
            return View(testCase);
        }

        // GET: TestCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestCases == null)
            {
                return NotFound();
            }

            var testCase = await _context.TestCases
                .Include(t => t.State)
                .Include(t => t.View)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testCase == null)
            {
                return NotFound();
            }

            return View(testCase);
        }

        // POST: TestCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestCases == null)
            {
                return Problem("Entity set 'TestCasesDbContext.TestCases'  is null.");
            }
            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase != null)
            {
                _context.TestCases.Remove(testCase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestCaseExists(int id)
        {
          return (_context.TestCases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
