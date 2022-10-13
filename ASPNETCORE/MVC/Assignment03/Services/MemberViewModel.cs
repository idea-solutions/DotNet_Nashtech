using System.ComponentModel;

namespace Assignment03.Services
{
    public class MemberViewModel
    {

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public string? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }
        public int Age { get; set; }
    }
}