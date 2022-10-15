using Assignment01.DataAccess;
using Assignment01.Models;
using Assignment01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly ILogger<MembersController> _logger;

    private readonly IServices _service;

    public MembersController(ILogger<MembersController> logger, IServices service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet()]
    public IActionResult GetAll()
    {
        var data = _service.GetListMember();

        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        try
        {
            var data = _service.GetOneMember(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost("")]
    public IActionResult Create([FromBody] CreateMemberRequest requestModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            _service.AddMember(requestModel);
            var IdMember = new { id = 10 };
            return new JsonResult(IdMember);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
