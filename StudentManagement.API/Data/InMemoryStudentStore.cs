using StudentManagement.API.Models;

namespace StudentManagement.API.Data
{
    public static class InMemoryStudentStore
    {
        public static List<Student> Students { get; } = new List<Student>()
        {
            new Student { FirstName = "Rahul", LastName = "K", Email = "rahul@example.com", DateOfBirth = new DateTime(2000,1,1), Course = "CS" },
            new Student { FirstName = "Anita", LastName = "P", Email = "anita@example.com", DateOfBirth = new DateTime(2001,5,20), Course = "EE" }
        };
    }
}
