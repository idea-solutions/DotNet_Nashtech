using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Assignment02.Services
{
    public class CreateMemberRequest
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(10)]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public int? Gender { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }

    }
}