namespace Barbermanager
{
    partial class FormNovoAgendamento
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
            cbClientes = new ComboBox();
            dtpData = new DateTimePicker();
            dtpHora = new DateTimePicker();
            cbServicos = new ComboBox();
            label2 = new Label();
            btnConfirmar = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 42);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // cbClientes
            // 
            cbClientes.FormattingEnabled = true;
            cbClientes.Location = new Point(36, 70);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(370, 23);
            cbClientes.TabIndex = 1;
            // 
            // dtpData
            // 
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(36, 208);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(160, 23);
            dtpData.TabIndex = 2;
            // 
            // dtpHora
            // 
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(271, 208);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(135, 23);
            dtpHora.TabIndex = 3;
            // 
            // cbServicos
            // 
            cbServicos.FormattingEnabled = true;
            cbServicos.Location = new Point(36, 137);
            cbServicos.Name = "cbServicos";
            cbServicos.Size = new Size(370, 23);
            cbServicos.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 119);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 5;
            label2.Text = "Serviço";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = SystemColors.Control;
            btnConfirmar.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.Location = new Point(36, 262);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(370, 33);
            btnConfirmar.TabIndex = 6;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            btnConfirmar.Paint += btnNovo_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 190);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 8;
            label3.Text = "Data";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(271, 190);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 9;
            label4.Text = "Hora";
            // 
            // FormNovoAgendamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(447, 370);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnConfirmar);
            Controls.Add(label2);
            Controls.Add(cbServicos);
            Controls.Add(dtpHora);
            Controls.Add(dtpData);
            Controls.Add(cbClientes);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNovoAgendamento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novo Agendamento";
            Load += FormNovoAgendamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbClientes;
        private DateTimePicker dtpData;
        private DateTimePicker dtpHora;
        private ComboBox cbServicos;
        private Label label2;
        private Button btnConfirmar;
        private Label label3;
        private Label label4;
    }
}