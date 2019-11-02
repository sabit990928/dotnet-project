using System.Collections.Generic;
using stable.Models.StudentScores;

namespace stable.Models.Scores {
	public class Score {
		public int Id { get; set; }
		public int Percent { get; set; }
		public List<StudentScore> StudentScores { get; set; }
	}
}