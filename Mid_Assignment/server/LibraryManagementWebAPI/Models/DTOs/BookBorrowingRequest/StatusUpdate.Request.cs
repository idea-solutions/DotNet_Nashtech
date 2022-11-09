using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagementWebAPI.Models.DTOs.BookBorrowingRequest
{
    public class StatusUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsUpdated { get; set; }

        [JsonIgnore] 
        public UserModel? StatusUpdateBy { get; set; }

    }
}