namespace Barbermanager
{
    partial class UC_Home
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
            panel1 = new Panel();
            lblGn = new Label();
            lblGanhos = new Label();
            panel2 = new Panel();
            lblAgendamento = new Label();
            lblTotalHoje = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblGn);
            panel1.Controls.Add(lblGanhos);
            panel1.Cursor = Cursors.Hand;
            panel1.Location = new Point(123, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 147);
            panel1.TabIndex = 0;
            // 
            // lblGn
            // 
            lblGn.AutoSize = true;
            lblGn.ForeColor = SystemColors.ControlDark;
            lblGn.Location = new Point(49, 17);
            lblGn.Name = "lblGn";
            lblGn.Size = new Size(89, 15);
            lblGn.TabIndex = 2;
            lblGn.Text = "Ganhos do Mes";
            // 
            // lblGanhos
            // 
            lblGanhos.AutoSize = true;
            lblGanhos.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGanhos.Location = new Point(49, 66);
            lblGanhos.Name = "lblGanhos";
            lblGanhos.Size = new Size(114, 31);
            lblGanhos.TabIndex = 1;
            lblGanhos.Text = "R$ 250,00";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblAgendamento);
            panel2.Controls.Add(lblTotalHoje);
            panel2.Cursor = Cursors.Hand;
            panel2.Location = new Point(502, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(233, 147);
            panel2.TabIndex = 1;
            // 
            // lblAgendamento
            // 
            lblAgendamento.AutoSize = true;
            lblAgendamento.Location = new Point(48, 17);
            lblAgendamento.Name = "lblAgendamento";
            lblAgendamento.Size = new Size(132, 15);
            lblAgendamento.TabIndex = 3;
            lblAgendamento.Text = "Agendamentos de Hoje";
            // 
            // lblTotalHoje
            // 
            lblTotalHoje.AutoSize = true;
            lblTotalHoje.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalHoje.Location = new Point(98, 66);
            lblTotalHoje.Name = "lblTotalHoje";
            lblTotalHoje.Size = new Size(38, 31);
            lblTotalHoje.TabIndex = 2;
            lblTotalHoje.Text = "15";
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(18, 233);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(803, 333);
            listView1.TabIndex = 3;
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
            columnHeader3.Width = 160;
            // 
            // UC_Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_Home";
            Size = new Size(842, 583);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lblGanhos;
        private Label lblTotalHoje;
        private Label lblGn;
        private Label lblAgendamento;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
