using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Barbermanager
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
            CarregarDashboard();
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

                    
                    string hoje = DateTime.Now.ToString("yyyy-MM-dd");
                    string filtroNome = "%%"; 

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
                   WHERE A.Data = @data AND C.Nome LIKE @nome
                    AND A.Status IN ('Confirmado', 'Aguardando Confirmação')
                   ORDER BY A.Horario ASC";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, connection))
                    {
                        // 2. DESCOMENTE e preencha os parâmetros aqui:
                        cmd.Parameters.AddWithValue("@data", hoje);
                        cmd.Parameters.AddWithValue("@nome", filtroNome);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // 1. Criamos o item apenas UMA VEZ com o ID (Coluna 0)
                                ListViewItem item = new ListViewItem(reader.GetValue(0).ToString());

                                // 2. Adicionamos as colunas na ordem correta
                                item.SubItems.Add(reader.GetValue(1).ToString()); // Data
                                item.SubItems.Add(reader.GetValue(2).ToString()); // Horario
                                item.SubItems.Add(reader.GetValue(3).ToString()); // Cliente
                                item.SubItems.Add(reader.GetValue(4).ToString()); // Serviço
                                item.SubItems.Add(reader.GetValue(5).ToString()); // Telefone

                                // 3. Pegamos o Status (Coluna 6)
                                string status = reader.GetValue(6).ToString();

                                // 4. Adicionamos o SubItem do Status e já guardamos na variável para mudar a cor
                                var subItemStatus = item.SubItems.Add(status);

                                // 5. Aplicamos a cor baseada no texto do status
                                if (status == "Finalizado")
                                    subItemStatus.ForeColor = Color.DarkGreen;
                                else if (status == "Cancelado")
                                    subItemStatus.ForeColor = Color.Red;
                                else if (status == "Confirmado")
                                    subItemStatus.ForeColor = Color.Blue;
                                else
                                    subItemStatus.ForeColor = Color.Orange;

                                // 6. Adicionamos o item completo à ListView
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


        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(ColorTranslator.FromHtml("#354A5F")))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (!e.Item.Selected)
            {
                Color corZebra = ColorTranslator.FromHtml("#F2F5F8");
                using (SolidBrush backBrush = new SolidBrush(e.ItemIndex % 2 == 0 ? Color.White : corZebra))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                }
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }

            // AQUI ESTÁ O SEGREDO: Usamos e.SubItem.ForeColor 
            // para que o Verde/Vermelho/Azul dos status apareça!
            Color corTexto = e.Item.Selected ? Color.White : e.SubItem.ForeColor;

            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds,
                corTexto, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Apenas deixa o Windows saber que o item está sendo processado
        }


        public void CarregarDashboard()
        {
            try
            {
                using (var connection = Models.DataBaseConfig.GetConnection())
                {
                    connection.Open();

                    // Pegamos a data atual formatada para o SQLite
                    string hoje = DateTime.Now.ToString("yyyy-MM-dd");
                    string mesAtual = DateTime.Now.ToString("MM");

                    // 1. Ganhos do Mês (Ajustado para comparar o mês corretamente)
                    string sqlGanhos = @"SELECT SUM(S.Preco) 
                                 FROM Agendamentos A 
                                 JOIN Servicos S ON A.ServicoId = S.Id 
                                 WHERE A.Status = 'Finalizado' 
                                 AND strftime('%m', A.Data) = @mes";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sqlGanhos, connection))
                    {
                        cmd.Parameters.AddWithValue("@mes", mesAtual);
                        var result = cmd.ExecuteScalar();
                        lblGanhos.Text = result != DBNull.Value ? string.Format("{0:C}", result) : "R$ 0,00";
                    }

                    // 2. Total de Agendamentos de Hoje (Usando o parâmetro corretamente)
                    string sqlHoje = "SELECT COUNT(*) FROM Agendamentos WHERE Data = @hoje  AND Status IN ('Confirmado' , 'Aguardando Confirmação')";
                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sqlHoje, connection))
                    {
                        cmd.Parameters.AddWithValue("@hoje", hoje);
                        lblTotalHoje.Text = cmd.ExecuteScalar().ToString();
                    }

                    // 3. Próximo Cliente
                    string sqlProximo = @"SELECT C.Nome || ' - ' || A.Horario 
                                  FROM Agendamentos A 
                                  JOIN Clientes C ON A.ClienteId = C.Id 
                                  WHERE A.Data = @hoje 
                                  AND A.Status = 'Aguardando Confirmação' 
                                  ORDER BY A.Horario ASC LIMIT 1";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sqlProximo, connection))
                    {
                        cmd.Parameters.AddWithValue("@hoje", hoje);
                        var res = cmd.ExecuteScalar();
                        // Se você tiver um lblProximo, descomente a linha abaixo:
                        // lblProximo.Text = res != null ? res.ToString() : "Sem próximos";
                    }

                    lblGanhos.ForeColor = ColorTranslator.FromHtml("#2B7D2B");

                    // Para os agendados (Azul)
                    lblTotalHoje.ForeColor = ColorTranslator.FromHtml("#354A5F");

                    lblAgendamento.ForeColor = ColorTranslator.FromHtml("#354A5F");
                    lblGn.ForeColor = ColorTranslator.FromHtml("#2B7D2B");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no dashboard: " + ex.Message);
            }
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            int borderRadius = 10; 

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(p.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(p.Width - borderRadius, p.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, p.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();
                p.Region = new Region(path);
            }
        }

        private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                AtualizarStatusAgendamento("Confirmado");
            }
            else
            {
                MessageBox.Show("Selecione um agendamento na lista primeiro!");
            }
        }

        private void finalizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarStatusAgendamento("Finalizado");
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarStatusAgendamento("Cancelado");
        }

        private void AtualizarStatusAgendamento(string novoStatus)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                string statusAtual = listView1.SelectedItems[0].SubItems[6].Text;

                if (statusAtual == "Finalizado" || statusAtual == "Cancelado")
                {
                    MessageBox.Show($"Este agendamento já está '{statusAtual}' e não pode mais ser alterado.",
                    "Ação Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string idAgendamento = listView1.SelectedItems[0].Text;
                string nomeCliente = listView1.SelectedItems[0].SubItems[3].Text;


                try
                {
                    using (var conn = Models.DataBaseConfig.GetConnection())
                    {
                        conn.Open();
                        string sql = "UPDATE Agendamentos SET Status = @status WHERE Id = @id";

                        using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", novoStatus);
                            cmd.Parameters.AddWithValue("@id", idAgendamento);
                            cmd.ExecuteNonQuery();
                        }

                        if(novoStatus == "Finalizado")
                        {
                            string sqlFid = "SELECT COUNT(*) FROM Agendamentos WHERE Status = 'Finalizado' " +
                                    "AND ClienteId = (SELECT ClienteId FROM Agendamentos WHERE Id = @id)";

                            using (var cmdFid = new Microsoft.Data.Sqlite.SqliteCommand(sqlFid, conn))
                            {
                                cmdFid.Parameters.AddWithValue("@id", idAgendamento);
                                int totalCortes = Convert.ToInt32(cmdFid.ExecuteScalar());

                               
                                if (totalCortes > 0 && totalCortes % 10 == 0)
                                {
                                    MessageBox.Show($"⭐ CLIENTE FIEL! ⭐\n\nO cliente {nomeCliente} acabou de completar {totalCortes} cortes!\nEste atendimento deve ser GRÁTIS.",
                                        "Programa de Fidelidade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }

                    
                    CarregarAgendamentos();
                    CarregarDashboard();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar status: " + ex.Message);
                }
            }
        }


        private void ConfigurarEstiloGrafico()
        {
            /*var area = chart1.ChartAreas[0];

            // Remove as linhas de grade do fundo (fica mais clean)
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.ForeColor = Color.Gray;
            area.AxisY.LabelStyle.ForeColor = Color.Gray;

            // Borda do gráfico
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Color = ColorTranslator.FromHtml("#354A5F"); // Azul SAP*/
        }
    }
}
