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


        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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
