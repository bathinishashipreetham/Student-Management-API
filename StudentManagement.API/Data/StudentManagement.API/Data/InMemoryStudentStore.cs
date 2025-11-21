using System.Collections.Generic;
using System.Linq;
using StudentManagement.API.Models;

namespace StudentManagement.API.Data
{
    public static class InMemoryStudentStore
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Rahul", Age = 20, Email = "rahul@example.com" },
            new Student { Id = 2, Name = "Priya", Age = 21, Email = "priya@example.com" }
        };

        public static List<Student> GetAllStudents() => students;

        public static Student GetStudentById(int id) =>
            students.FirstOrDefault(s => s.Id == id);

        public static void AddStudent(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
        }

        public static void UpdateStudent(int id, Student updatedStudent)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Age = updatedStudent.Age;
                existingStudent.Email = updatedStudent.Email;
            }
        }

        public static void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}

