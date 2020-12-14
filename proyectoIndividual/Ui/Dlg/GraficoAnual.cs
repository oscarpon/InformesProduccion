using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using proyectoIndividual.Core;

namespace proyectoIndividual.Ui.Dlg
{
    public partial class GraficoAnual : Form
    {
        public GraficoAnual(GestionMeritoCientifico meritos)
        {
            this.Meritos = meritos;
            InitializeComponent();
        }

        private void GraficoAnual_Load(object sender, EventArgs e)
        {


            string[] series = this.Meritos.getListAutores().Distinct().ToArray();
            int[] puntos = this.Meritos.getNumeroVeces();

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Informe Anual");


            for (int i = 0; i < series.Length; i++)
            {
                Series serie = chart1.Series.Add(series[i]);
                serie.Points.Add(puntos[i]);
            }
        }

        private GestionMeritoCientifico Meritos;


    }
}