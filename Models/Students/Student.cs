using System.Collections.Generic;
using stable.Models.Groups;
using stable.Models.StudentScores;

namespace stable.Models.Students {
	public class Student {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public Group Group { get; set; }
		public List<StudentScore> StudentScores { get; set; }
	}
}