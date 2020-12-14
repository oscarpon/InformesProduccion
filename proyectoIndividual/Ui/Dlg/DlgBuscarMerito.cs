using System.Collections.Generic;
using proyectoIndividual.Core;
using System;

namespace proyectoIndividual.Ui.Dlg
{
    using System.Windows.Forms;
    using System.Drawing;
    
    public class DlgBuscarMerito : Form
    {
        
        
        public DlgBuscarMerito()
        {
            this.Build();
            this.CenterToScreen();
        }

        public DlgBuscarMerito(GestionMeritoCientifico meritos)
        {
            
            this.Meritos = meritos;
            this.Build();
            this.CenterToScreen();
            
            this.MinimumSize = new Size(500, 500);
            this.MaximumSize = new Size(500, 500);
            this.MaximizeBox = false;

            this.opSalir.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Salir(); };
            this.opVolver.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;

        }

        public void Build()
        {

            this.BuildMenu();
            
            this.SuspendLayout();
            
            this.pnlBuscar = new TableLayoutPanel
            {
                Size = new Size(500,500),
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(23, 160, 219),
            };
            
            pnlBuscar.SuspendLayout();
            this.Controls.Add(pnlBuscar);
            
            var pnlMerito = this.BuildMerito();
            pnlBuscar.Controls.Add(pnlMerito);

            //Tipo
            var pnlTipo = this.BuildTipo();
            pnlBuscar.Controls.Add(pnlTipo);

            //AÑO
            var pnlAño = this.BuildAño();
            pnlBuscar.Controls.Add(pnlAño);
            
            
            //autor
            var pnlAutor = this.BuildAutor();
            pnlBuscar.Controls.Add(pnlAutor);

            
            var pnlBotones = this.BuildBotonesPanel();
            pnlBuscar.Controls.Add(pnlBotones);
            
            pnlBuscar.ResumeLayout(true);
            
        }

        private void BuildMenu()
        {
            
            this.mPpal = new MainMenu();

            this.mArchivo = new MenuItem("&Archivo");
            this.opVolver = new MenuItem("&Volver");

            this.opSalir = new MenuItem("&Salir");
            this.opSalir.Shortcut = Shortcut.CtrlQ;


            this.mArchivo.MenuItems.Add(this.opVolver);
            this.mArchivo.MenuItems.Add(this.opSalir);
            


            this.Menu = mPpal;
            
        }
        
        
        Panel BuildBotonesPanel()
        {
            var pnlBotones = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1,
                Dock = DockStyle.Top,
            };

            var btCierra = new Button()
            {
                Text = "&Cancelar",
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(69, 93, 117),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Silver,
            };

            var btBuscar = new Button()
            {
                Text = "&Buscar",
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(69, 93, 117),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Silver,
            };

            pnlBotones.Controls.Add(btBuscar);
            pnlBotones.Controls.Add(btCierra);

            this.AcceptButton = btBuscar;
            this.CancelButton = btCierra;

            pnlBotones.Controls.Add(btBuscar);
            pnlBotones.Controls.Add(btCierra);

            return pnlBotones;
        }
        
         Panel BuildMerito()
        {
            
            this.pnlMerito = new Panel()
            {
                Dock = DockStyle.Fill,
                MaximumSize = new Size(int.MaxValue, 30),
                Height = 30,
            };

            var lblMerito = new Label()
            {
                Text = "Datos del Merito",
                Dock = DockStyle.Top,
                Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopCenter,
            };

            
            pnlMerito.Controls.Add(lblMerito);

            return pnlMerito;

        }
         
         Panel BuildTipo()
         {
             this.pnlTipo = new Panel()
             {
                 Dock = DockStyle.Fill,
                 
             };

             var lblTipo = new Label()
             {
                 Text = "Tipo:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbTipo = new ComboBox()
             {
                 Dock = DockStyle.Fill,
                 DropDownStyle = ComboBoxStyle.DropDownList,
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };
             
             this.tbTipo.Items.AddRange( new [] {
                 "Libro", "Articulo", "Comunacion", "Vacio"
             } );
             this.tbTipo.Text = (string) this.tbTipo.Items[ 3 ];

             pnlTipo.MaximumSize = new Size(int.MaxValue, tbTipo.Height * 2);

             pnlTipo.Controls.Add(this.tbTipo);
             pnlTipo.Controls.Add(lblTipo);

             return pnlTipo;
         }
         
         Panel BuildAño()
         {

             this.pnlAño = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
             };

             var lblAño = new Label()
             {
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
                 Text = "Año:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };


             this.tbAño = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Text = "0",
                 Anchor = AnchorStyles.Bottom,
             };
             

             pnlAño.MaximumSize = new Size(int.MaxValue, tbAño.Height * 2);

             pnlAño.Controls.Add(this.tbAño);
             pnlAño.Controls.Add(lblAño);

             return pnlAño;
         }
         Panel BuildAutor()
         {
             this.pnlAutor = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlAño.Top + this.pnlAño.Height + 10),
             };

             var lblAutor = new Label()
             {
                 Location = new Point(Left, this.pnlAño.Top + this.pnlAño.Height + 10),
                 Text = "Autor:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbAutor = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };
             

             pnlAutor.MaximumSize = new Size(int.MaxValue, tbAutor.Height * 2);

             pnlAutor.Controls.Add(this.tbAutor);
             pnlAutor.Controls.Add(lblAutor);

             return pnlAutor;
         }
         
         
         public void Salir()
         {
             Console.WriteLine("Guardar y Salir");

             Application.Exit();
         }
         
         void OnQuit()
         {
             Application.Exit();
         }
        
         
         
        private ComboBox cbIssnMeritoList;

        private ComboBox tbTipo;
        private Panel pnlMerito;
        private Panel pnlTipo;
        private Panel pnlAño;
        private Panel pnlAutor;
        private Panel pnlBuscar;

        public string Tipo => this.tbTipo.Text;
        public string Año => this.tbAño.Text;
        public string Autor => this.tbAutor.Text;
        
        
        public StatusBar SbStatus;
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;
        public MenuItem opSalir;
        public MenuItem mBuscar;
        
        private TextBox tbAño;
        private TextBox tbAutor;
        
        
        private GestionMeritoCientifico Meritos;

    }
}