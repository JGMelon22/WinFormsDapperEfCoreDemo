using WinFormsDapperDemo.Models;
using WinFormsDapperDemo.ViewModels;

namespace WinFormsDapperDemo.Interfaces;

public interface IPessoaRepository
{
	Task<List<PessoaViewModel>> GetPessoas();
	Task<List<PessoaViewModel>> GetPessoasEfCore();
	Task<IEnumerable<Pessoa>> GetPessoasTelefonesDetalhes();
	Task<IEnumerable<PessoaTelefoneDetalhe>> GetPessoasTelefonesDetalhesEfCore();
}
