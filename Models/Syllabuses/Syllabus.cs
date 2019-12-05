using stable.Models.Subjects;

namespace stable.Models.Syllabuses {
	public class Syllabus {
		public int Id { get; set; }
		public int Semester { get; set; }
		// public int SubjectId {get; set}
		public Subject Subject { get; set; }
	}
}