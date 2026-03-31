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
            listView1 = new ListView();
            SuspendLayout();
            // 
            // btnNovoCliente
            // 
            btnNovoCliente.Location = new Point(609, 48);
            btnNovoCliente.Name = "btnNovoCliente";
            btnNovoCliente.Size = new Size(169, 23);
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
            // listView1
            // 
            listView1.Location = new Point(47, 241);
            listView1.Name = "listView1";
            listView1.Size = new Size(731, 307);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // UC_Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
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
        private ListView listView1;
    }
}
