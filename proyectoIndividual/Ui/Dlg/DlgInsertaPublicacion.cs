using System.Collections.Generic;
using proyectoIndividual.Core;
using System;

namespace proyectoIndividual.Ui.Dlg
{
    
    using System.Windows.Forms;
    using System.Drawing;
   
    public class DlgInsertaPublicacion : Form
    {
        
        
        public DlgInsertaPublicacion()
        {
            this.Build();
            this.CenterToScreen();
        }

        public DlgInsertaPublicacion(GestionPublicacion publicaciones)
        {
            
            this.Publicaciones = publicaciones;
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
            //(string tipo, string issnP, string tituloP, string editorialP, string regEditorialP)
            var pnlPublicacion = this.BuildPublicacion();
            pnlInserta.Controls.Add(pnlPublicacion);

            //Tipo
            var pnlTipo = this.BuildTipo();
            pnlInserta.Controls.Add(pnlTipo);
            
            //ISSN
            var pnlIssnP = this.BuildIssn();
            pnlInserta.Controls.Add(pnlIssnP);
            
            //Titulo
            var pnlTituloP = this.BuildTituloP();
            pnlInserta.Controls.Add(pnlTituloP);


            //Editorial
            var pnlEditorialP = this.BuildEditorialP();
            pnlInserta.Controls.Add(pnlEditorialP);

            
            //Registro Editorial
            var pnlRegEditorialP = this.BuildRegEditorialP();
            pnlInserta.Controls.Add(pnlRegEditorialP);

            
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
        
         Panel BuildPublicacion()
        {
            
            this.pnlPublicacion = new Panel()
            {
                Dock = DockStyle.Fill,
                MaximumSize = new Size(int.MaxValue, 30),
                Height = 30,
            };

            var lblPublicacion = new Label()
            {
                Text = "Datos de la publicación",
                Dock = DockStyle.Top,
                Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopCenter,
            };

            
            pnlPublicacion.Controls.Add(lblPublicacion);

            return pnlPublicacion;

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
                 "Libro", "Revista", "Congreso"
             } );
             this.tbTipo.Text = (string) this.tbTipo.Items[ 0 ];

             pnlTipo.MaximumSize = new Size(int.MaxValue, tbTipo.Height * 2);

             pnlTipo.Controls.Add(this.tbTipo);
             pnlTipo.Controls.Add(lblTipo);

             return pnlTipo;
         }
         Panel BuildIssn()
         {
             this.pnlIssnP = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
             };

             var lblIssn = new Label()
             {
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
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
                 bool invalid = string.IsNullOrEmpty(this.IssnP);

                 invalid = invalid || this.tbIssn.Text == "";

                 if (invalid || this.tbIssn.Text == "")
                 {

                     string mensaje = "El Issn no puede estar vacía";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbIssn.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlIssnP.MaximumSize = new Size(int.MaxValue, tbIssn.Height * 2);

             pnlIssnP.Controls.Add(this.tbIssn);
             pnlIssnP.Controls.Add(lblIssn);

             return pnlIssnP;
         }
         
         Panel BuildTituloP()
         {
             this.pnlTituloP = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlIssnP.Top + this.pnlIssnP.Height + 10),
             };

             var lblTituloP = new Label()
             {
                 Location = new Point(Left, this.pnlIssnP.Top + this.pnlIssnP.Height + 10),
                 Text = "Titulo:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbTituloP = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbTituloP.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.TituloP);

                 invalid = invalid || this.tbTituloP.Text == "";

                 if (invalid || this.tbTituloP.Text == "")
                 {

                     string mensaje = "El título no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbTituloP.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlTituloP.MaximumSize = new Size(int.MaxValue, tbTituloP.Height * 2);

             pnlTituloP.Controls.Add(this.tbTituloP);
             pnlTituloP.Controls.Add(lblTituloP);

             return pnlTituloP;
         }
         
        
         
         Panel BuildEditorialP()
         {

             this.pnlEditorialP = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTituloP.Top + this.pnlTituloP.Height + 10),
             };

             var lblEditorialP = new Label()
             {
                 Location = new Point(Left, this.pnlTituloP.Top + this.pnlTituloP.Height + 10),
                 Text = "Editorial:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };


             this.tbEditorialP = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbEditorialP.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.EditorialP);

                 invalid = invalid || this.tbEditorialP.Text == "";

                 if (invalid || this.tbEditorialP.Text == "")
                 {

                     string mensaje = "La editorial no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbEditorialP.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlEditorialP.MaximumSize = new Size(int.MaxValue, tbEditorialP.Height * 2);

             pnlEditorialP.Controls.Add(this.tbEditorialP);
             pnlEditorialP.Controls.Add(lblEditorialP);

             return pnlEditorialP;
         }
         
         Panel BuildRegEditorialP()
         {
             this.pnlRegEditorialP = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlEditorialP.Top + this.pnlEditorialP.Height + 10),
             };

             var lblRegEditorialP = new Label()
             {
                 Location = new Point(Left, this.pnlEditorialP.Top + this.pnlEditorialP.Height + 10),
                 Text = "Registro Editorial:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbRegEditorialP= new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbRegEditorialP.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.RegEditorialP);

                 invalid = invalid || this.tbRegEditorialP.Text == "";

                 if (invalid || this.tbRegEditorialP.Text == "")
                 {

                     string mensaje = "El registro de editorial no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbRegEditorialP.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlRegEditorialP.MaximumSize = new Size(int.MaxValue, tbRegEditorialP.Height * 2);

             pnlRegEditorialP.Controls.Add(this.tbRegEditorialP);
             pnlRegEditorialP.Controls.Add(lblRegEditorialP);

             return pnlRegEditorialP;
         }
         
         
         
         
         public void Salir()
         {
             Console.WriteLine("Guardar y Salir");
             this.Publicaciones.GuardarXml();
             Application.Exit();
         }
         
         void OnQuit()
         {
             Application.Exit();
         }
        
         
         
    
        private Panel pnlPublicacion;
        private ComboBox tbTipo;
        private Panel pnlTipo;
        private Panel pnlIssnP;
        private Panel pnlTituloP;
        private Panel pnlEditorialP;
        private Panel pnlRegEditorialP;
        private Panel pnlInserta;
        
        private Button btnAddPublicacion;
        
        
        
        public string Tipo => this.tbTipo.Text;
        public string IssnP => this.tbIssn.Text;
        public string TituloP => this.tbTituloP.Text;
        public string EditorialP => this.tbEditorialP.Text;
        public string RegEditorialP => this.tbRegEditorialP.Text;
   

        
        
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;
        public MenuItem opSalir;
        public MenuItem mBuscar;
        
        
        private TextBox tbIssnP;
        private TextBox tbTituloP;
        private TextBox tbEditorialP;
        private TextBox tbRegEditorialP;
        private TextBox tbIssn;
        
        private GestionPublicacion Publicaciones;

    }
}