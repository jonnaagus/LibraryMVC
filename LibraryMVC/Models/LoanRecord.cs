using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class LoanRecord
    {
        public int LoanRecordId { get; set; }
        [Required]
        public int LibraryMemberId { get; set; }
        public int BookItemId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned => ReturnDate.HasValue;
        public LibraryMember LibraryMember { get; set; }
        public BookItem BookItem { get; set; }
    }
}
