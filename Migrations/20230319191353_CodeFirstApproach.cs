using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsDapperDemo.Migrations;

/// <inheritdoc />
public partial class CodeFirstApproach : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Pessoas",
			columns: table => new
			{
				PessoaId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
			});

		migrationBuilder.CreateTable(
			name: "Telefones",
			columns: table => new
			{
				TelefoneId = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				TelefoneTexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Ativo = table.Column<bool>(type: "bit", nullable: false),
				PessoaId = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Telefones", x => x.TelefoneId);
			});

		migrationBuilder.CreateTable(
			name: "PessoaTelefone",
			columns: table => new
			{
				PessoasPessoaId = table.Column<int>(type: "int", nullable: false),
				TelefonesTelefoneId = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_PessoaTelefone", x => new { x.PessoasPessoaId, x.TelefonesTelefoneId });
				table.ForeignKey(
					name: "FK_PessoaTelefone_Pessoas_PessoasPessoaId",
					column: x => x.PessoasPessoaId,
					principalTable: "Pessoas",
					principalColumn: "PessoaId",
					onDelete: ReferentialAction.Cascade);
				table.ForeignKey(
					name: "FK_PessoaTelefone_Telefones_TelefonesTelefoneId",
					column: x => x.TelefonesTelefoneId,
					principalTable: "Telefones",
					principalColumn: "TelefoneId",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.CreateIndex(
			name: "IX_Pessoas_PessoaId",
			table: "Pessoas",
			column: "PessoaId");

		migrationBuilder.CreateIndex(
			name: "IX_PessoaTelefone_TelefonesTelefoneId",
			table: "PessoaTelefone",
			column: "TelefonesTelefoneId");

		migrationBuilder.CreateIndex(
			name: "IX_Telefones_TelefoneId",
			table: "Telefones",
			column: "TelefoneId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "PessoaTelefone");

		migrationBuilder.DropTable(
			name: "Pessoas");

		migrationBuilder.DropTable(
			name: "Telefones");
	}
}
