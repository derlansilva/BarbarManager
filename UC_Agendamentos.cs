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
    public partial class UC_Agendamentos : UserControl
    {
        public UC_Agendamentos()
        {
            InitializeComponent();

            if (listView1.Columns.Count > 0)
                listView1.Columns[listView1.Columns.Count - 1].Width = -2;

            CarregarAgendamentos();



        }


        public void CarregarAgendamentos()
        {
            listView1.Items.Clear();

            try
            {
                using (var connection = Models.DataBaseConfig.GetConnection())
                {
                    connection.Open();
                    string sql = @"SELECT 
                A.Id, 
                A.Data, 
                A.Horario, 
                C.Nome, 
                S.Nome, 
                C.Telefone, 
                A.Status 
               FROM Agendamentos A 
               JOIN Clientes C ON A.ClienteId = C.Id 
               JOIN Servicos S ON A.ServicoId = S.Id 
               ORDER BY A.Horario ASC";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Usar GetValue(indice) evita o erro de "Parameter name"
                                ListViewItem item = new ListViewItem(reader.GetValue(0).ToString()); // ID
                                item.SubItems.Add(reader.GetValue(1).ToString()); // Data
                                item.SubItems.Add(reader.GetValue(2).ToString()); // Horario
                                item.SubItems.Add(reader.GetValue(3).ToString()); // Nome do Cliente
                                item.SubItems.Add(reader.GetValue(4).ToString()); // Nome do Serviço
                                item.SubItems.Add(reader.GetValue(5).ToString()); // Telefone
                                item.SubItems.Add(reader.GetValue(6).ToString()); // Status

                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

      

        private void btnNovoAgendamento_Click(object sender, EventArgs e)
        {
            using(FormNovoAgendamento modal = new FormNovoAgendamento())
            {
                var result = modal.ShowDialog();

                if(result == DialogResult.OK)
                {
                    CarregarAgendamentos();

                }
            }
        }
    }
}
