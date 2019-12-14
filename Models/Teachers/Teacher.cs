using System.ComponentModel.DataAnnotations;
using stable.Models.Departments;

namespace stable.Models.Teachers {
	public class Teacher {
		public int Id { get; set; }

		[Required]
		[StringLength (50)]
		public string Name { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }

		public Teacher () { }

		public Teacher (int id, string name, int departmentId) {
			this.Id = id;
			this.Name = name;
			this.DepartmentId = departmentId;
		}
	}
}