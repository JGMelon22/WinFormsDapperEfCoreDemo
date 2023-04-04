using Dapper;
using System.Data;
using WinFormsDapperDemo.Data;
using WinFormsDapperDemo.Interfaces;
using WinFormsDapperDemo.Models;
using WinFormsDapperDemo.ViewModels;

namespace WinFormsDapperDemo.Repositories;

public class PessoaRepository : IPessoaRepository
{
	private readonly IDbConnection _dbConnection;
	private readonly AppDbContext _context;
	public PessoaRepository(IDbConnection dbConnection, AppDbContext context)
	{
		_dbConnection = dbConnection;
		_context = context;
	}

	public async Task<IEnumerable<Pessoa>> GetPessoas()
	{
		var getPessoasQuery = @"SELECT TOP 500 PessoaId,
											   Nome
								FROM Pessoas
								ORDER BY PessoaId ASC;";

		_dbConnection.Open();

		var result = await _dbConnection.QueryAsync<Pessoa>(getPessoasQuery);

		_dbConnection.Close();

		return result.ToList();
	}

	// Only Pessoas Id and Nome
	public async Task<List<PessoaViewModel>> GetPessoasEfCore()
	{
		var pessoas = await _context.Pessoas.AsNoTracking().Take(500).ToListAsync();
		var pessoaViewModel = pessoas.Select(x => new PessoaViewModel
		{
			PessoaId = x.PessoaId,
			Nome = x.Nome
		}).ToList();

		return pessoaViewModel;
	}

	public async Task<IEnumerable<Pessoa>> GetPessoasTelefonesDetalhes()
	{
		var getPessoasTelefonesQuery = @"SELECT TOP 500 p.PessoaId,
										 		        p.Nome,
										 		        t.TelefoneId,
										 		        t.TelefoneTexto,
										 		        t.PessoaId,
										 		        t.Ativo,
														d.DetalheId,
										 			    d.DetalheTexto
										 FROM Pessoas p
										 INNER JOIN Telefones t
										 	ON p.PessoaId = t.PessoaId
										 INNER JOIN Detalhes d
										 	ON p.PessoaId = d.PessoaId
										 ORDER BY p.PessoaId ASC;";

		_dbConnection.Open();

		var pessoas = await _dbConnection.QueryAsync<Pessoa, Telefone, Detalhe, Pessoa>(getPessoasTelefonesQuery, (pessoa, telefone, detalhe) =>
		{
			// Verifica se o Objeto telefone foi inicializado, se não, inicia
			if (pessoa.Telefones == null)
			{
				pessoa.Telefones = new List<Telefone>();
			}

			if (pessoa.Detalhes == null)
			{
				pessoa.Detalhes = new List<Detalhe>();
			}

			pessoa.Telefones.Add(telefone);
			pessoa.Detalhes.Add(detalhe);
			return pessoa;
		},

		splitOn: "TelefoneId, DetalheId");

		var result = pessoas.ToList();

		_dbConnection.Close();

		return result;
	}

	public async Task<IEnumerable<PessoaTelefoneDetalhe>> GetPessoasTelefonesDetalhesEfCore()
	{
		var pessoasTelefones = await (from p in _context.Pessoas
									  join t in _context.Telefones on p.PessoaId equals t.PessoaId
									  join d in _context.Detalhes on p.PessoaId equals d.PessoaId
									  select new PessoaTelefoneDetalhe()
									  {
										  PessoaId = p.PessoaId,
										  Nome = p.Nome,
										  TelefoneTexto = t.TelefoneTexto,
										  Ativo = t.Ativo,
										  DetalheTexto = d.DetalheTexto
									  })
									  .Select(x => new PessoaTelefoneDetalhe()
									  {
										  PessoaId = x.PessoaId,
										  Nome = x.Nome,
										  TelefoneTexto = x.TelefoneTexto,
										  Ativo = x.Ativo,
										  DetalheTexto = x.DetalheTexto
									  }).Take(500).AsNoTracking().ToListAsync();

		return pessoasTelefones;
	}
}
