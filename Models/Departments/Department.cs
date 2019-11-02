using System.Collections.Generic;
using stable.Models.Teachers;

namespace stable.Models.Departments {
	public class Department {
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Teacher> Teachers { get; set; }
	}
}