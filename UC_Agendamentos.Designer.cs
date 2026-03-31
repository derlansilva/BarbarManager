namespace Barbermanager
{
    partial class UC_Agendamentos
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Agendamentos = new Label();
            btnNovoAgendamento = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            btnFiltrar = new Button();
            dtpDataFiltro = new DateTimePicker();
            txtBuscaCliente = new TextBox();
            SuspendLayout();
            // 
            // Agendamentos
            // 
            Agendamentos.AutoSize = true;
            Agendamentos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Agendamentos.Location = new Point(13, 40);
            Agendamentos.Name = "Agendamentos";
            Agendamentos.Size = new Size(126, 21);
            Agendamentos.TabIndex = 0;
            Agendamentos.Text = "Agendamentos";
            // 
            // btnNovoAgendamento
            // 
            btnNovoAgendamento.BackColor = Color.DodgerBlue;
            btnNovoAgendamento.FlatStyle = FlatStyle.Flat;
            btnNovoAgendamento.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNovoAgendamento.ForeColor = Color.White;
            btnNovoAgendamento.Location = new Point(671, 40);
            btnNovoAgendamento.Name = "btnNovoAgendamento";
            btnNovoAgendamento.Size = new Size(145, 31);
            btnNovoAgendamento.TabIndex = 1;
            btnNovoAgendamento.Text = "Novo agendamento";
            btnNovoAgendamento.UseVisualStyleBackColor = false;
            btnNovoAgendamento.Click += btnNovoAgendamento_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(13, 189);
            listView1.Name = "listView1";
            listView1.Size = new Size(803, 376);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 40;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Data";
            columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Hora";
            columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Cliente";
            columnHeader8.Width = 220;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Serviço";
            columnHeader9.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Telefone";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 125);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 3;
            label1.Text = "Filtrar por data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 130);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Cliente";
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.DodgerBlue;
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(610, 144);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(206, 29);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Buscar";
            btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // dtpDataFiltro
            // 
            dtpDataFiltro.Location = new Point(13, 148);
            dtpDataFiltro.Name = "dtpDataFiltro";
            dtpDataFiltro.Size = new Size(249, 23);
            dtpDataFiltro.TabIndex = 6;
            // 
            // txtBuscaCliente
            // 
            txtBuscaCliente.Location = new Point(272, 148);
            txtBuscaCliente.Name = "txtBuscaCliente";
            txtBuscaCliente.Size = new Size(332, 23);
            txtBuscaCliente.TabIndex = 7;
            // 
            // UC_Agendamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtBuscaCliente);
            Controls.Add(dtpDataFiltro);
            Controls.Add(btnFiltrar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(btnNovoAgendamento);
            Controls.Add(Agendamentos);
            Name = "UC_Agendamentos";
            Size = new Size(842, 583);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Agendamentos;
        private Button btnNovoAgendamento;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Label label1;
        private Label label2;
        private Button btnFiltrar;
        private DateTimePicker dtpDataFiltro;
        private TextBox txtBuscaCliente;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
