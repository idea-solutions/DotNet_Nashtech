using System.ComponentModel.DataAnnotations;
using Common.Enums;
using LibraryManagement.Data.Entities;

namespace LibraryManagementWebAPI.Models
{
    public class UserModel : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public RolesEnum Role { get; set; }
    }
}