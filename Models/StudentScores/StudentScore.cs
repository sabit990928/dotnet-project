using stable.Models.Scores;
using stable.Models.Students;

namespace stable.Models.StudentScores {
	public class StudentScore {
		public int id { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int ScoreId { get; set; }
		public Score Score { get; set; }
	}
}