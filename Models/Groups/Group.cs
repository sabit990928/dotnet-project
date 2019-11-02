using System.Collections.Generic;
using stable.Models.Students;

namespace stable.Models.Groups {
	public class Group {
		public int Id { get; set; }
		public int GroupNumber { get; set; }
		public List<Student> Students { get; set; }
	}
}