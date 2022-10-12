using Microsoft.AspNetCore.Mvc;
using Assignment02.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        [HttpGet("Edit")]
        public IActionResult Edit(int index)
        {
            if (index >= 0 && index < _service.GetListEdit().Count)
            {
                var member = _service.GetListEdit()[index];
                var model = new EditMemberViewModel
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    PhoneNumber = member.PhoneNumber,
                    BirthPlace = member.BirthPlace
                };

                ViewData["Index"] = index;
                return View(model);
            }

            return View();
        }

        [HttpPost("Update")]
        public IActionResult Update(int index, EditMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (index >= 0 && index < _service.GetListMember().Count)
                {
                    var member = _service.GetListMember()[index];

                    member.FirstName = model.FirstName;
                    member.LastName = model.LastName;
                    member.PhoneNumber = model.PhoneNumber;
                    member.BirthPlace = model.BirthPlace;

                    // TODO
                    // foreach (var item in _service.GetListMember())
                    // {
                    //     Console.WriteLine(JsonSerializer.Serialize(item));
                    // }

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < _service.GetListMember().Count)
            {
                _service.GetListMember().RemoveAt(index);

                foreach (var item in _service.GetListMember())
                {
                    Console.WriteLine(JsonSerializer.Serialize(item));
                }
            }
            return RedirectToAction("Index");
        }
    }
}