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

    // [HttpGet]
    // public GetAllStudentsResponse GetAll()
    // {

    //     return _studentService.GetAll();
       
    // }

    // [HttpGet("{id}", Name="GetById")]
    // public ActionResult<StudentViewModel> GetById(int id)
    // {
    //     try
    //     {
    //         var student = _studentService.GetById(id);

    //         return student != null ? Ok(student) : NotFound();
    //     }
    //     catch (Exception exception)
    //     {
    //         return HandleException(exception);
    //     }
    // }

    // [HttpPost]
    // public ActionResult<StudentViewModel> Create([FromBody] StudentCreateModel createModel)
    // {
    //     if (createModel == null) return BadRequest();

    //     try
    //     {
    //         var createdId = _studentService.Create(createModel);

    //         return createdId != null
    //             ? CreatedAtRoute(nameof(GetById), new { id = createdId }, null)
    //             : StatusCode(500);
    //     }
    //     catch (Exception exception)
    //     {
    //         return HandleException(exception);
    //     }
    // }

    // [HttpPut("{id}")]
    // public ActionResult<StudentViewModel> Update(int id, [FromBody] StudentUpdateModel updateModel)
    // {
    //     if (updateModel == null) return BadRequest();

    //     try
    //     {
    //         var updatedStudent = _studentService.Update(id, updateModel);

    //         return updatedStudent != null ? Ok(updatedStudent) : StatusCode(500);
    //     }
    //     catch (Exception exception)
    //     {
    //         return HandleException(exception);
    //     }
    // }

    // [HttpDelete("{id}")]
    // public ActionResult Delete(int id)
    // {
    //     try
    //     {
    //         var isSucceeded = _studentService.Delete(id);

    //         return isSucceeded ? NoContent() : StatusCode(500);
    //     }
    //     catch (Exception exception)
    //     {
    //         return HandleException(exception);
    //     }
    // }

    // private ActionResult HandleException(Exception exception)
    // {
    //     Console.WriteLine(exception);

    //     return StatusCode(500, "Unexpected Error!");
    // }
}