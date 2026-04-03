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



            btnNovoServiço.BackColor = ColorTranslator.FromHtml("#354A5F");
            btnNovoServiço.ForeColor = Color.White;
            btnNovoServiço.FlatStyle = FlatStyle.Flat;
            btnNovoServiço.FlatAppearance.BorderSize = 0;
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
        private void btnNovoServiço_Click(object sender, EventArgs e)
        {
            using(FormServices modal = new FormServices())
            {
                var result = modal.ShowDialog();

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

        // 1. Desenha o Cabeçalho Azul SAP
        private void listViewServicos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(ColorTranslator.FromHtml("#354A5F")))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }
            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.White,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        // 2. Desenha as Linhas Zebra e o Texto
        private void listViewServicos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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
                // Cor azul de destaque quando selecionado
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }

            // Texto (Branco se selecionado, Preto se normal)
            Color corTexto = e.Item.Selected ? Color.White : Color.Black;

            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds,
                corTexto, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        // 3. Método Obrigatório (vazio)
        private void listViewServicos_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Apenas para o Windows saber que o item está sendo processado
        }


    }
}
