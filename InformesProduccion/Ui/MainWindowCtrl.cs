using System;
using System.Data;
using System.Runtime.CompilerServices;
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


        }
        public MainWindowView View
        {
            get;
        }

        void InformeAnual()
        {
            int ano;
            string strAno;
            
        }

        private RegistroMeritos meritos;

    }
}