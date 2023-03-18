namespace WinFormsDapperDemo.Models;

public class Pessoa
{
	public int PessoaId { get; set; }
	public string Nome { get; set; } = string.Empty!;
	public List<Telefone> Telefones { get; set; }
}
