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
            return Ok(data);
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

    [HttpPut]
    public IActionResult EditTask([FromBody] TaskModel requestModel)
    {
        // TODO: Validate request model

        try
        {
            var data = _service.EditTask(requestModel);
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



    // [HttpPost("/v1/bulk")]
    // public IActionResult CreateBulkTask_V1([FromBody] List<NewTaskRequestModel> requestModel)
    // {

    //     // TODO: Validate request model

    //     try
    //     {
    //         // TODO: Create new Task request model
    //         createMultiTask_V1(requestModel);

    //         return Accepted();
    //     }
    //     catch (Exception ex)
    //     {

    //         return StatusCode(StatusCodes.Status500InternalServerError, ex);
    //     }
    // }

    // [HttpPost("/v2/bulk")]
    // public async Task<IActionResult> CreateBulkTask_V2([FromBody] List<NewTaskRequestModel> requestModel)
    // {

    //     // TODO: Validate request model

    //     try
    //     {
    //         // TODO: Create new Task request model
    //         await createMultiTask_V1(requestModel);

    //         return Ok();
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(StatusCodes.Status500InternalServerError, ex);
    //     }
    // }


    // private Task createMultiTask_V1(List<NewTaskRequestModel> requestModel)
    // {
    //     foreach (var item in requestModel)
    //     {
    //         CreateANewTask__Service(item);
    //     }

    //     // TODO: Notify result to client: send emails,...
    //     _ = SendEmail();

    //     return Task.CompletedTask;
    // }


    // private void CreateANewTask__Service(NewTaskRequestModel requestModel)
    // {
    //     System.Threading.Thread.Sleep(10);
    // }

    // private Task SendEmail()
    // {
    //     // TODO: handle Send Email...

    //     return Task.CompletedTask;
    // }
}
