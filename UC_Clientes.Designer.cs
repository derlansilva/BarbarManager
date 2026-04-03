namespace Barbermanager
{
    partial class UC_Clientes
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
            btnNovoCliente = new Button();
            label1 = new Label();
            listViewClientes = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            SuspendLayout();
            // 
            // btnNovoCliente
            // 
            btnNovoCliente.Location = new Point(609, 48);
            btnNovoCliente.Name = "btnNovoCliente";
            btnNovoCliente.Size = new Size(169, 34);
            btnNovoCliente.TabIndex = 0;
            btnNovoCliente.Text = "Cadastrar Novo Cliente";
            btnNovoCliente.UseVisualStyleBackColor = true;
            btnNovoCliente.Click += btnNovoCliente_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 51);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Clientes";
            // 
            // listViewClientes
            // 
            listViewClientes.BorderStyle = BorderStyle.None;
            listViewClientes.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewClientes.GridLines = true;
            listViewClientes.Location = new Point(47, 116);
            listViewClientes.Name = "listViewClientes";
            listViewClientes.OwnerDraw = true;
            listViewClientes.Size = new Size(731, 455);
            listViewClientes.TabIndex = 2;
            listViewClientes.UseCompatibleStateImageBehavior = false;
            listViewClientes.View = View.Details;
            listViewClientes.DrawColumnHeader += listViewClientes_DrawColumnHeader;
            listViewClientes.DrawSubItem += listViewClientes_DrawSubItem;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nome";
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Telefone";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Total Cortes";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Fidelidade";
            columnHeader5.Width = 150;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // UC_Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listViewClientes);
            Controls.Add(label1);
            Controls.Add(btnNovoCliente);
            Name = "UC_Clientes";
            Size = new Size(842, 583);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNovoCliente;
        private Label label1;
        private ListView listViewClientes;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}
