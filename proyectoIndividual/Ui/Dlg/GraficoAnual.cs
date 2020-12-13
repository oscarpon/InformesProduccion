using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using proyectoIndividual.Core;

namespace proyectoIndividual.Ui.Dlg
{
    public partial class GraficoAnual : Form
    {
        public GraficoAnual()
        {
            InitializeComponent();
        }

        private void GraficoAnual_Load(object sender, EventArgs e)
        {
            
            string[] series = {"Oscar", "Raul", "Ponte"};
            int[] puntos = {23, 10, 70};

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Informe Anual");


            for (int i = 0; i < series.Length; i++)
            {
                Series serie = chart1.Series.Add(series[i]);
                serie.Points.Add(puntos[i]);
            }
        }

        
    }
}