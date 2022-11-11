using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace LibraryManagement.Data.Entities
{
    public class BookBorrowingRequest : BaseEntity<int>
    {
        // public BookBorrowingRequest()
        // {
        //     RequestDetails = new List<BookBorrowingRequestDetails>();
        // }

        [Required, DefaultValue(RequestStatusEnum.Waiting)]
        public RequestStatusEnum Status { get; set; }
        [Required]
        public int RequestedByUserId { get; set; }
        public virtual User? RequestedBy { get; set; }
        public DateTime DateRequested { get; set; }
        public int? StatusUpdateByUserId { get; set; }
        public virtual User? StatusUpdateBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        // public ICollection<BookBorrowingRequestDetails>? RequestDetails { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}