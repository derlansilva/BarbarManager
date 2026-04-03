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

            this.BackColor = ColorTranslator.FromHtml("#E5E9ED");

       

            btnNovoAgendamento.BackColor = ColorTranslator.FromHtml("#354A5F");
            btnNovoAgendamento.ForeColor = Color.White;
            btnNovoAgendamento.FlatStyle = FlatStyle.Flat;
            btnNovoAgendamento.FlatAppearance.BorderSize = 0;
           


            // ListView (Branco com bordas suaves)
            listView1.BackColor = Color.White;
            listView1.BorderStyle = BorderStyle.None;

            if (listView1.Columns.Count > 0)
                listView1.Columns[listView1.Columns.Count - 1].Width = -2;

            listView1.ContextMenuStrip = menuStatus;
            CarregarAgendamentos();



        }

        private void btnNovo_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            int radius = 5; 
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

        private void txtBuscaNome_TextChanged(object sender, EventArgs e)
        {
            
            CarregarAgendamentos(); // Chama o seu método aqui dentro!
        }


        private void dtpDataFiltro_ValueChanged(object sender, EventArgs e)
        {
            // Sempre que a data mudar, ele executa a query com a nova data
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

                    string dataFiltro = dtpData.Value.ToString("yyyy-MM-dd"); // Ajuste o nome para o seu DateTimePicker
                    string nomeFiltro = "%" + txtBuscaNome.Text + "%";

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
                   WHERE A.Data = @data    AND C.Nome LIKE @nome
                   ORDER BY A.Horario ASC";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@data", dataFiltro);
                        cmd.Parameters.AddWithValue("@nome", nomeFiltro);

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

      

        private void btnNovoAgendamento_Click(object sender, EventArgs e)
        {
            using(FormNovoAgendamento modal = new FormNovoAgendamento())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CarregarAgendamentos();

                }
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

                if(statusAtual =="Finalizado" || statusAtual == "Cancelado")
                {
                    MessageBox.Show($"Este agendamento já está '{statusAtual}' e não pode mais ser alterado.",
                "Ação Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string idAgendamento = listView1.SelectedItems[0].Text; 

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
                    }

                    // Recarrega a lista para mostrar o novo status em tempo real
                    CarregarAgendamentos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar status: " + ex.Message);
                }
            }
        }


        // 1. Desenha o Cabeçalho Azul SAP
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(ColorTranslator.FromHtml("#354A5F")))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        // 2. Desenha as Linhas Zebra e o Texto Colorido
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

        // 3. Método obrigatório para OwnerDraw
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Apenas deixa o Windows saber que o item está sendo processado
        }

    }
}
