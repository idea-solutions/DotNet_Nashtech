using EntityFrameworkCore.Data;
using EntityFrameworkCore.Models;
using EntityFrameworkCore.Repositories;
using EntityFrameworkCore.Services;
// using EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();


builder.Services.AddDbContext<StudentManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
