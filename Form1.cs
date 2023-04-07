using System.Runtime.InteropServices;
using WinFormsDapperDemo.Interfaces;

namespace WinFormsDapperAutofacDemo;

public partial class Form1 : Form
{
	private readonly IPessoaRepository _repository;

	// Dark Header
	[DllImport("DwmApi")] //System.Runtime.InteropServices
	private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

	protected override void OnHandleCreated(EventArgs e)
	{
		if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
			DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
	}

	public Form1(IPessoaRepository repository)
	{
		_repository = repository;
		InitializeComponent();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		listBox1.HorizontalScrollbar = true;

		listBox1.Items.Clear();
		button5.Enabled = false;

		// Caption ao passar cursor em cima dos botões
		var btn = new ToolTip();

		btn.AutoPopDelay = 500;
		btn.InitialDelay = 1000;
		btn.ReshowDelay = 500;

		btn.SetToolTip(button1, "Join query with Dapper");
		btn.SetToolTip(button2, "Join query with EF Core");
		btn.SetToolTip(button3, "Query with EF Core");
		btn.SetToolTip(button4, "Query with Dapper");
		btn.SetToolTip(button5, "Clear Results");
	}

	private async void button1_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		button5.Enabled = false;

		Cursor = Cursors.WaitCursor;

		listBox1.Items.Clear();

		var peoplePhone = await _repository.GetPessoasTelefonesDetalhes();

		foreach (var item in peoplePhone)
			listBox1.Items.Add(item.PessoaId + " - " + item.Nome + " - " + item.Telefones.Select(x => x.TelefoneTexto).FirstOrDefault() + " - " + item.Telefones.Select(x => x.Ativo).FirstOrDefault() + " - " + item.Detalhes.Select(x => x.DetalheTexto).FirstOrDefault());

		Cursor = Cursors.Default;

		button1.Enabled = true;
		button2.Enabled = true;
		button3.Enabled = true;
		button4.Enabled = true;
		button5.Enabled = true;
	}

	private async void button2_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		button5.Enabled = false;

		Cursor = Cursors.WaitCursor;

		listBox1.Items.Clear();

		var peoplePhone = await _repository.GetPessoasTelefonesDetalhesEfCore();

		foreach (var item in peoplePhone)
			listBox1.Items.Add(item.PessoaId + " - " + item.Nome + " - " + item.TelefoneTexto + " - " + item.Ativo + " - " + item.DetalheTexto);

		Cursor = Cursors.Default;

		button1.Enabled = true;
		button2.Enabled = true;
		button3.Enabled = true;
		button4.Enabled = true;
		button5.Enabled = true;
	}

	private async void button3_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		button5.Enabled = false;

		Cursor = Cursors.WaitCursor;

		listBox1.Items.Clear();

		var pessoas = await _repository.GetPessoasEfCore();
		foreach (var item in pessoas)
			listBox1.Items.Add(item.PessoaId + " - " + item.Nome);

		Cursor = Cursors.Default;

		button1.Enabled = true;
		button2.Enabled = true;
		button3.Enabled = true;
		button4.Enabled = true;
		button5.Enabled = true;
	}

	private async void button4_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		button5.Enabled = false;

		Cursor = Cursors.WaitCursor;

		listBox1.Items.Clear();

		var pessoas = await _repository.GetPessoas();
		foreach (var item in pessoas)
			listBox1.Items.Add(item.PessoaId + " - " + item.Nome);

		Cursor = Cursors.Default;

		button1.Enabled = true;
		button2.Enabled = true;
		button3.Enabled = true;
		button4.Enabled = true;
		button5.Enabled = true;
	}

	private void button5_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		button2.Enabled = false;
		button3.Enabled = false;
		button4.Enabled = false;
		button5.Enabled = false;

		listBox1.Items.Clear();

		button1.Enabled = true;
		button2.Enabled = true;
		button3.Enabled = true;
		button4.Enabled = true;
	}

	// Disable buttons 
}

