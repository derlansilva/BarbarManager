namespace Barbermanager
{
    partial class FormServices
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
            label3 = new Label();
            txtNomeServico = new TextBox();
            txtPrecoServico = new TextBox();
            txtTempoServico = new TextBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 120);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Titulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 184);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(353, 187);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "Tempo";
            // 
            // txtNomeServico
            // 
            txtNomeServico.Location = new Point(79, 120);
            txtNomeServico.Name = "txtNomeServico";
            txtNomeServico.Size = new Size(504, 23);
            txtNomeServico.TabIndex = 3;
            // 
            // txtPrecoServico
            // 
            txtPrecoServico.Location = new Point(79, 181);
            txtPrecoServico.Name = "txtPrecoServico";
            txtPrecoServico.Size = new Size(258, 23);
            txtPrecoServico.TabIndex = 4;
            // 
            // txtTempoServico
            // 
            txtTempoServico.Location = new Point(406, 181);
            txtTempoServico.Name = "txtTempoServico";
            txtTempoServico.Size = new Size(177, 23);
            txtTempoServico.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(79, 247);
            button1.Name = "button1";
            button1.Size = new Size(175, 31);
            button1.TabIndex = 6;
            button1.Text = "Salvar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Enabled = false;
            progressBar1.Location = new Point(79, 319);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(504, 12);
            progressBar1.TabIndex = 7;
            progressBar1.Visible = false;
            // 
            // FormServices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 450);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(txtTempoServico);
            Controls.Add(txtPrecoServico);
            Controls.Add(txtNomeServico);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormServices";
            Text = "FormServices";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNomeServico;
        private TextBox txtPrecoServico;
        private TextBox txtTempoServico;
        private Button button1;
        private ProgressBar progressBar1;
    }
}