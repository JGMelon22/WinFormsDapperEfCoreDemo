namespace WinFormsDapperDemo.Models;

public class Telefone
{
	public int TelefoneId { get; set; }
	public string TelefoneTexto { get; set; } = string.Empty!;
	public int PessoaId { get; set; }
	public bool Ativo { get; set; }

	public List<Pessoa> Pessoas { get; set; }
}
