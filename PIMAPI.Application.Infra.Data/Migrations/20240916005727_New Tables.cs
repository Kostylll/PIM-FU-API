using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIMAPI.Application.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Nome_Produto = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Quantidade = table.Column<float>(type: "real", maxLength: 90, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Produto_Vendido = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Quantidade_Vendida = table.Column<float>(type: "real", maxLength: 90, nullable: false),
                    Local_Vendido = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
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
                    table.PrimaryKey("PK_Supply", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Supply");
        }
    }
}
