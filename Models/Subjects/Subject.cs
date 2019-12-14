using System.ComponentModel.DataAnnotations;
using stable.Models.Syllabuses;

namespace stable.Models.Subjects {
	public class Subject {
		public int Id { get; set; }

		[Required]
		[StringLength (100)]
		public string Name { get; set; }
		public int SyllabusId { get; set; }
		public Syllabus Syllabus { get; set; }

		public Subject () { }

		public Subject (int id, string name, int syllabusId) {
			this.Id = id;
			this.Name = name;
			this.SyllabusId = syllabusId;
		}
	}
}