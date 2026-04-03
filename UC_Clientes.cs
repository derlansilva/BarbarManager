using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Barbermanager
{
    public partial class UC_Clientes : UserControl
    {
        public UC_Clientes()
        {
            InitializeComponent();

            CarregarClientes();

            btnNovoCliente.BackColor = ColorTranslator.FromHtml("#354A5F");
            btnNovoCliente.ForeColor = Color.White;
            btnNovoCliente.FlatStyle = FlatStyle.Flat;
            btnNovoCliente.FlatAppearance.BorderSize = 0;
            listViewClientes.OwnerDraw = true;

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

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            using(CadastrarNovoCliente modal = new CadastrarNovoCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CarregarClientes();

                }
            }
        }

        private void listViewClientes_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // 1. Lógica da cor Zebra (Linha sim, linha não)
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
                // Cor quando a linha está selecionada
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }

            // 2. Desenhar o texto (IMPORTANTE: sem isso a lista fica em branco)
            // Usamos e.SubItem.ForeColor para manter o verde/vermelho que definimos no carregamento
            Color corTexto = e.Item.Selected ? Color.White : e.SubItem.ForeColor;

            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds,
                corTexto, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void listViewClientes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Cor de fundo do cabeçalho (Azul Profissional)
            using (SolidBrush backBrush = new SolidBrush(ColorTranslator.FromHtml("#354A5F")))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            // Texto em Branco e Centralizado
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }


        public void CarregarClientes()
        {
            // Limpa a lista antes de carregar
            listViewClientes.Items.Clear();

            try
            {
                using (var connection = Models.DataBaseConfig.GetConnection())
                {
                    connection.Open();

                    // Query que busca os dados do cliente e conta quantos cortes 'Finalizados' ele tem
                    string sql = @"SELECT 
                            C.Id, 
                            C.Nome, 
                            C.Telefone,
                            (SELECT COUNT(*) FROM Agendamentos WHERE ClienteId = C.Id AND Status = 'Finalizado') as TotalCortes
                           FROM Clientes C
                           ORDER BY C.Nome ASC";

                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sql, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Criando o item com o ID
                                ListViewItem item = new ListViewItem(reader["Id"].ToString());

                                // Adicionando as sub-colunas
                                item.SubItems.Add(reader["Nome"].ToString());
                                item.SubItems.Add(reader["Telefone"].ToString());

                                int totalCortes = Convert.ToInt32(reader["TotalCortes"]);
                                item.SubItems.Add(totalCortes.ToString());

                                // Lógica de Fidelidade: A cada 10 cortes
                                if (totalCortes > 0 && totalCortes % 10 == 0)
                                {
                                    item.SubItems.Add("⭐ GANHOU GRÁTIS!");
                                    item.ForeColor = Color.DarkGreen; // Texto verde para ganhadores
                                    item.Font = new Font(listViewClientes.Font, FontStyle.Bold);
                                }
                                else
                                {
                                    int faltam = 10 - (totalCortes % 10);
                                    item.SubItems.Add($"Faltam {faltam} cortes");
                                    item.ForeColor = Color.Black;
                                }

                                listViewClientes.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

    }
}
