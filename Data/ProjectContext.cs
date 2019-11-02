using Microsoft.EntityFrameworkCore;
using stable.Models.Departments;
using stable.Models.Groups;
using stable.Models.Scores;
using stable.Models.Students;
using stable.Models.StudentScores;
using stable.Models.Subjects;
using stable.Models.Syllabuses;
using stable.Models.Teachers;
public class ProjectContext : DbContext {
	public ProjectContext (DbContextOptions options) : base (options) { }

	public DbSet<Department> Departments { get; set; }
	public DbSet<Group> Groups { get; set; }
	public DbSet<Score> Scores { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<StudentScore> StudentScores { get; set; }
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<Syllabus> Syllabuss { get; set; }
	public DbSet<Teacher> Teachers { get; set; }

}