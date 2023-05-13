using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsData.Migrations
{
    public partial class Contacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "Family", "Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "Friend", "Friend" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "Work", "Work" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "Created", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "Friend", new DateTime(2023, 4, 23, 23, 40, 57, 9, DateTimeKind.Local).AddTicks(4760), "osten26@yahoo.com", "Steve", "Osten", "587-654-1111" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "Created", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, "Work", new DateTime(2023, 4, 23, 23, 40, 57, 9, DateTimeKind.Local).AddTicks(4764), "wandaring@outlook.com", "Wanda", "Suther", "825-623-4548" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "Created", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 3, "Family", new DateTime(2023, 4, 23, 23, 40, 57, 9, DateTimeKind.Local).AddTicks(4767), "marks0n.m@gmail.com", "Marvin", "Markson", "780-961-2526" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
