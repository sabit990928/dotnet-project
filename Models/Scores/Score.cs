using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using stable.Models.StudentScores;

namespace stable.Models.Scores {
	public class Score {
		public int Id { get; set; }

		[Range (0, 100)]

		public int Percent { get; set; }
		public List<StudentScore> StudentScores { get; set; }
	}
}