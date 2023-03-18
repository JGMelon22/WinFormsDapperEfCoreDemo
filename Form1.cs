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
		listBox1.Items.Clear();

		// Caption ao passar cursor em cima dos botões
		var btn = new ToolTip();

		btn.AutoPopDelay = 500;
		btn.InitialDelay = 1000;
		btn.ReshowDelay = 500;

		btn.SetToolTip(button1, "Buscar com Dapper");
		btn.SetToolTip(button2, "Buscar com EF Core");
	}

	private async void button1_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;

		listBox1.Items.Clear();

		var peoplePhone = await _repository.GetPessoasTelefones();

		foreach (var item in peoplePhone)
			listBox1.Items.Add(item.PessoaId + " - " + item.Nome + " - " + item.Telefones.Select(x => x.TelefoneTexto).FirstOrDefault() + " - " + item.Telefones.Select(x => x.Ativo).FirstOrDefault());

		Cursor = Cursors.Default;
	}

	private async void button2_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;

		listBox1.Items.Clear();

		var peoplePhone = await _repository.GetPessoasTelefonesEfCore();

		foreach (var item in peoplePhone)
			listBox1.Items.Add(item.PessoaId + " - " + item.Nome + " - " + item.TelefoneTexto + " - " + item.Ativo);

		Cursor = Cursors.Default;
	}
}