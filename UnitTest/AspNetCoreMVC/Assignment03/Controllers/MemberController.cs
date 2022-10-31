using Microsoft.AspNetCore.Mvc;
using Assignment03.Services;
namespace Assignment03.Controllers
{
    [Route("[controller]")]
    public class MemberController : Controller
    {

        private readonly IServices _service;

        public MemberController(IServices service)
        {
            _service = service;
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

        [HttpGet("Details")]
        public IActionResult Details(int index)
        {
            if (index >= 0 && index < _service.GetListMember().Count)
            {
                var member = _service.GetOneMember(index);
                var model = new MemberDetailsModel
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Gender = member.Gender,
                    DateOfBirth = member.DateOfBirth,
                    PhoneNumber = member.PhoneNumber,
                    BirthPlace = member.BirthPlace
                };

                ViewData["Index"] = index;

                return View(model);
            }

            return View();
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (index >= 0 && index < _service.GetListEdit().Count)
            {
                _service.UpdateMember(index, model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < _service.GetListMember().Count)
            {
                _service.DeleteMember(index);
            }

            return RedirectToAction("Index");
        }

        [HttpPost("DeleteAndRedirectToResultView")]
        public IActionResult DeleteAndRedirectToResultView(int index)
        {
            if (index >= 0 && index < _service.GetListMember().Count)
            {
                // TempData["DeleteNameMember"] = _service.GetOneMember(index).FullName;
                HttpContext.Session.SetString("DeleteNameMember", _service.GetOneMember(index).FullName);
                _service.DeleteMember(index);
            }

            return RedirectToAction("DeleteResult");
        }

        [HttpGet("DeleteResult")]
        public IActionResult DeleteResult()
        {
            ViewBag.DeleteNameMember = HttpContext.Session.GetString("DeleteNameMember") ?? "unknown";
            return View();
        }
    }
}