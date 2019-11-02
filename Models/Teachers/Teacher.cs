using stable.Models.Departments;

namespace stable.Models.Teachers {
	public class Teacher {
		public int Id { get; set; }
		public string Name { get; set; }
		public Department Department { get; set; }
	}
}