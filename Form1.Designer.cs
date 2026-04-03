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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlSidebar = new Panel();
            linhaDivisora = new Panel();
            btnHome = new Button();
            imageList1 = new ImageList(components);
            btnServices = new Button();
            btnAgendamento = new Button();
            btnCLient = new Button();
            pnlConteudo = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(linhaDivisora);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Controls.Add(btnServices);
            pnlSidebar.Controls.Add(btnAgendamento);
            pnlSidebar.Controls.Add(btnCLient);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(206, 622);
            pnlSidebar.TabIndex = 0;
            // 
            // linhaDivisora
            // 
            linhaDivisora.BackColor = Color.FromArgb(242, 200, 17);
            linhaDivisora.Location = new Point(203, 0);
            linhaDivisora.Name = "linhaDivisora";
            linhaDivisora.Size = new Size(3, 627);
            linhaDivisora.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.ImageIndex = 3;
            btnHome.ImageList = imageList1;
            btnHome.Location = new Point(11, 35);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(184, 33);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.White;
            imageList1.Images.SetKeyName(0, "icons8-confirm-schedule-67.png");
            imageList1.Images.SetKeyName(1, "icons8-customer-50.png");
            imageList1.Images.SetKeyName(2, "icons8-services-50.png");
            imageList1.Images.SetKeyName(3, "icons8-home-50.png");
            // 
            // btnServices
            // 
            btnServices.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnServices.ImageAlign = ContentAlignment.MiddleLeft;
            btnServices.ImageIndex = 2;
            btnServices.ImageList = imageList1;
            btnServices.Location = new Point(11, 152);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(184, 32);
            btnServices.TabIndex = 2;
            btnServices.Text = "Serviços";
            btnServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += btnServices_Click;
            // 
            // btnAgendamento
            // 
            btnAgendamento.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgendamento.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgendamento.ImageIndex = 0;
            btnAgendamento.ImageList = imageList1;
            btnAgendamento.Location = new Point(11, 113);
            btnAgendamento.Name = "btnAgendamento";
            btnAgendamento.Size = new Size(184, 33);
            btnAgendamento.TabIndex = 1;
            btnAgendamento.Text = "Agendamento";
            btnAgendamento.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgendamento.UseVisualStyleBackColor = true;
            btnAgendamento.Click += btnAgendamento_Click;
            // 
            // btnCLient
            // 
            btnCLient.Font = new Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCLient.ImageAlign = ContentAlignment.MiddleLeft;
            btnCLient.ImageIndex = 1;
            btnCLient.ImageList = imageList1;
            btnCLient.Location = new Point(11, 74);
            btnCLient.Name = "btnCLient";
            btnCLient.Size = new Size(184, 33);
            btnCLient.TabIndex = 0;
            btnCLient.Text = "Clientes";
            btnCLient.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCLient.UseVisualStyleBackColor = true;
            btnCLient.Click += btnCLient_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.FromArgb(237, 240, 242);
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
        private ImageList imageList1;
        private Button btnHome;
        private Panel linhaDivisora;
    }
}
