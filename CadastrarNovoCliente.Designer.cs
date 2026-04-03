namespace Barbermanager
{
    partial class CadastrarNovoCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnCadastrar = new Button();
            txtNome = new TextBox();
            txtTelefone = new TextBox();
            progress = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold);
            label1.Location = new Point(51, 58);
            label1.Name = "label1";
            label1.Size = new Size(37, 16);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold);
            label2.Location = new Point(51, 142);
            label2.Name = "label2";
            label2.Size = new Size(52, 16);
            label2.TabIndex = 1;
            label2.Text = "Telefone";
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.Blue;
            btnCadastrar.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.FlatStyle = FlatStyle.System;
            btnCadastrar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.Location = new Point(51, 233);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(343, 35);
            btnCadastrar.TabIndex = 2;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            btnCadastrar.Paint += btnNovo_Paint;
            // 
            // txtNome
            // 
            txtNome.BorderStyle = BorderStyle.None;
            txtNome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNome.Location = new Point(51, 77);
            txtNome.Multiline = true;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(343, 28);
            txtNome.TabIndex = 3;
            // 
            // txtTelefone
            // 
            txtTelefone.BorderStyle = BorderStyle.None;
            txtTelefone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefone.Location = new Point(51, 161);
            txtTelefone.Multiline = true;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(343, 28);
            txtTelefone.TabIndex = 4;
            // 
            // progress
            // 
            progress.Location = new Point(51, 310);
            progress.Name = "progress";
            progress.Size = new Size(343, 14);
            progress.TabIndex = 6;
            progress.Visible = false;
            // 
            // CadastrarNovoCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 370);
            Controls.Add(progress);
            Controls.Add(txtTelefone);
            Controls.Add(txtNome);
            Controls.Add(btnCadastrar);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CadastrarNovoCliente";
            Text = "Cadastrar Novo Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnCadastrar;
        private TextBox txtNome;
        private TextBox txtTelefone;
        private ProgressBar progress;
    }
}