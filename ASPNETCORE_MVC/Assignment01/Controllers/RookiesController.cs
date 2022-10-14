using Microsoft.AspNetCore.Mvc;
using Assignment01.Models;
using CsvHelper;
using System.Globalization;

namespace Assignment01.Controllers
{
    [Route("Nashtech/Rookies")]
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        private static List<MemberModel> _members = new List<MemberModel> {
                new MemberModel{
                    FirstName = "Hoan",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000,11,09),
                    PhoneNumber = "0123456789",
                    BirthPlace = "Thai Binh",
                    IsGraduated = true
                },
                new MemberModel{
                    FirstName = "Huy",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2001,01,01),
                    PhoneNumber = "9876543210",
                    BirthPlace = "Bac Ninh",
                    IsGraduated = false
                },
                new MemberModel{
                    FirstName = "Trang",
                    LastName = "Pham Thuy",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998,05,07),
                    PhoneNumber = "01213141516",
                    BirthPlace = "Ha Noi",
                    IsGraduated = true
                }
            };

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Json(_members);
        }

        [HttpGet("ListMale")]
        public IActionResult ListMale()
        {
            var data = _members.Where(member => member.Gender == "Male");
            return Json(data);
        }

        [HttpGet("OldestMember")]
        public IActionResult OldestMember()
        {
            var data = _members.Where(member => member.Gender == "Male");
            var maxAge = _members.Max(member => member.Age);
            MemberModel oldestMember = _members.First(m => m.Age == maxAge);
            return Json(oldestMember);
        }

        [HttpGet("ListFullNameMember")]
        public IActionResult ListFullNameMember()
        {
            var fullNames = _members.Select(member => member.FullName);
            return Json(fullNames);
        }

        [HttpGet("ListMembersByBirthYear")]
        public IActionResult ListMembersByBirthYear([FromQuery] int year, [FromQuery] string compareType)
        {
            switch (compareType)
            {
                case "equals":
                    return Json(_members.Where(p => p.DateOfBirth.Year == year));
                case "greaterThan":
                    return Json(_members.Where(p => p.DateOfBirth.Year < year));
                case "lessThan":
                    return Json(_members.Where(p => p.DateOfBirth.Year > year));
                default:
                    return Json(null);
            }
        }

        [HttpGet("MembersWhoBornIn2000")]
        public IActionResult MembersWhoBornIn2000()
        {
            return RedirectToAction("ListMembersByBirthYear", new { year = 2000, compareType = "equals" });
        }

        [HttpGet("MembersWhoBornAfter2000")]
        public IActionResult MembersWhoBornAfter2000()
        {
            return RedirectToAction("ListMembersByBirthYear", new { year = 2000, compareType = "lessThan" });
        }

        [HttpGet("MembersWhoBornBefore2000")]
        public IActionResult MembersWhoBornBefore2000()
        {
            return RedirectToAction("ListMembersByBirthYear", new { year = 2000, compareType = "greaterThan" });
        }

        [HttpGet("ExportDataToCsv")]
        public FileStreamResult ExportDataToCsv()
        {
            var result = WriteCsvToMemory(_members);
            var memoryStream = new MemoryStream(result);
            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "export.csv" };
        }

        public byte[] WriteCsvToMemory(IEnumerable<MemberModel> _people)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(_people);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}