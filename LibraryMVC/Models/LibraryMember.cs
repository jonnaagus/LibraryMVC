using LibraryMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class LibraryMember
    {
        public int LibraryMemberId { get; set; }

        [Required(ErrorMessage = "Förnamn måste anges")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Telefonnummer måste anges")]        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-postadress måste anges")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress")]
        public string EmailAddress { get; set; }

        // Navigation property to access related LoanRecords
        public ICollection<LoanRecord> LoanRecords { get; set; }
    }
}