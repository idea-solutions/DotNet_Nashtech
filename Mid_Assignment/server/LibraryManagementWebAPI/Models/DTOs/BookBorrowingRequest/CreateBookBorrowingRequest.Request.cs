using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest
{
    public class CreateBookBorrowingRequestRequest
    {
        [Required]
        public List<int>? BookIds { get; set; }

        [JsonIgnore]
        public UserModel? RequestedBy { get; set; }
    }
}