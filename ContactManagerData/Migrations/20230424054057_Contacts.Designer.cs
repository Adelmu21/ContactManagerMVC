﻿// <auto-generated />
using System;
using ContactsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactsData.Migrations
{
    [DbContext(typeof(ContactsContext))]
    [Migration("20230424054057_Contacts")]
    partial class Contacts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContactsData.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "Friend",
                            Name = "Friend"
                        },
                        new
                        {
                            CategoryId = "Work",
                            Name = "Work"
                        },
                        new
                        {
                            CategoryId = "Family",
                            Name = "Family"
                        });
                });

            modelBuilder.Entity("ContactsData.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            CategoryId = "Friend",
                            Created = new DateTime(2023, 4, 23, 23, 40, 57, 9, DateTimeKind.Local).AddTicks(4760),
                            Email = "osten26@yahoo.com",
                            FirstName = "Steve",
                            LastName = "Osten",
                            Phone = "587-654-1111"
                        },
                        new
                        {
                            ContactId = 2,
                            CategoryId = "Work",
                            Created = new DateTime(2023, 4, 23, 23, 40, 57, 9, DateTimeKind.Local).AddTicks(4764),
                            Email = "wandaring@outlook.com",
                            FirstName = "Wanda",
                            LastName = "Suther",
                            Phone = "825-623-4548"
                        },
                        new
                        {
                            ContactId = 3,
                            CategoryId = "Family",
                            Created = new DateTime(2023, 4, 23, 23, 40, 57, 9, DateTimeKind.Local).AddTicks(4767),
                            Email = "marks0n.m@gmail.com",
                            FirstName = "Marvin",
                            LastName = "Markson",
                            Phone = "780-961-2526"
                        });
                });

            modelBuilder.Entity("ContactsData.Contact", b =>
                {
                    b.HasOne("ContactsData.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
