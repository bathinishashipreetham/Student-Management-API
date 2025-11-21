using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Data;
using StudentManagement.API.Models;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = InMemoryStudentStore.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = InMemoryStudentStore.GetStudentById(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            InMemoryStudentStore.AddStudent(student);
            return Created($"api/student/{student.Id}", student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            InMemoryStudentStore.UpdateStudent(id, student);
            return Ok($"Student {id} updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            InMemoryStudentStore.DeleteStudent(id);
            return Ok($"Student {id} deleted successfully");
        }
    }
}
