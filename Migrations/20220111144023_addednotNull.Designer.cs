﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlutuppgiftDatabasLotta.Data;

namespace SlutuppgiftDatabasLotta.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220111144023_addednotNull")]
    partial class addednotNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lent")
                        .HasColumnType("bit");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("YearOfIssue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Book_Author", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BooksAndAuthor");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Customer", b =>
                {
                    b.Property<int>("CardNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Customer_Book", b =>
                {
                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CardNumber", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("CustomerAndBooks");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Book_Author", b =>
                {
                    b.HasOne("SlutuppgiftDatabasLotta.Models.Author", "Author")
                        .WithMany("Book_Author")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlutuppgiftDatabasLotta.Models.Book", "Book")
                        .WithMany("Book_Author")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Customer_Book", b =>
                {
                    b.HasOne("SlutuppgiftDatabasLotta.Models.Book", "Book")
                        .WithMany("Customer_Book")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SlutuppgiftDatabasLotta.Models.Customer", "Customer")
                        .WithMany("Customer_Book")
                        .HasForeignKey("CardNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Author", b =>
                {
                    b.Navigation("Book_Author");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Book", b =>
                {
                    b.Navigation("Book_Author");

                    b.Navigation("Customer_Book");
                });

            modelBuilder.Entity("SlutuppgiftDatabasLotta.Models.Customer", b =>
                {
                    b.Navigation("Customer_Book");
                });
#pragma warning restore 612, 618
        }
    }
}
