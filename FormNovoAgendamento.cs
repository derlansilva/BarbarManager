using Barbermanager.Models;
using Microsoft.Data.Sqlite;
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

            btnConfirmar.BackColor = ColorTranslator.FromHtml("#354A5F");
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.FlatAppearance.BorderSize = 0;
        }

        private void FormNovoAgendamento_Load(object sender, EventArgs e)
        {
            ConfigurarCombos();
            CarregarDadosDosCombos();
           // CarregarHorariosDisponiveis();
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

        private void btnNovo_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            int radius = 10; // Ajuste o arredondamento aqui
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

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            // Quando mudar o dia, ele atualiza a lista de horários livres
            //();
        }
        /*
        private void CarregarHorariosDisponiveis()
        {
            cbHorario.Items.Clear();
            string dataSelecionada = dtpData.Value.ToString("yyyy-MM-dd");

            try
            {
                using (var conn = DataBaseConfig.GetConnection())
                {
                    conn.Open();

                    // Query TOP: Pega horários padrão que não têm agendamento ativo naquela data
                    string sql = @"
                SELECT Hora FROM HorariosPadrao 
                WHERE Hora NOT IN (
                    SELECT Horario FROM Agendamentos 
                    WHERE Data = @data AND Status != 'Cancelado'
                )
                ORDER BY Hora ASC";

                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@data", dataSelecionada);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbHorario.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                if (cbHorario.Items.Count > 0) cbHorario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        */
    }
}
