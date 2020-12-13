using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Xml.Linq;
using proyectoIndividual.Ui.Dlg;
using proyectoIndividual.Core;

namespace proyectoIndividual
{
    
    using System.Windows.Forms;
    using System.Windows;
    using System.Drawing;
    using System;
    
    public class MainWindowCore : Form
    {
        public int i = 0;
        public MainWindowCore()
        {
            
            this.View = new MainWindowView();
            Console.Write("Main core");
            Console.WriteLine(this.Meritos);
            this.Meritos = new GestionMeritoCientifico();
            this.Miembros = new GestionMiembros();
           
         

            this.View.FormClosed += (sender, e) => this.OnQuit();
            this.View.opGuardar.Click += (sender, e) => this.Guardar();
            this.View.opSalir.Click += (sender, e) => this.Salir();


            //meritos cientificos
            this.View.opConsultaMerito.Click += (sender, e) => this.ConsultaMeritoCientifico();
            this.View.opInsertarMerito.Click += (sender, e) => this.InsertaMeritoCientifico();
            
            //informes
            this.View.opInfAnual.Click += (sender, e) => this.InformeAnual();
            this.View.opInfMensual.Click += (sender, e) => this.InformeMensual();
            this.View.opTodos.Click += (sender, e) => this.InformeDeTodos();
            
            //miembros
            this.View.opConsultaMiembro.Click += (sender, e) => this.ConsultaMiembro();
            this.View.opInsertarMiembro.Click += (sender, e) => this.InsertaMiembro();

            
        }
        
        void InsertaMeritoCientifico()
        {
            Console.WriteLine("Inserta Merito Cientifico");
            var dlgInsertaMerito = new DlgInsertaMerito(this.Meritos);
            i++;

            this.View.Hide();
            MeritoCientifico nuevoMeritoCientifico = new MeritoCientifico("",0,"",0,0,0,"");

            if (dlgInsertaMerito.ShowDialog() == DialogResult.OK)
            {
                 nuevoMeritoCientifico = new MeritoCientifico(dlgInsertaMerito.Tipo,i,dlgInsertaMerito.Issn.ToString(),int.Parse(dlgInsertaMerito.Año),int.Parse(dlgInsertaMerito.PagIn), int.Parse(dlgInsertaMerito.PagFin), dlgInsertaMerito.Autor);
                 Console.WriteLine(nuevoMeritoCientifico);
                 this.Meritos.añadirMeritoCientifico(nuevoMeritoCientifico);
                 
            }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }
        }
        
        
        
        void ConsultaMeritoCientifico()
        {
            Console.WriteLine("Consulta merito cientifico");
            var dlgConsultaMerito = new DlgConsultaMerito(this.Meritos);


            this.View.Hide();

            if (dlgConsultaMerito.ShowDialog() == DialogResult.OK) { }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }

        }
        
        void InsertaMiembro()
        {
            Console.WriteLine("Inserta Miembro");

            var dlgInsertaMiembro = new DlgInsertaMiembro(this.Miembros);
            

            this.View.Hide();
            Miembro nuevoMiembro = new Miembro("","",0,"","");

            if (dlgInsertaMiembro.ShowDialog() == DialogResult.OK)
            {
                nuevoMiembro = new Miembro(dlgInsertaMiembro.DNI,dlgInsertaMiembro.Nombre,dlgInsertaMiembro.Telefono,dlgInsertaMiembro.Email,dlgInsertaMiembro.DirPostal);
                Console.WriteLine(nuevoMiembro);
                this.Miembros.añadirMiembro(nuevoMiembro);
                 
            }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }
        }
        
        void ConsultaMiembro()
        {
            Console.WriteLine("Consulta miembro");
            var dlgConsultaMiembro = new DlgConsultaMiembro(this.Miembros);


            this.View.Hide();

            if (dlgConsultaMiembro.ShowDialog() == DialogResult.OK) { }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }

        }
        
        
        
        public void Salir()
        {
            Console.WriteLine("Main core guardar y salir");
            System.Windows.Forms.Application.Exit();
        }

        void Guardar()
        {
            Console.WriteLine("Main core solo guardar");
            
            
        }

        void OnQuit()
        {
            System.Windows.Forms.Application.Exit();
        }
        
        void InformeAnual()
        {
            Console.WriteLine("Informe Anual");
            var dlgInformeAnual = new GraficoAnual();


            this.View.Hide();

            if (dlgInformeAnual.ShowDialog() == DialogResult.OK) { }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }
        }

       void InformeMensual()
        {
            Console.WriteLine("Informe Mensual");
            var dlgInformeMensual = new GraficoMensual();


            this.View.Hide();

            if (dlgInformeMensual.ShowDialog() == DialogResult.OK) { }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }
        }

        void InformeDeTodos()
        {
            Console.WriteLine("Informe Todos");
            var dlgInformeTodos = new DlgInformeTodos(this.Meritos);


            this.View.Hide();

            if (dlgInformeTodos.ShowDialog() == DialogResult.OK)
            {
                this.Meritos.getMeritoAño(dlgInformeTodos.Año);
            }

            if (!this.View.IsDisposed) { this.View.Show(); }
            else { System.Windows.Forms.Application.Exit(); }
        }

        
        public MainWindowView View { get; private set; }
        private GestionMeritoCientifico Meritos { get; set; }
        
        private GestionMiembros Miembros { get; set; }
    }
}