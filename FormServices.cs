using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Barbermanager
{
    public partial class FormServices : Form
    {
        public FormServices()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            button1.BackColor = ColorTranslator.FromHtml("#354A5F");
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeServico.Text) || string.IsNullOrWhiteSpace(txtPrecoServico.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

          
            try
            {
                // Usa a cultura invariante (padrão com ponto) para converter o texto limpando a vírgula
                string textoFormatado = txtPrecoServico.Text.Replace(",", ".");
                double preco = double.Parse(textoFormatado, System.Globalization.CultureInfo.InvariantCulture);

                using (var conn = Barbermanager.Models.DataBaseConfig.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Servicos (Nome, Preco , Tempo) VALUES (@nome, @preco ,@tempo)";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNomeServico.Text);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@tempo", txtTempoServico.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Serviço cadastrado com sucesso!");

                // Limpar campos e atualizar a lista
                txtNomeServico.Clear();
                txtPrecoServico.Clear();
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

    }
}
