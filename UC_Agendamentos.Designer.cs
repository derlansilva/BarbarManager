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
            components = new System.ComponentModel.Container();
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
            menuStatus = new ContextMenuStrip(components);
            confirmarToolStripMenuItem = new ToolStripMenuItem();
            finalizarToolStripMenuItem = new ToolStripMenuItem();
            cancelarToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            dtpData = new DateTimePicker();
            txtBuscaNome = new TextBox();
            menuStatus.SuspendLayout();
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
            listView1.ContextMenuStrip = menuStatus;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(13, 189);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(803, 376);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DrawColumnHeader += listView1_DrawColumnHeader;
            listView1.DrawItem += listView1_DrawItem;
            listView1.DrawSubItem += listView1_DrawSubItem;
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
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Cliente";
            columnHeader8.Width = 200;
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
            // menuStatus
            // 
            menuStatus.Items.AddRange(new ToolStripItem[] { confirmarToolStripMenuItem, finalizarToolStripMenuItem, cancelarToolStripMenuItem });
            menuStatus.Name = "menuStatus";
            menuStatus.Size = new Size(129, 70);
            // 
            // confirmarToolStripMenuItem
            // 
            confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
            confirmarToolStripMenuItem.Size = new Size(128, 22);
            confirmarToolStripMenuItem.Text = "Confirmar";
            confirmarToolStripMenuItem.Click += confirmarToolStripMenuItem_Click;
            // 
            // finalizarToolStripMenuItem
            // 
            finalizarToolStripMenuItem.Name = "finalizarToolStripMenuItem";
            finalizarToolStripMenuItem.Size = new Size(128, 22);
            finalizarToolStripMenuItem.Text = "Finalizar";
            finalizarToolStripMenuItem.Click += finalizarToolStripMenuItem_Click;
            // 
            // cancelarToolStripMenuItem
            // 
            cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            cancelarToolStripMenuItem.Size = new Size(128, 22);
            cancelarToolStripMenuItem.Text = "Cancelar";
            cancelarToolStripMenuItem.Click += cancelarToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 151);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 3;
            label1.Text = "Filtrar por data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(434, 154);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Cliente";
            // 
            // dtpData
            // 
            dtpData.Location = new Point(103, 148);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(249, 23);
            dtpData.TabIndex = 6;
            dtpData.ValueChanged += dtpDataFiltro_ValueChanged;
            // 
            // txtBuscaNome
            // 
            txtBuscaNome.BorderStyle = BorderStyle.None;
            txtBuscaNome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscaNome.Location = new Point(484, 148);
            txtBuscaNome.Multiline = true;
            txtBuscaNome.Name = "txtBuscaNome";
            txtBuscaNome.Size = new Size(332, 23);
            txtBuscaNome.TabIndex = 7;
            txtBuscaNome.TextChanged += txtBuscaNome_TextChanged;
            // 
            // UC_Agendamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtBuscaNome);
            Controls.Add(dtpData);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(btnNovoAgendamento);
            Controls.Add(Agendamentos);
            Name = "UC_Agendamentos";
            Size = new Size(842, 583);
            menuStatus.ResumeLayout(false);
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
        private DateTimePicker dtpData;
        private TextBox txtBuscaNome;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ContextMenuStrip menuStatus;
        private ToolStripMenuItem confirmarToolStripMenuItem;
        private ToolStripMenuItem finalizarToolStripMenuItem;
        private ToolStripMenuItem cancelarToolStripMenuItem;
    }
}
