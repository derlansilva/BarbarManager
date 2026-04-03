using Barbermanager.Models; // Importante adicionar esta linha no topo!
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Barbermanager
{
    public partial class CadastrarNovoCliente : Form
    {
        public CadastrarNovoCliente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            btnCadastrar.BackColor = ColorTranslator.FromHtml("#354A5F");
            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            

        }

        private void btnNovo_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            int radius = 5; // Ajuste o arredondamento aqui
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                btn.Region = new Region(path);
            }
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            try
            {
                using (var conn = Barbermanager.Models.DataBaseConfig.GetConnection())
                {

                   

                    conn.Open();
                    string sql = "INSERT INTO Clientes (Nome, Telefone) VALUES (@nome, @telefone)";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Informa que deu tudo certo e fecha o modal
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar no banco: " + ex.Message);
                
            }
        }
    }
}
