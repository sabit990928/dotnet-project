using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stable.Models.Departments;
using stable.Services;

namespace stable.Controllers {
    public class DepartmentController : Controller {
        private readonly ProjectContext _context;
        private DepartmentService _depService;

        public DepartmentController (ProjectContext context, DepartmentService depService) {
            _context = context;
            _depService = depService;
        }

        // GET: Department
        public async Task<IActionResult> Index () {
            return View (await _depService.getDepartments ());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync (m => m.Id == id);
            if (department == null) {
                return NotFound ();
            }

            return View (department);
        }

        // GET: Department/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Name")] Department department) {
            if (ModelState.IsValid) {
                _context.Add (department);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var department = await _context.Departments.FindAsync (id);
            if (department == null) {
                return NotFound ();
            }
            return View (department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("Id,Name")] Department department) {
            if (id != department.Id) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (department);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!DepartmentExists (department.Id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync (m => m.Id == id);
            if (department == null) {
                return NotFound ();
            }

            return View (department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var department = await _context.Departments.FindAsync (id);
            _context.Departments.Remove (department);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool DepartmentExists (int id) {
            return _context.Departments.Any (e => e.Id == id);
        }
    }
}