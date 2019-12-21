using System;
using System.ComponentModel.DataAnnotations;

namespace stable.Utils {
	public class ValidTeacherDomainAttribute : ValidationAttribute {
		private readonly string iituDomain;

		public ValidTeacherDomainAttribute (string iituDomain) {
			this.iituDomain = iituDomain;
		}

		public override bool IsValid (object value) {
			string[] strings = value.ToString ().Split ('@');
			return strings[1].ToUpper () == iituDomain.ToUpper ();
		}
	}
}