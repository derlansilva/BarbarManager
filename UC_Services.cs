using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Barbermanager
{
    public partial class UC_Services : UserControl
    {
        public UC_Services()
        {
            InitializeComponent();
            CarregarServicos();
        }

        private void btnNovoServiço_Click(object sender, EventArgs e)
        {
            using(FormServices services = new FormServices())
            {
                var result = services.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CarregarServicos();

                }
            }
        }


        private void CarregarServicos()
        {
            listView1.Items.Clear();
            try
            {
                using (var conn = Barbermanager.Models.DataBaseConfig.GetConnection())
                {
                    conn.Open();
                    // Note que usei os nomes das colunas conforme sua imagem (Titulo, Valor, Tempo)
                    string sql = "SELECT Id, Nome , Preco , Tempo FROM Servicos";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               
                                ListViewItem item = new ListViewItem(reader["Id"].ToString());

                               
                                item.SubItems.Add(reader["Nome"].ToString()); // Titulo

                            
                                double preco = Convert.ToDouble(reader["Preco"]);
                                item.SubItems.Add(preco.ToString("C2")); // Valor


                                string valorTempo = reader["Tempo"] != DBNull.Value ? reader["Tempo"].ToString() : "0";
                                item.SubItems.Add(valorTempo + " min");

                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar serviços: " + ex.Message);
            }

        }
    }
}
