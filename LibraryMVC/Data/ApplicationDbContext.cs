namespace LibraryMVC.Data
{
    using LibraryMVC.Models;
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    namespace Library.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }

            public DbSet<BookItem> BookItems { get; set; }
            public DbSet<LibraryMember> LibraryMembers { get; set; }
            public DbSet<LoanRecord> LoanRecords { get; set; }

            //Adding data to tables
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                var member1 = new LibraryMember
                {
                    LibraryMemberId = 1,
                    FirstName = "Jonna",
                    LastName = "Gustafsson",                    
                    PhoneNumber = "0722011717",
                    EmailAddress = "jonna@hotmail.com"
                };

                var member2 = new LibraryMember
                {
                    LibraryMemberId = 2,
                    FirstName = "Wille",
                    LastName = "Hellström",
                    PhoneNumber = "0727143468",
                    EmailAddress = "wille@hotmail.com"
                };

                var member3 = new LibraryMember
                {
                    LibraryMemberId = 3,
                    FirstName = "Lizzie",
                    LastName = "Söderberg",
                    PhoneNumber = "0730587700",
                    EmailAddress = "lizzie@hotmail.com"
                };

                var book1 = new BookItem
                {
                    BookItemId = 1,
                    Title = "Harry Potter och de vises sten",
                    Writer = "J.K. Rowling",
                    PublicationDate = new DateTime(1997, 06, 26),
                    Available = false
                };

                var book2 = new BookItem
                {
                    BookItemId = 2,
                    Title = "Brott och straff",
                    Writer = "Fjodor Dostojevskij",
                    PublicationDate = new DateTime(1866, 01, 01),
                    Available = false
                };

                var book3 = new BookItem
                {
                    BookItemId = 3,
                    Title = "Bröderna Lejonhjärta",
                    Writer = "Astrid Lindgren",
                    PublicationDate = new DateTime(1973, 10, 01),
                    Available = true
                };

                var book4 = new BookItem
                {
                    BookItemId = 4,
                    Title = "Hundraåringen som klev ut genom fönstret och försvann",
                    Writer = "Jonas Jonasson",
                    PublicationDate = new DateTime(2009, 01, 01),
                    Available = false
                };

                var loan1 = new LoanRecord
                {
                    LoanRecordId = 1,
                    LibraryMemberId = 1,
                    BookItemId = 2,
                    BorrowDate = DateTime.Now.AddDays(-5),
                    ReturnDate = DateTime.Now.AddDays(40)
                };

                var loan2 = new LoanRecord
                {
                    LoanRecordId = 2,
                    LibraryMemberId = 2,
                    BookItemId = 1,
                    BorrowDate = DateTime.Now.AddDays(-12), 
                    ReturnDate = DateTime.Now.AddDays(40)
                };

                var loan3 = new LoanRecord
                {
                    LoanRecordId = 3,
                    LibraryMemberId = 3,
                    BookItemId = 4,
                    BorrowDate = DateTime.Now.AddDays(-10), 
                    ReturnDate = DateTime.Now.AddDays(40)
                };

                modelBuilder.Entity<LibraryMember>().HasData(member1, member2, member3);
                modelBuilder.Entity<BookItem>().HasData(book1, book2, book3, book4);
                modelBuilder.Entity<LoanRecord>().HasData(loan1, loan2, loan3);

                base.OnModelCreating(modelBuilder);
            }
        }

    }
}
