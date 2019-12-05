using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using stable.Models.StudentScores;

namespace stable.Models.Scores {
	public class Score {
		public int Id { get; set; }

		// [Range (0, 100)]
		[Remote (action: "VerifyScorePercent", controller: "Score")]
		public int Percent { get; set; }
		public List<StudentScore> StudentScores { get; set; }
	}
}