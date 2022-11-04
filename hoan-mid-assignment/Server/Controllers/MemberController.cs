using Microsoft.AspNetCore.Mvc;
using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;

namespace AspNetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IMemberService _memberServices;

        public TaskController(ILogger<TaskController> logger, IMemberService taskServices)
        {
            _logger = logger;
            _memberServices = taskServices;
        }


        [HttpGet]
        [Route("list-pagnition")]
        public IActionResult GetListPagnition([FromQuery] Pagnition pagnition)
        {
            var data = _memberServices.GetPagnition(pagnition);
            return Ok(data);
        }

        [HttpGet()]
        public IActionResult GetAll(string? name, string? gender, string? birthPlace)
        {
            try
            {
                var data = _memberServices.GetAll(name, gender, birthPlace);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _memberServices.GetOne(id);

                return data != null ? Ok(data) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }



        [HttpPut("{id}")]
        public IActionResult Update(Guid id, MemberRequestModel model)
        {
            // TODO: Validate request model

            try
            {
                var data = _memberServices.Update(id, model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            // TODO: Validate request model

            try
            {
                _memberServices.Delete(id);
                return Ok($"Done Delete: {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MemberRequestModel requestModel)
        {
            // TODO: Validate request model
            if (requestModel == null) return BadRequest();

            try
            {
                _memberServices.Create(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // [HttpGet]
        // [Route("filter-list")]
        // public List<MemberRequestModel> GetFilterList(string? firstName, string? lastName, string? gender, string? birthPlace)
        // {
        //     return _memberServices.FilterList(firstName, lastName, gender, birthPlace);
        // }
    }
}