namespace WinFormsDapperDemo.Models;

[Table("Telefones")]
[Index(nameof(TelefoneId))]
public class Telefone
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("TelefoneId")]
	public int TelefoneId { get; set; }

	[Column("TelefoneTexto"), DataType("VARCHAR(11)")]
	[Required]
	public string TelefoneTexto { get; set; } = string.Empty!;

	[Column("Ativo"), DataType("BIT")]
	public bool Ativo { get; set; }

	[ForeignKey("PessoaId")]
	public int PessoaId { get; set; }
	public List<Pessoa> Pessoas { get; set; }
}
