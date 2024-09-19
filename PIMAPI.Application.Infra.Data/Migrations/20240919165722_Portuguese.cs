using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIMAPI.Application.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Portuguese : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborator");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValue: "NEWID()"),
                    Nome = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Data_Nascimento = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Nome_Produto = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Quantidade = table.Column<float>(type: "real", maxLength: 90, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
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
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.CreateTable(
                name: "Colaborator",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValue: "NEWID()"),
                    CPF = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    Data_Nascimento = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Nome_Produto = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Quantidade = table.Column<float>(type: "real", maxLength: 90, nullable: false)
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
                    Local_Vendido = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Nome_Empresa = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Produto_Vendido = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Quantidade_Vendida = table.Column<float>(type: "real", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });
        }
    }
}
