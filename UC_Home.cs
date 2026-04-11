using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

using Microsoft.Data.Sqlite; // Para o SQLite funcionar

using LiveChartsCore.SkiaSharpView.WinForms;



namespace Barbermanager
{
    public partial class UC_Home : UserControl
    {
       
        private CartesianChart graficoMensal; 

        public UC_Home()
        {
            InitializeComponent();
            CarregarDashboard();

            CarregarGrafico();
        }


        public void CarregarDashboard()
        {
            try
            {
                using (var connection = Models.DataBaseConfig.GetConnection())
                {
                    connection.Open();

                    
                    string hoje = DateTime.Now.ToString("yyyy-MM-dd");
                    string mesAtual = DateTime.Now.ToString("MM");

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

                    string sqlHoje = "SELECT COUNT(*) FROM Agendamentos WHERE Data = @hoje  AND Status IN ('Confirmado' , 'Aguardando Confirmação')";
                    using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(sqlHoje, connection))
                    {
                        cmd.Parameters.AddWithValue("@hoje", hoje);
                        lblTotalHoje.Text = cmd.ExecuteScalar().ToString();
                    }

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
                       
                    }

                    lblGanhos.ForeColor = ColorTranslator.FromHtml("#2B7D2B");


                    lblTotalHoje.ForeColor = ColorTranslator.FromHtml("#007AFF");

                    lblAgendamento.ForeColor = ColorTranslator.FromHtml("#007AFF");
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

        private void CarregarGrafico()
        {
            try
            {
                if (graficoMensal == null)
                {
                    graficoMensal = new CartesianChart();
                    graficoMensal.Dock = DockStyle.Fill;
                    panelGrafico.Controls.Add(graficoMensal);
                }

                var labels = new List<string>();
                var valores = new List<double>();

                using (var conn = Models.DataBaseConfig.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT strftime('%m/%Y', Data) as Mes, SUM(S.Preco) as Total 
                           FROM Agendamentos A 
                           JOIN Servicos S ON A.ServicoId = S.Id 
                           WHERE A.Status = 'Finalizado' AND A.Data >= date('now', '-6 months') 
                           GROUP BY Mes ORDER BY A.Data ASC";

                    using (var cmd = new SqliteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            string dataTexto = reader["Mes"].ToString();
                            DateTime dt = DateTime.ParseExact(dataTexto, "MM/yyyy", null);


                            string mesExtenso = dt.ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                            // Deixa a primeira letra maiúscula
                            mesExtenso = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);
                            labels.Add(mesExtenso);
                            valores.Add(Convert.ToDouble(reader["Total"]));
                        }

                        graficoMensal.Series = new ISeries[]
                        {
                            new ColumnSeries<double>
                            {
                                Values = valores,
                                Name = "Faturamento",
                                Fill = new SolidColorPaint(SKColors.DarkGreen),
                                Padding = 15,
                                MaxBarWidth = 60,
                                Rx = 8, Ry = 8 
                            }
                        };

                        graficoMensal.XAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
                        {
                            new LiveChartsCore.SkiaSharpView.Axis
                            {
                                Labels = labels,
                                LabelsRotation = 0,
                                TextSize = 12
                            }
                        };      

                        graficoMensal.YAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
                        {
                            new LiveChartsCore.SkiaSharpView.Axis
                            {
                                Labeler = v => v.ToString("C0"), // R$ sem centavos para limpar o visual
                                MinStep = 100, // FORÇA A ESCALA DE 100 EM 100
                                ForceStepToMin = true,
                                TextSize = 12
                            }
                        };

                        graficoMensal.YAxes = new List<LiveChartsCore.SkiaSharpView.Axis>
{
                        new LiveChartsCore.SkiaSharpView.Axis
                            {
                                Labeler = v => v.ToString("C0"),
                                // Define o intervalo fixo entre as linhas
                                MinStep = 100,
                                UnitWidth = 100,
                                // Define onde o gráfico começa (geralmente zero)
                                MinLimit = 0,
                                TextSize = 12,
                                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(80)) { StrokeThickness = 1 }
                            }
                         };

                    }
                }

                if (valores.Count == 0) return;

                graficoMensal.Series = new ISeries[]
                {
            new ColumnSeries<double>
            {
                Values = valores,
                Name = "Ganhos",
                Fill = new SolidColorPaint(SKColors.DarkGreen),
                Padding = 15,
                MaxBarWidth = 50
            }
                };

                // AQUI AS LINHAS QUE VOCÊ MANDOU NA FOTO, CORRIGIDAS:
                graficoMensal.XAxes = new List<LiveChartsCore.SkiaSharpView.Axis> {
            new LiveChartsCore.SkiaSharpView.Axis { Labels = labels }
        };

                graficoMensal.YAxes = new List<LiveChartsCore.SkiaSharpView.Axis> {
            new LiveChartsCore.SkiaSharpView.Axis { Labeler = v => v.ToString("C2") }
        };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no Dashboard: " + ex.Message);
            }
        }

      
    }
}
