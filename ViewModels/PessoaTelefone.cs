namespace WinFormsDapperDemo.ViewModels;

public class PessoaTelefone
{
	public int PessoaId { get; set; }
	public string Nome { get; set; } = string.Empty!;
	public int IdTelefone { get; set; }
	public string TelefoneTexto { get; set; } = string.Empty!;
	public bool Ativo { get; set; }
}
