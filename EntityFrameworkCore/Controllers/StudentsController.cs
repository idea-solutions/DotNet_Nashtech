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
    public IEnumerable<GetStudentResponse> GetAll()
    {
        return _studentService.GetAll();
    }

    [HttpGet("{id}", Name = "GetById")]
    public GetStudentResponse? GetById(int id)
    {
        return _studentService.GetOne(id);
    }

    [HttpPut("{id}", Name = "Update")]
    public UpdateStudentResponse? Update(int id, [FromBody] UpdateStudentRequest updateModel)
    {
        return _studentService.Update(id, updateModel);
    }

    [HttpDelete("{id}", Name = "Delete")]
    public bool Delete(int id)
    {
        return _studentService.Delete(id);
    }

}