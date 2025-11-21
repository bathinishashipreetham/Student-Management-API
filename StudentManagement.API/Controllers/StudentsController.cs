using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Data;
using StudentManagement.API.Models;

namespace StudentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(InMemoryStudentStore.Students);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Student> GetById(Guid id)
        {
            var student = InMemoryStudentStore.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> Create([FromBody] Student student)
        {
            InMemoryStudentStore.Students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] Student updated)
        {
            var student = InMemoryStudentStore.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.FirstName = updated.FirstName;
            student.LastName = updated.LastName;
            student.Email = updated.Email;
            student.DateOfBirth = updated.DateOfBirth;
            student.Course = updated.Course;

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var student = InMemoryStudentStore.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            InMemoryStudentStore.Students.Remove(student);
            return NoContent();
        }
    }
}
