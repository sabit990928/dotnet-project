using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stable.Models.Students;
using stable.Services;

namespace stable.Controllers {
    public class StudentController : Controller {
        private readonly StudentService _studService;
        private readonly ProjectContext _context;

        public StudentController (ProjectContext context, StudentService studService) {
            _studService = studService;
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index () {

            return View (await _studService.getStudents ());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var student = await _studService.getStudent (id);
            if (student == null) {
                return NotFound ();
            }

            return View (student);
        }

        // GET: Student/Create
        public IActionResult Create () {
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "GroupNumber");
            return View ();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Name,Email,GroupId")] Student student) {
            if (ModelState.IsValid) {
                await _studService.createStudent (student);
                return RedirectToAction (nameof (Index));
            }
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "GroupNumber", student.GroupId);
            return View (student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var student = await _studService.findStudent (id);
            if (student == null) {
                return NotFound ();
            }
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "GroupNumber", student.GroupId);
            return View (student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("Id,Name,Email,GroupId")] Student student) {
            if (id != student.Id) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _studService.editStudent (student);
                } catch (DbUpdateConcurrencyException) {
                    if (!StudentExists (student.Id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "GroupNumber", student.GroupId);
            return View (student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var student = await _studService.getStudent (id);
            if (student == null) {
                return NotFound ();
            }

            return View (student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var student = await _studService.findStudent (id);
            await _studService.deleteStudent (student);
            return RedirectToAction (nameof (Index));
        }

        private bool StudentExists (int id) {
            return _studService.studentExists (id);
        }
    }
}