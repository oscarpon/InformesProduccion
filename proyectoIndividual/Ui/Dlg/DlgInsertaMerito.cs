using System.Collections.Generic;
using proyectoIndividual.Core;
using System;

namespace proyectoIndividual.Ui.Dlg
{
    
    using System.Windows.Forms;
    using System.Drawing;
   
    public class DlgInsertaMerito : Form
    {
        
        
        public DlgInsertaMerito()
        {
            this.Build();
            this.CenterToScreen();
        }

        public DlgInsertaMerito(GestionMeritoCientifico meritos)
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
            
            this.pnlInserta = new TableLayoutPanel
            {
                Size = new Size(500,500),
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(23, 160, 219),
            };
            
            pnlInserta.SuspendLayout();
            this.Controls.Add(pnlInserta);
            
            var pnlMerito = this.BuildMerito();
            pnlInserta.Controls.Add(pnlMerito);

            //Tipo
            var pnlTipo = this.BuildTipo();
            pnlInserta.Controls.Add(pnlTipo);
            
            //DOI
            var pnlDoi = this.BuildDoi();
            //pnlInserta.Controls.Add(pnlDoi);

            //ISSN
            var pnlIssn = this.BuildIssn();
            pnlInserta.Controls.Add(pnlIssn);


            //AÑO
            var pnlAño = this.BuildAño();
            pnlInserta.Controls.Add(pnlAño);


            //pagIn
            var pnlpagIn = this.BuildPagIn();
            pnlInserta.Controls.Add(pnlpagIn);
            
            //pagFin
            var pnlPagFin = this.BuildPagFin();
            pnlInserta.Controls.Add(pnlPagFin);
            
            //autor
            var pnlAutor = this.BuildAutor();
            pnlInserta.Controls.Add(pnlAutor);

            
            var pnlBotones = this.BuildBotonesPanel();
            pnlInserta.Controls.Add(pnlBotones);
            
            pnlInserta.ResumeLayout(true);
            
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

            var btGuarda = new Button()
            {
                Text = "&Guardar",
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(69, 93, 117),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Silver,
            };

            pnlBotones.Controls.Add(btGuarda);
            pnlBotones.Controls.Add(btCierra);

            this.AcceptButton = btGuarda;
            this.CancelButton = btCierra;

            pnlBotones.Controls.Add(btGuarda);
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
                 "Libro", "Articulo", "Comunacion"
             } );
             this.tbTipo.Text = (string) this.tbTipo.Items[ 0 ];

             pnlTipo.MaximumSize = new Size(int.MaxValue, tbTipo.Height * 2);

             pnlTipo.Controls.Add(this.tbTipo);
             pnlTipo.Controls.Add(lblTipo);

             return pnlTipo;
         }
         
         Panel BuildDoi()
         {
             this.pnlDoi = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
             };

             var lblDoi = new Label()
             {
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
                 Text = "Doi:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbDoi = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbDoi.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Doi);

                 invalid = invalid || this.tbDoi.Text == "";

                 if (invalid || this.tbDoi.Text == "")
                 {

                     string mensaje = "El Doi no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbDoi.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlDoi.MaximumSize = new Size(int.MaxValue, tbDoi.Height * 2);

             pnlDoi.Controls.Add(this.tbDoi);
             pnlDoi.Controls.Add(lblDoi);

             return pnlDoi;
         }
         
         Panel BuildIssn()
         {
             this.pnlIssn = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlDoi.Top + this.pnlDoi.Height + 10),
             };

             var lblIssn = new Label()
             {
                 Location = new Point(Left, this.pnlDoi.Top + this.pnlDoi.Height + 10),
                 Text = "ISSN:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbIssn = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbIssn.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Issn);

                 invalid = invalid || this.tbIssn.Text == "";

                 if (invalid || this.tbIssn.Text == "")
                 {

                     string mensaje = "El Issn no puede estar vacía";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbIssn.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlIssn.MaximumSize = new Size(int.MaxValue, tbIssn.Height * 2);

             pnlIssn.Controls.Add(this.tbIssn);
             pnlIssn.Controls.Add(lblIssn);

             return pnlIssn;
         }
         
         Panel BuildAño()
         {

             this.pnlAño = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlIssn.Top + this.pnlIssn.Height + 10),
             };

             var lblAño = new Label()
             {
                 Location = new Point(Left, this.pnlIssn.Top + this.pnlIssn.Height + 10),
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
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbAño.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Año);

                 invalid = invalid || this.tbAño.Text == "";

                 if (invalid || this.tbAño.Text == "")
                 {

                     string mensaje = "El año no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbAño.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlAño.MaximumSize = new Size(int.MaxValue, tbAño.Height * 2);

             pnlAño.Controls.Add(this.tbAño);
             pnlAño.Controls.Add(lblAño);

             return pnlAño;
         }
         
         Panel BuildPagIn()
         {
             this.pnlPagIn = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlAño.Top + this.pnlAño.Height + 10),
             };

             var lblPagIn = new Label()
             {
                 Location = new Point(Left, this.pnlAño.Top + this.pnlAño.Height + 10),
                 Text = "Pagina de inicio:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbPagIn = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbPagIn.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.PagIn);

                 invalid = invalid || this.tbPagIn.Text == "";

                 if (invalid || this.tbPagIn.Text == "")
                 {

                     string mensaje = "La dirección postal no puede estar vacía";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbPagIn.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlPagIn.MaximumSize = new Size(int.MaxValue, tbPagIn.Height * 2);

             pnlPagIn.Controls.Add(this.tbPagIn);
             pnlPagIn.Controls.Add(lblPagIn);

             return pnlPagIn;
         }
         
         Panel BuildPagFin()
         {
             this.pnlPagFin = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlPagIn.Top + this.pnlPagIn.Height + 10),
             };

             var lblPagFin = new Label()
             {
                 Location = new Point(Left, this.pnlPagIn.Top + this.pnlPagIn.Height + 10),
                 Text = "Pagina de final:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbPagFin = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbPagFin.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.PagFin);

                 invalid = invalid || this.tbPagFin.Text == "";

                 if (invalid || this.tbPagFin.Text == "")
                 {

                     string mensaje = "La pagina de final no puede estar vacia";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbPagFin.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlPagFin.MaximumSize = new Size(int.MaxValue, tbPagFin.Height * 2);

             pnlPagFin.Controls.Add(this.tbPagFin);
             pnlPagFin.Controls.Add(lblPagFin);

             return pnlPagFin;
         }

         
         
         Panel BuildAutor()
         {
             this.pnlAutor = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlPagFin.Top + this.pnlPagFin.Height + 10),
             };

             var lblAutor = new Label()
             {
                 Location = new Point(Left, this.pnlPagFin.Top + this.pnlPagFin.Height + 10),
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

             this.tbAutor.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Autor);

                 invalid = invalid || this.tbAutor.Text == "";

                 if (invalid || this.tbAutor.Text == "")
                 {

                     string mensaje = "El autor no puede estar vacía";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbAutor.Focus();
                 }

                 btAccept.Enabled = !invalid;
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
        private Panel pnlDoi;
        private Panel pnlAño;
        private Panel pnlIssn;
        private Panel pnlPagIn;
        private Panel pnlAutor;
        private Panel pnlPagFin;
        private Panel pnlInserta;
        private Button btnAddMerito;
        
        public string Tipo => this.tbTipo.Text;
        public string Doi => this.tbDoi.Text;

        public string Issn => this.tbIssn.Text;
        public string Año => this.tbAño.Text;

        public string PagIn => this.tbPagIn.Text;
        
        public string Autor => this.tbAutor.Text;
        
        public string PagFin => this.tbPagFin.Text;

        
        public StatusBar SbStatus;
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;
        public MenuItem opSalir;
        public MenuItem mBuscar;
        
        private TextBox tbDoi;
        private TextBox tbAño;
        private TextBox tbPagIn;
        private TextBox tbAutor;
        private TextBox tbPagFin;

        private TextBox tbIssn;
        
        private GestionMeritoCientifico Meritos;

    }
}