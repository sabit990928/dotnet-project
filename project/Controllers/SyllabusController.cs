using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stable.Models.Syllabuses;

namespace stable.Controllers
{
    public class SyllabusController : Controller
    {
        private readonly ProjectContext _context;

        public SyllabusController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Syllabus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Syllabuss.ToListAsync());
        }

        // GET: Syllabus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabuss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // GET: Syllabus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Syllabus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Semester")] Syllabus syllabus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(syllabus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(syllabus);
        }

        // GET: Syllabus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabuss.FindAsync(id);
            if (syllabus == null)
            {
                return NotFound();
            }
            return View(syllabus);
        }

        // POST: Syllabus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Semester")] Syllabus syllabus)
        {
            if (id != syllabus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(syllabus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SyllabusExists(syllabus.Id))
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
            return View(syllabus);
        }

        // GET: Syllabus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabuss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // POST: Syllabus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var syllabus = await _context.Syllabuss.FindAsync(id);
            _context.Syllabuss.Remove(syllabus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SyllabusExists(int id)
        {
            return _context.Syllabuss.Any(e => e.Id == id);
        }
    }
}
