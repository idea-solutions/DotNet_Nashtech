using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.Services
{
    public class CreateMemberRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Gender { get; set; }
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }

    }
}