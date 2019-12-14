using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using stable.Models.Teachers;

namespace stable.Models.Departments {
	public class Department : IValidatableObject {
		public int Id { get; set; }
		public string Name { get; set; }

		public IEnumerable<ValidationResult> Validate (ValidationContext validationContext) {
			var results = new List<ValidationResult> ();
			if (!IsValidDepartment (Name)) {
				results.Add (new ValidationResult ("Invalid department name"));
			}
			return results;
		}

		bool IsValidDepartment (string departmentName) {
			foreach (var item in Enum.GetValues (typeof (DepartmentNames))) {
				if (string.Equals (departmentName.Trim (), $"{item}", StringComparison.CurrentCultureIgnoreCase)) {
					return true;
				}
			}
			return false;
		}
		public enum DepartmentNames {
			MCM,
			CIandIS,
			IS,
			JUR,
			FIN
		}

		public List<Teacher> Teachers { get; set; }
	}
}