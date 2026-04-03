namespace Barbermanager
{
    partial class UC_Services
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
            btnNovoServiço = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            SuspendLayout();
            // 
            // Agendamentos
            // 
            Agendamentos.AutoSize = true;
            Agendamentos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Agendamentos.Location = new Point(27, 30);
            Agendamentos.Name = "Agendamentos";
            Agendamentos.Size = new Size(74, 21);
            Agendamentos.TabIndex = 1;
            Agendamentos.Text = "Serviços";
            // 
            // btnNovoServiço
            // 
            btnNovoServiço.Location = new Point(628, 30);
            btnNovoServiço.Name = "btnNovoServiço";
            btnNovoServiço.Size = new Size(182, 29);
            btnNovoServiço.TabIndex = 2;
            btnNovoServiço.Text = "Cadastrar Novo Serviço";
            btnNovoServiço.UseVisualStyleBackColor = true;
            btnNovoServiço.Click += btnNovoServiço_Click;
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.None;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4, columnHeader5 });
            listView1.GridLines = true;
            listView1.Location = new Point(27, 98);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(783, 439);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DrawColumnHeader += listViewServicos_DrawColumnHeader;
            listView1.DrawItem += listViewServicos_DrawItem;
            listView1.DrawSubItem += listViewServicos_DrawSubItem;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Titulo";
            columnHeader2.Width = 400;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Valor";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tempo";
            columnHeader5.Width = 172;
            // 
            // UC_Services
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(btnNovoServiço);
            Controls.Add(Agendamentos);
            Name = "UC_Services";
            Size = new Size(842, 583);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Agendamentos;
        private Button btnNovoServiço;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
    }
}
