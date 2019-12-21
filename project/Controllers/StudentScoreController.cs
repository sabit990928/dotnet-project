using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stable.Models.StudentScores;

namespace stable.Controllers {
    public class StudentScoreController : Controller {
        private readonly ProjectContext _context;

        public StudentScoreController (ProjectContext context) {
            _context = context;
        }

        // GET: StudentScore
        public async Task<IActionResult> Index () {
            var projectContext = _context.StudentScores.Include (s => s.Score).Include (s => s.Student);
            return View (await projectContext.ToListAsync ());
        }

        // GET: StudentScore/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var studentScore = await _context.StudentScores
                .Include (s => s.Score)
                .Include (s => s.Student)
                .FirstOrDefaultAsync (m => m.id == id);
            if (studentScore == null) {
                return NotFound ();
            }

            return View (studentScore);
        }

        // GET: StudentScore/Create
        public IActionResult Create () {
            ViewData["ScoreId"] = new SelectList (_context.Scores, "Id", "Percent");
            ViewData["StudentId"] = new SelectList (_context.Students, "Id", "Email");
            return View ();
        }

        // POST: StudentScore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("id,StudentId,ScoreId")] StudentScore studentScore) {
            if (ModelState.IsValid) {
                _context.Add (studentScore);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            ViewData["ScoreId"] = new SelectList (_context.Scores, "Id", "Id", studentScore.ScoreId);
            ViewData["StudentId"] = new SelectList (_context.Students, "Id", "Email", studentScore.StudentId);
            return View (studentScore);
        }

        // GET: StudentScore/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var studentScore = await _context.StudentScores.FindAsync (id);
            if (studentScore == null) {
                return NotFound ();
            }
            ViewData["ScoreId"] = new SelectList (_context.Scores, "Id", "Percent", studentScore.ScoreId);
            ViewData["StudentId"] = new SelectList (_context.Students, "Id", "Email", studentScore.StudentId);
            return View (studentScore);
        }

        // POST: StudentScore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("id,StudentId,ScoreId")] StudentScore studentScore) {
            if (id != studentScore.id) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (studentScore);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!StudentScoreExists (studentScore.id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            ViewData["ScoreId"] = new SelectList (_context.Scores, "Id", "Id", studentScore.ScoreId);
            ViewData["StudentId"] = new SelectList (_context.Students, "Id", "Email", studentScore.StudentId);
            return View (studentScore);
        }

        // GET: StudentScore/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var studentScore = await _context.StudentScores
                .Include (s => s.Score)
                .Include (s => s.Student)
                .FirstOrDefaultAsync (m => m.id == id);
            if (studentScore == null) {
                return NotFound ();
            }

            return View (studentScore);
        }

        // POST: StudentScore/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var studentScore = await _context.StudentScores.FindAsync (id);
            _context.StudentScores.Remove (studentScore);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool StudentScoreExists (int id) {
            return _context.StudentScores.Any (e => e.id == id);
        }
    }
}