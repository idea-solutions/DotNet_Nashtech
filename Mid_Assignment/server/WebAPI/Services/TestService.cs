using Microsoft.EntityFrameworkCore;

using Data;
using Data.Entities;

namespace WebAPI.Services
{
    public class TestService : ITestService
    {
        private DataContext _context;

        public TestService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> Get()
        {
            var people = await _context.People.ToListAsync();
            return people;
        }

        public async Task Add()
        {
            var p = new Person()
            {
                Name = "Hoan",
                Age = 22,
                Dob = DateTime.Now,
                Gender = Common.Enums.GenderEnum.Male,
                EmailAddress = "test@gmail.com",
                LicenseId = "license to kill"
            };
            await _context.People.AddAsync(p);
            await _context.SaveChangesAsync();
        }
    }
}
