using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class BookItem
    {
        public int BookItemId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Writer { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool Available { get; set; }
    }
}
