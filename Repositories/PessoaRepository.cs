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

	public async Task<IEnumerable<Pessoa>> GetPessoasTelefones()
	{
		var getPessoasTelefonesQuery = @"SELECT TOP 500 p.PessoaId,
                                            			p.Nome,
                                            			t.TelefoneId,
                                            			t.TelefoneTexto,
                                            			t.PessoaId,
                                            			t.Ativo
                                         FROM Pessoas p
                                         INNER JOIN Telefones t
                                         	ON p.PessoaId = t.PessoaId
										 ORDER BY p.PessoaId ASC;";

		_dbConnection.Open();

		var pessoas = await _dbConnection.QueryAsync<Pessoa, Telefone, Pessoa>(getPessoasTelefonesQuery, (pessoa, telefone) =>
		{
			// Verifica se o Objeto telefone foi inicializado, se não, inicia
			if (pessoa.Telefones == null)
			{
				pessoa.Telefones = new List<Telefone>();
			}

			pessoa.Telefones.Add(telefone);
			return pessoa;
		},

		splitOn: "TelefoneId");

		var result = pessoas.ToList();

		_dbConnection.Close();

		return result;
	}

	public async Task<IEnumerable<PessoaTelefone>> GetPessoasTelefonesEfCore()
	{
		var pessoasTelefones = await (from p in _context.Pessoas
									  join t in _context.Telefones on p.PessoaId equals t.PessoaId
									  select new PessoaTelefone()
									  {
										  PessoaId = p.PessoaId,
										  Nome = p.Nome,
										  TelefoneTexto = t.TelefoneTexto,
										  Ativo = t.Ativo
									  })
									  .Select(x => new PessoaTelefone()
									  {
										  PessoaId = x.PessoaId,
										  Nome = x.Nome,
										  TelefoneTexto = x.TelefoneTexto,
										  Ativo = x.Ativo
									  }).Take(500).AsNoTracking().ToListAsync();

		return pessoasTelefones;
	}
}
