using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsDapperDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddingDetalhesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Detalhes",
                columns: table => new
                {
                    DetalheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetalheTexto = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalhes", x => x.DetalheId);
                    table.ForeignKey(
                        name: "FK_Detalhes_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalhes_DetalheId",
                table: "Detalhes",
                column: "DetalheId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalhes_PessoaId",
                table: "Detalhes",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalhes");
        }
    }
}
