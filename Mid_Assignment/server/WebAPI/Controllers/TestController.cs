using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok("Test");
        }

        [HttpGet("get")]
        public async Task<ActionResult> Get()
        {
            var result = await _testService.Get();
            return Ok(result);
        }

        [HttpPost("post")]
        public async Task<ActionResult> Post()
        {
            await _testService.Add();
            return Accepted();
        }
    }
}
