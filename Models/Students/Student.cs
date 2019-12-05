using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using stable.Models.Groups;
using stable.Models.StudentScores;

namespace stable.Models.Students {
	public class Student {
		public int Id { get; set; }

		[Required]
		[StringLength (50)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]

		public string Email { get; set; }
		public int GroupId { get; set; }
		public Group Group { get; set; }
		public List<StudentScore> StudentScores { get; set; }
	}
}