using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using stable.Models.Students;

namespace stable.Models.Groups {
	public class Group {
		public int Id { get; set; }

		[Range (1, 9999)]

		public int GroupNumber { get; set; }
		public List<Student> Students { get; set; }

		public Group () { }

		public Group (int id, int groupNumber) {
			this.Id = id;
			this.GroupNumber = groupNumber;
		}
	}
}