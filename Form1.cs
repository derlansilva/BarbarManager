namespace Barbermanager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#354A5F");
            pnlSidebar.BackColor = ColorTranslator.FromHtml("#354A5F");

            // Cor de fundo do formulário onde os UserControls aparecem
            this.BackColor = ColorTranslator.FromHtml("#E5E9ED");

            ConfigurarBotoesMenu();
            PintarIconesDeBranco();
            ShowSection(new UC_Home());
        }



        private void ConfigurarBotoesMenu()
        {
            // Adicione o btnHome aqui na lista!
            var botoes = new List<Button> { btnHome, btnCLient, btnAgendamento, btnServices };

            foreach (var btn in botoes)
            {

                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleLeft;

                btnHome.Text = "     Home";
                btnCLient.Text = "    Clientes";
                btnAgendamento.Text = "     Agendamento";
                btnServices.Text = "     Serviços";

                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Padding = new Padding(15, 0, 0, 0);

                // Efeito de Hover
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#455E73");
            }
        }


        private void DestacarBotaoAtivo(Button btnAtivo)
        {
            // Reseta todos para transparente
            btnHome.BackColor = Color.Transparent;
            btnCLient.BackColor = Color.Transparent;
            btnAgendamento.BackColor = Color.Transparent;
            btnServices.BackColor = Color.Transparent;

            // Destaca o que foi clicado (Azul Destaque SAP)
            btnAtivo.BackColor = ColorTranslator.FromHtml("#0070D2");
        }


        private void PintarIconesDeBranco()
        {
            foreach (Button btn in pnlSidebar.Controls.OfType<Button>())
            {
                if (btn.Image != null)
                {
                    Bitmap bmp = new Bitmap(btn.Image);
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color pixelColor = bmp.GetPixel(x, y);
                            // Se o pixel não for transparente, pinta de branco
                            if (pixelColor.A > 0)
                            {
                                bmp.SetPixel(x, y, Color.FromArgb(pixelColor.A, Color.White));
                            }
                        }
                    }
                    btn.Image = bmp;
                }
            }
        }


        public void ShowSection(UserControl section)
        {
            if (pnlConteudo.Controls.Count > 0)
            {
                pnlConteudo.Controls[0].Dispose();
                pnlConteudo.Controls.Clear();
            }

            section.Dock = DockStyle.Fill;

            pnlConteudo.Controls.Add(section);
            section.BringToFront();
        }
        private void btnCLient_Click(object sender, EventArgs e)
        {
            ShowSection(new UC_Clientes());
        }

        private void btnAgendamento_Click(object sender, EventArgs e)
        {
            ShowSection(new UC_Agendamentos());
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            ShowSection(new UC_Services());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowSection(new UC_Home());
        }
    }
}
