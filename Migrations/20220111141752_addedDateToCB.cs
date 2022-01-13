using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SlutuppgiftDatabasLotta.Migrations
{
    public partial class addedDateToCB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Customer");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanDate",
                table: "CustomerAndBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "CustomerAndBooks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanDate",
                table: "CustomerAndBooks");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "CustomerAndBooks");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanDate",
                table: "Customer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Customer",
                type: "datetime2",
                nullable: true);
        }
    }
}
