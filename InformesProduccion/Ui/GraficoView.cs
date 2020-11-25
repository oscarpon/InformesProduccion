using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using InformesProduccion.Core;

namespace InformesProduccion.Ui
{
    public partial class GraficoView : Form
    {
        public GraficoView()
        {
            InitializeComponent();
            //Load += chart1_Load;
            
        }
        
        private void chart1_Load(Object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("../meritos.xml");
            chart1.Series["Series1"].XValueMember = "AUTOR";
            chart1.Series["Series1"].YValueMembers = "ANO";
            chart1.DataSource = ds;
            chart1.DataBind();
            
            this.chart1.Legends.Add("Legend1");  
            this.chart1.Legends[0].Enabled = true;  
            this.chart1.Legends[0].Docking = Docking.Bottom;  
            this.chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;  
            this.chart1.Series[0].LegendText = "#VALX (#PERCENT)";
        }
        
        
        
        
    }
}