using stable.Models.Syllabuses;

namespace stable.Models.Subjects {
	public class Subject {
		public int Id { get; set; }
		public string Name { get; set; }
		public int SyllabusId { get; set; }
		public Syllabus Syllabus { get; set; }
	}
}