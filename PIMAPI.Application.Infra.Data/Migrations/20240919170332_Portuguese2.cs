using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIMAPI.Application.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Portuguese2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.Id);
                });
        }
    }
}
