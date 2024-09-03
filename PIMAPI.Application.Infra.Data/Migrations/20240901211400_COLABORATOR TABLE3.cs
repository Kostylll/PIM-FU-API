using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIMAPI.Application.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class COLABORATORTABLE3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Nascimento",
                table: "Colaborator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Nascimento",
                table: "Colaborator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
