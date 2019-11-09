using System.ComponentModel.DataAnnotations;
using stable.Models.Departments;

namespace stable.Models.Teachers {
	public class Teacher {
		public int Id { get; set; }

		[Required]
		[StringLength (50)]
		public string Name { get; set; }
		public Department Department { get; set; }
	}
}