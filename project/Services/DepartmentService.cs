using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stable.Models.Departments;

namespace stable.Services {
	public class DepartmentService {
		private readonly ProjectContext _context;

		public DepartmentService (ProjectContext context) {
			_context = context;
		}
		// GET: Department
		public async Task<List<Department>> getDepartments () {
			return await _context.Departments.ToListAsync ();
		}

	}
}