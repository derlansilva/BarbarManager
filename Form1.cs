namespace Barbermanager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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



    }
}
