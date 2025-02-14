﻿// <auto-generated />
using System;
using LibraryMVC.Data.Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240531135331_3tablesanddata")]
    partial class _3tablesanddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryMVC.Models.BookItem", b =>
                {
                    b.Property<int>("BookItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookItemId"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookItemId");

                    b.ToTable("BookItems");

                    b.HasData(
                        new
                        {
                            BookItemId = 1,
                            Available = true,
                            PublicationDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter och de vises sten",
                            Writer = "J.K. Rowling"
                        },
                        new
                        {
                            BookItemId = 2,
                            Available = true,
                            PublicationDate = new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Brott och straff",
                            Writer = "Fjodor Dostojevskij"
                        },
                        new
                        {
                            BookItemId = 3,
                            Available = true,
                            PublicationDate = new DateTime(1973, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Bröderna Lejonhjärta",
                            Writer = "Astrid Lindgren"
                        },
                        new
                        {
                            BookItemId = 4,
                            Available = true,
                            PublicationDate = new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hundraåringen som klev ut genom fönstret och försvann",
                            Writer = "Jonas Jonasson"
                        });
                });

            modelBuilder.Entity("LibraryMVC.Models.LibraryMember", b =>
                {
                    b.Property<int>("LibraryMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibraryMemberId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibraryMemberId");

                    b.ToTable("LibraryMembers");

                    b.HasData(
                        new
                        {
                            LibraryMemberId = 1,
                            EmailAddress = "jonna@hotmail.com",
                            FirstName = "Jonna",
                            LastName = "Gustafsson",
                            PhoneNumber = "0722011717"
                        },
                        new
                        {
                            LibraryMemberId = 2,
                            EmailAddress = "wille@hotmail.com",
                            FirstName = "Wille",
                            LastName = "Hellström",
                            PhoneNumber = "0727143468"
                        },
                        new
                        {
                            LibraryMemberId = 3,
                            EmailAddress = "lizzie@hotmail.com",
                            FirstName = "Lizzie",
                            LastName = "Söderberg",
                            PhoneNumber = "0730587700"
                        });
                });

            modelBuilder.Entity("LibraryMVC.Models.LoanRecord", b =>
                {
                    b.Property<int>("LoanRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanRecordId"));

                    b.Property<int>("BookItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LibraryMemberId")
                        .HasColumnType("int");

                    b.Property<int>("LibraryMemberId")
                        .HasColumnType("int");

                    b.HasKey("LoanRecordId");

                    b.HasIndex("BookItemId");

                    b.HasIndex("LibraryMemberId");

                    b.ToTable("LoanRecords");
                });

            modelBuilder.Entity("LibraryMVC.Models.LoanRecord", b =>
                {
                    b.HasOne("LibraryMVC.Models.BookItem", "BookItem")
                        .WithMany()
                        .HasForeignKey("BookItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryMVC.Models.LibraryMember", "LibraryMember")
                        .WithMany()
                        .HasForeignKey("LibraryMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookItem");

                    b.Navigation("LibraryMember");
                });
#pragma warning restore 612, 618
        }
    }
}
