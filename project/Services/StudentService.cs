using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stable.Data;
using stable.Models.Students;

namespace stable.Services {
	public class StudentService {
		private readonly IStudentRepo _context;

		public StudentService (IStudentRepo context) {
			_context = context;
		}
		// GET: Student
		public async Task<List<Student>> getStudents () {
			return await _context.getStudents ();
		}

		// GET: student/details
		public async Task<Student> getStudent (int? id) {
			return await _context.getStudent (id);
		}

		// post: student/create
		public async Task createStudent (Student student) {
			await _context.createStudent (student);
		}

		// post: student/edit
		public async Task editStudent (Student student) {
			await _context.editStudent (student);
		}

		// GET: student/edit
		public Task<Student> findStudent (int? id) {
			return _context.findStudent (id);
		}

		//post: student/delete
		public Task deleteStudent (Student student) {
			return _context.deleteStudent (student);
		}

		//exist
		public bool studentExists (int id) {
			return _context.studentExists (id);
		}
	}
}