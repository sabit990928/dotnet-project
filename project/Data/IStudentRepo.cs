using System.Collections.Generic;
using System.Threading.Tasks;
using stable.Models.Students;

namespace stable.Data {
	public interface IStudentRepo {
		Task<List<Student>> getStudents ();
		Task<Student> getStudent (int? id);
		Task createStudent (Student student);
		Task editStudent (Student student);
		Task deleteStudent (Student student);
		Task<Student> findStudent (int? id);
		bool studentExists (int id);
	}
}