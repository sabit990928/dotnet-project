using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using stable.Models.Groups;
using stable.Models.StudentScores;
using stable.Utils;
namespace stable.Models.Students {
	public class Student {
		public int Id { get; set; }

		[Required]
		[StringLength (50)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		[ValidTeacherDomain (iituDomain: "iitu.kz",
			ErrorMessage = "Email domain must be iitu.kz")]
		public string Email { get; set; }
		public int GroupId { get; set; }
		public Group Group { get; set; }
		public List<StudentScore> StudentScores { get; set; }

		public Student () { }

		public Student (int id, string name, string email, int groupId) {
			this.Id = id;
			this.Name = name;
			this.Email = email;
			this.GroupId = groupId;
		}
	}
}