using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseInMemoryDatabase("StudentsDb"));

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
