namespace Barbermanager
{
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
            pnlSidebar = new Panel();
            btnServices = new Button();
            btnAgendamento = new Button();
            btnCLient = new Button();
            pnlConteudo = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(btnServices);
            pnlSidebar.Controls.Add(btnAgendamento);
            pnlSidebar.Controls.Add(btnCLient);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(206, 622);
            pnlSidebar.TabIndex = 0;
            // 
            // btnServices
            // 
            btnServices.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnServices.Location = new Point(8, 110);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(184, 32);
            btnServices.TabIndex = 2;
            btnServices.Text = "Serviços";
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += btnServices_Click;
            // 
            // btnAgendamento
            // 
            btnAgendamento.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgendamento.Location = new Point(8, 70);
            btnAgendamento.Name = "btnAgendamento";
            btnAgendamento.Size = new Size(184, 33);
            btnAgendamento.TabIndex = 1;
            btnAgendamento.Text = "Agendamento";
            btnAgendamento.UseVisualStyleBackColor = true;
            btnAgendamento.Click += btnAgendamento_Click;
            // 
            // btnCLient
            // 
            btnCLient.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCLient.Location = new Point(8, 31);
            btnCLient.Name = "btnCLient";
            btnCLient.Size = new Size(184, 33);
            btnCLient.TabIndex = 0;
            btnCLient.Text = "Clientes";
            btnCLient.UseVisualStyleBackColor = true;
            btnCLient.Click += btnCLient_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.White;
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(206, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(842, 622);
            pnlConteudo.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 622);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlSidebar);
            Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Barbearia do Manaus";
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnCLient;
        private Button btnAgendamento;
        private Panel pnlConteudo;
        private Button btnServices;
    }
}
