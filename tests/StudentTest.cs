using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using stable.Data;
using stable.Models.Students;
using stable.Services;
using Xunit;

namespace Tests {
    public class StudentTest {

        List<Student> students = new List<Student> {
            new Student (1, "Alex", "alex@iitu.kz", 2)
        };
        Mock<IStudentRepo> studentRepository;
        StudentService studentService;
        Student test = new Student (1, "Alex", "alex@iitu.kz", 2);
        [Fact]
        public async Task GetStudentsTest () {
            var result = await studentService.getStudents ();
            Assert.Collection (result, student => {
                    Assert.Equal (students[0].Name, student.Name);
                },
                student => {
                    Assert.Equal (students[1].Email, student.Email);
                });
        }

        [Fact]
        public async Task AddStudentTest () {
            var student = new Student (1, "Alex", "alex@iitu.kz", 2);
            await studentService.createStudent (student);
        }

        [Fact]
        public async Task GetDetailTest () {
            var id = 1;
            await studentService.getStudent (id);
        }

        [Fact]
        public async Task DeleteStudentTest () {
            var student = new Student (1, "Alex", "alex@iitu.kz", 2);
            await studentService.Delete (student);
        }

    }
}