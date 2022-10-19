using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Models;
using EntityFrameworkCore.Services;

namespace EntityFrameworkCore.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public AddStudentResponse Add([FromBody] AddStudentRequest addRequest)
    {
        return _studentService.Create(addRequest);
    }

    [HttpGet]
    public IEnumerable<Student> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpGet("{id}", Name = "GetById")]
    public Student? GetById(int id)
    {
        return _studentService.GetOne(id);
    }
}