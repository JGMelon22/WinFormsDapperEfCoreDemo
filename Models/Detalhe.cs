using System.ComponentModel;

namespace WinFormsDapperDemo.Models;

[Table("Detalhes")]
[Index(nameof(DetalheId))]
public class Detalhe
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("DetalheId")]
	public int DetalheId { get; set; }

	[Column("DetalheTexto", TypeName = "VARCHAR(255)")]
    [Required]
	public string DetalheTexto { get; set; } = string.Empty!;

	[ForeignKey("PessoaId")]
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
