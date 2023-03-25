namespace WinFormsDapperDemo.ViewModels;

public class PessoaTelefoneDetalhe
{
	public int PessoaId { get; set; }
	public string Nome { get; set; } = string.Empty!;
	public int TelefoneId { get; set; }
	public string TelefoneTexto { get; set; } = string.Empty!;
	public bool Ativo { get; set; }
	public int DetalheId { get; set; }
	public string DetalheTexto { get; set; } = string.Empty!;
}
