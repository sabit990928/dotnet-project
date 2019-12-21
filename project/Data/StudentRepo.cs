using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stable.Models.Students;

namespace stable.Data {
	public class StudentRepo : IStudentRepo {
		private readonly ProjectContext _context;

		public StudentRepo (ProjectContext context) {
			_context = context;
		}
		// GET: Student
		public Task<List<Student>> getStudents () {
			return _context.Students.Include (s => s.Group).ToListAsync ();
		}

		// GET: student/details
		public async Task<Student> getStudent (int? id) {
			return await _context.Students
				.Include (s => s.Group).FirstOrDefaultAsync (m => m.Id == id);
		}

		// post: student/create
		public async Task createStudent (Student student) {
			_context.Add (student);
			await _context.SaveChangesAsync ();
		}

		// post: student/edit
		public async Task editStudent (Student student) {
			_context.Update (student);
			await _context.SaveChangesAsync ();
		}

		// GET: student/edit
		public Task<Student> findStudent (int? id) {
			return _context.Students.FindAsync (id);
		}

		//post: student/delete
		public Task deleteStudent (Student student) {
			_context.Students.Remove (student);
			return _context.SaveChangesAsync ();
		}

		//exist
		public bool studentExists (int id) {
			return _context.Students.Any (e => e.Id == id);
		}
	}
}