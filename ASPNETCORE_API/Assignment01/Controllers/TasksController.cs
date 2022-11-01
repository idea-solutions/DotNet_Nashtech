using Assignment01.Models;
using Assignment01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;

    private readonly ITaskService _service;

    public TasksController(ILogger<TasksController> logger, ITaskService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet()]
    public IActionResult GetAll()
    {
        try
        {
            var data = _service.GetAll();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpGet("{id}")]
    public IActionResult GetOne(Guid id)
    {
        try
        {
            var data = _service.GetOne(id);

            return data != null ? Ok(data) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TaskModel requestModel)
    {
        // TODO: Validate request model
        if (requestModel == null) return BadRequest();

        try
        {
            _service.AddTask(requestModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(Guid id)
    {
        // TODO: Validate request model

        try
        {
            _service.DeleteTask(id);
            return Ok($"Done Delete: {id}");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{id}")]
    public IActionResult EditTask(Guid id, [FromBody] TaskModel requestModel)
    {
        // TODO: Validate request model

        try
        {
            var data = _service.EditTask(id, requestModel);
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpPost]
    [Route("add-multi")]
    public IActionResult AddMultiple(List<TaskModel> taskModels)
    {
        // TODO: Validate request model

        try
        {
            var data = _service.AddMulti(taskModels);

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpDelete]
    [Route("delete-multi")]
    public IActionResult DeleteMultiple([FromBody] List<Guid> Ids)
    {
        // TODO: Validate request model

        try
        {
            _service.DeleteMulti(Ids);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

}
