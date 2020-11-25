using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms.Design;
using System.Xml;
using InformesProduccion.Core;


namespace InformesProduccion.Ui
{
    using WForms = System.Windows.Forms;
    public class MainWindowCtrl
    {
        public MainWindowCtrl()
        {
            this.View = new MainWindowView();
            this.meritos = RegistroMeritos.RecuperaXml();
            this.View.InfAnual.TextChanged += (sender, args) => this.InformeAnual();
            this.View.BtInfAnual.Click += (sender, args) => this.InformeAnual();
            this.View.InfMensual.SelectedIndexChanged += (sender, args) => this.InformeMensual(); 
            //this.View.BtInfMensual.Click += (sender, args) => this.InformeMensual();
            //this.View.BtnInfTodos.Click += (sender, args) => this.MostrarTodos();
            Console.WriteLine(this.View.BtnInfTodos);

        }
        
        public MainWindowView View
        {
            get;
        }

        public void MostrarTodos()
        {
            var numMeritos = this.meritos.Count;

            for (var i = 0; i < numMeritos; i++)
            {
                this.View.PanelLista.Rows.Add();
            }

            WForms.DataGridViewRow row = this.View.PanelLista.Rows[1];

            row.Cells[0].Value = merito.Doi;
            row.Cells[1].Value = merito.Issn;
            row.Cells[2].Value = merito.Ano;
            row.Cells[3].Value = merito.Pagina;
            row.Cells[4].Value = merito.Autor;

        }

        public void InformeMensual()
        {
            var grafMes = new GraficoView();
        }

        public void InformeAnual()
        {
            var grafAn = new GraficoView();
        }

        private RegistroMeritos meritos;
        private Merito merito;

    }
}