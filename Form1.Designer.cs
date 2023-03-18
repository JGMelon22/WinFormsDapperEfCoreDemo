namespace WinFormsDapperAutofacDemo;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
		listBox1 = new ListBox();
		button1 = new Button();
		button2 = new Button();
		SuspendLayout();
		// 
		// listBox1
		// 
		listBox1.BackColor = Color.FromArgb(68, 71, 90);
		listBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
		listBox1.ForeColor = Color.FromArgb(248, 248, 242);
		listBox1.FormattingEnabled = true;
		listBox1.ItemHeight = 31;
		listBox1.Location = new Point(12, 12);
		listBox1.Name = "listBox1";
		listBox1.Size = new Size(662, 283);
		listBox1.TabIndex = 0;
		// 
		// button1
		// 
		button1.BackColor = Color.FromArgb(189, 147, 249);
		button1.Cursor = Cursors.Hand;
		button1.FlatStyle = FlatStyle.Flat;
		button1.ForeColor = Color.FromArgb(248, 248, 242);
		button1.Location = new Point(541, 301);
		button1.Name = "button1";
		button1.Size = new Size(133, 35);
		button1.TabIndex = 1;
		button1.Text = "Listar Pessoas";
		button1.UseVisualStyleBackColor = false;
		button1.Click += button1_Click;
		// 
		// button2
		// 
		button2.BackColor = Color.FromArgb(189, 147, 249);
		button2.Cursor = Cursors.Hand;
		button2.FlatStyle = FlatStyle.Flat;
		button2.ForeColor = Color.FromArgb(248, 248, 242);
		button2.Location = new Point(373, 301);
		button2.Name = "button2";
		button2.Size = new Size(162, 35);
		button2.TabIndex = 2;
		button2.Text = "Listar Pessoas EF";
		button2.UseVisualStyleBackColor = false;
		button2.Click += button2_Click;
		// 
		// Form1
		// 
		AutoScaleDimensions = new SizeF(10F, 25F);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(40, 42, 54);
		ClientSize = new Size(686, 346);
		Controls.Add(button2);
		Controls.Add(button1);
		Controls.Add(listBox1);
		Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		Icon = (Icon)resources.GetObject("$this.Icon");
		Margin = new Padding(4);
		MaximizeBox = false;
		Name = "Form1";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "DI and Dapper";
		Load += Form1_Load;
		ResumeLayout(false);
	}

	#endregion

	private ListBox listBox1;
	private Button button1;
	private Button button2;
}