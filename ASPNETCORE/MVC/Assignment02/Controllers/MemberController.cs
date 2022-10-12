using Microsoft.AspNetCore.Mvc;
using Assignment02.Services;
namespace Assignment02.Controllers
{
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        private readonly MemberService _service;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
            _service = new MemberService();
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(_service.GetListMember());
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateMemberRequest request)
        {
            if (ModelState.IsValid)
            {
                _service.AddMember(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}