using WinFormsDapperDemo.Models;
using WinFormsDapperDemo.ViewModels;

namespace WinFormsDapperDemo.Interfaces;

public interface IPessoaRepository
{
	Task<IEnumerable<Pessoa>> GetPessoas();
	Task<List<PessoaViewModel>> GetPessoasEfCore();
	Task<IEnumerable<Pessoa>> GetPessoasTelefonesDetalhes();
	Task<IEnumerable<PessoaTelefoneDetalhe>> GetPessoasTelefonesDetalhesEfCore();
}
