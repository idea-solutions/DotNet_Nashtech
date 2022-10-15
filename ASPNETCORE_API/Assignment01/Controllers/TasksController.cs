using Assignment01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/newTask")]
    public IActionResult CreateNewTask([FromBody] NewTaskRequestModel requestModel)
    {
        if (string.IsNullOrWhiteSpace(requestModel.Title))
        {
            return BadRequest("No Title");
        }

        requestModel.Title = requestModel.Title.Trim();
        if (requestModel.Title.Length < 5)
        {
            return BadRequest("Length Title Error");
        }
        try
        {
            var newID = 1;
            return Ok(newID);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Example Database Error");
        }
    }
}
