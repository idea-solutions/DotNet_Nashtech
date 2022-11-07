using System.ComponentModel.DataAnnotations;
using Common.Enums;
using Data.Entities;

namespace WebAPI.Models
{
    public class UserModel : BaseEntity<int>
    {
        [Required, MaxLength(50)]
        public RolesEnum Role { get; set; }
    }
}