using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Promocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocoes_Promocoes_PromocaoId",
                table: "Promocoes");

            migrationBuilder.DropIndex(
                name: "IX_Promocoes_PromocaoId",
                table: "Promocoes");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "PromocaoProduto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false),
                    IdPromocao = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: true),
                    PromocaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocaoProduto", x => new { x.IdProduto, x.IdPromocao });
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                        column: x => x.PromocaoId,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_ProdutoId",
                table: "PromocaoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromocaoProduto");

            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Promocoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promocoes_PromocaoId",
                table: "Promocoes",
                column: "PromocaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos",
                column: "PromocaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promocoes_Promocoes_PromocaoId",
                table: "Promocoes",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
