using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace proyectoIndividual.Ui.Dlg
{
    public partial class GraficoMensual : Form
    {
        public GraficoMensual()
        {
            InitializeComponent();
        }

        private void GraficoMensual_Load(object sender, EventArgs e)
        {
            string[] series = {"Oscar", "Raul", "Ponte"};
            int[] puntos = {23, 10, 70};

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Informe Mensual");


            for (int i = 0; i < series.Length; i++)
            {
                Series serie = chart1.Series.Add(series[i]);
                serie.Points.Add(puntos[i]);
            }
        }
    }
}