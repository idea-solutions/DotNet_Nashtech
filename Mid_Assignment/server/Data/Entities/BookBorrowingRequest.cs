
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Data.Entities
{
    public class BookBorrowingRequest : BaseEntity<int>
    {
        [Required, DefaultValue(RequestStatusEnum.Waiting)]
        public RequestStatusEnum Status { get; set; }
        [Required]
        public int RequestedByUserId { get; set; }
        public virtual User? RequestedBy { get; set; }
        public DateTime DateRequested { get; set; }
        public int? StatusUpdateByUserId { get; set; }
        public virtual User? StatusUpdateBy { get; set; }
        public ICollection<BookBorrowingRequestDetails>? RequestDetails { get; set; }
    }
}