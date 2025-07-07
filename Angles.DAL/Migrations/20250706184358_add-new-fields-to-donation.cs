using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angles.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addnewfieldstodonation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Donations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ServiceNumber",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionNumber",
                table: "Donations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ServiceNumber",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                table: "Donations");
        }
    }
}
