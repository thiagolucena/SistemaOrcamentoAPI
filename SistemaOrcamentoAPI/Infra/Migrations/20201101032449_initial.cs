using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteId", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemId", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    orcamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(nullable: false),
                    dataOrcamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuarioCricacao = table.Column<string>(nullable: true),
                    usuarioAlteracao = table.Column<string>(nullable: true),
                    valorTotal = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    valorDesconto = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    situacao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoId", x => x.orcamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioId", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrcamento",
                columns: table => new
                {
                    OrcamentoId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrcamento", x => new { x.ItemId, x.OrcamentoId });
                    table.ForeignKey(
                        name: "FK_ItemOrcamento_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOrcamento_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "orcamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrcamento_OrcamentoId",
                table: "ItemOrcamento",
                column: "OrcamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ItemOrcamento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Orcamento");
        }
    }
}
