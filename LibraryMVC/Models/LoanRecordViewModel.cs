namespace LibraryMVC.Models
{
    public class LoanRecordViewModel
    {
        public IEnumerable<LibraryMember> LibraryMembers { get; set; }
        public IEnumerable<LoanRecord> LoanRecords { get; set; }
        public IEnumerable<BookItem> BookItems { get; set; }

        public LoanRecord LoanRecord { get; set; }
    }
}
