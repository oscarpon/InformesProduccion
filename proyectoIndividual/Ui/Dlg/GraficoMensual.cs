using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using proyectoIndividual.Core;

namespace proyectoIndividual.Ui.Dlg
{
    public partial class GraficoMensual : Form
    {
        public GraficoMensual(GestionMeritoCientifico meritos)
        {
            this.Meritos = meritos;
            InitializeComponent();
        }

        private void GraficoMensual_Load(object sender, EventArgs e)
        {
            string[] series = this.Meritos.getListAños().Distinct().ToArray();
            int[] puntos = this.Meritos.getNumeroVecesAño();

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Informe por años");


            for (int i = 0; i < series.Length; i++)
            {
                Series serie = chart1.Series.Add(series[i]);
                serie.Points.Add(puntos[i]);
            }
        }

        private GestionMeritoCientifico Meritos;

    }
}