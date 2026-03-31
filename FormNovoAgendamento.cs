using Barbermanager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Barbermanager
{
    public partial class FormNovoAgendamento : Form
    {
        public FormNovoAgendamento()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormNovoAgendamento_Load(object sender, EventArgs e)
        {
            ConfigurarCombos();
            CarregarDadosDosCombos();
        }

        private void ConfigurarCombos()
        {
            // Isso ativa o efeito de "aparecer o nome abaixo" enquanto digita
            cbClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbClientes.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbServicos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbServicos.AutoCompleteSource = AutoCompleteSource.ListItems;
        }



        private void CarregarDadosDosCombos()
        {
            using (var conn = Barbermanager.Models.DataBaseConfig.GetConnection())
            {
                conn.Open();

                // Carregar Clientes
                var cmdClie = new Microsoft.Data.Sqlite.SqliteCommand("SELECT Id, Nome FROM Clientes", conn);
                using (var reader = cmdClie.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbClientes.Items.Add(new ComboboxItem
                        {
                            Value = Convert.ToInt32(reader["Id"]),
                            Text = reader["Nome"].ToString()
                        });
                    }
                }

                // Carregar Serviços
                var cmdServ = new Microsoft.Data.Sqlite.SqliteCommand("SELECT Id, Nome FROM Servicos", conn);
                using (var reader = cmdServ.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbServicos.Items.Add(new ComboboxItem
                        {
                            Value = Convert.ToInt32(reader["Id"]),
                            Text = reader["Nome"].ToString()
                        });
                    }
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedItem == null || cbServicos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um cliente e um serviço da lista.");
                return;
            }

            // Pegando os valores reais (IDs)
            int clienteId = ((ComboboxItem)cbClientes.SelectedItem).Value;
            int servicoId = ((ComboboxItem)cbServicos.SelectedItem).Value;
            string data = dtpData.Value.ToString("yyyy-MM-dd");
            string hora = dtpHora.Value.ToString("HH:mm");
            string status = "Aguardando Confirmação";

            try
            {
                using (var conn = Barbermanager.Models.DataBaseConfig.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Agendamentos (ClienteId, ServicoId, Data, Horario, Status) " +
                                 "VALUES (@cid, @sid, @data, @hora, @status)";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", clienteId);
                        cmd.Parameters.AddWithValue("@sid", servicoId);
                        cmd.Parameters.AddWithValue("@data", data);
                        cmd.Parameters.AddWithValue("@hora", hora);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Agendamento confirmado com sucesso!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao agendar: " + ex.Message);
            }
        }
    }
}
