using System;
using System.Windows.Forms;
 
using proyectoIndividual.Core;
using System.Drawing;

namespace proyectoIndividual.Ui.Dlg
{
    public class DlgModificaPublicacion : Form
    {
        public DlgModificaPublicacion(Publicacion publicacion)
        {
            this.publicacion = publicacion;
            this.Build();
            this.CenterToScreen();
            this.gestionPublicaciones = new GestionPublicacion();
            
            this.MinimumSize = new Size(500, 500);
            this.MaximumSize = new Size(500, 500);
            this.MaximizeBox = false;
           
            
            var DCC = new DlgConsultaPublicacion(gestionPublicaciones);
            this.opSalir.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; DCC.Salir(); };
            this.opVolver.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;
        }
        
         void Build()
        {
            
            this.BuildMenu();

            this.SuspendLayout();

            this.pnlInserta = new TableLayoutPanel
            {
                Size = new Size(500, 500), //Size(ancho, alto)
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(23, 160, 219),
            };
            pnlInserta.SuspendLayout();
            this.Controls.Add(pnlInserta);
            
            var pnlPublicacion = this.BuildPublicacion();
            pnlInserta.Controls.Add(pnlPublicacion);
            
            //Tipo
            var pnlTipo = this.BuildTipo();
            pnlInserta.Controls.Add(pnlTipo);
            
            //Issn
            var pnlIssn = this.BuildIssn();
            pnlInserta.Controls.Add(pnlIssn);


            //Titulo
            var pnlTitulo = this.BuildTitulo();
            pnlInserta.Controls.Add(pnlTitulo);


            //Editorial
            var pnlEditorial = this.BuildEditorial();
            pnlInserta.Controls.Add(pnlEditorial);
            
            
            //RegEditorial
            var pnlRegEditorial = this.BuildRegEditorial();
            pnlInserta.Controls.Add(pnlRegEditorial);
            
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
             this.mPpal.MenuItems.Add(this.mArchivo);
             

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
                 Text = "Datos de la Publicacion",
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
                 "Libro", "Revistas", "Congresos"
             } );
             this.tbTipo.Text = (string) this.tbTipo.Items[ 0 ];

             pnlTipo.MaximumSize = new Size(int.MaxValue, tbTipo.Height * 2);

             pnlTipo.Controls.Add(this.tbTipo);
             pnlTipo.Controls.Add(lblTipo);

             return pnlTipo;
         }

          Panel BuildIssn()
         {
             this.pnlIssn = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
             };

             var lblIssn = new Label()
             {
                 Location = new Point(Left, this.pnlTipo.Top + this.pnlTipo.Height + 10),
                 Text = "Issn:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.mtbIssn = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
                 Text = this.publicacion.IssnP.ToString(),
             };

             this.mtbIssn.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 if (this.mtbIssn.Text == "")
                 {

                     string mensaje = "El ISSN no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.mtbIssn.Focus();
                 }

                 //btAccept.Enabled = !invalid;
             };

             pnlIssn.MaximumSize = new Size(int.MaxValue, mtbIssn.Height * 2);

             pnlIssn.Controls.Add(this.mtbIssn);
             pnlIssn.Controls.Add(lblIssn);

             return pnlIssn;
         }
         
         Panel BuildTitulo()
         {

             this.pnlTitulo = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlIssn.Top + this.pnlIssn.Height + 10),
             };

             var lblTitulo = new Label()
             {
                 Location = new Point(Left, this.pnlIssn.Top + this.pnlIssn.Height + 10),
                 Text = "Titulo:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };


             this.tbTitulo = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Text = this.publicacion.TituloP.ToString(),
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbTitulo.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.publicacion.ToString());

                 invalid = invalid || this.tbTitulo.Text == "";

                 if (invalid || this.tbTitulo.Text == "")
                 {

                     string mensaje = "El Titulo no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbTitulo.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlTitulo.MaximumSize = new Size(int.MaxValue, tbTitulo.Height * 2);

             pnlTitulo.Controls.Add(this.tbTitulo);
             pnlTitulo.Controls.Add(lblTitulo);

             return pnlTitulo;
         }
         
         Panel BuildEditorial()
         {
             this.pnlEditorial = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTitulo.Top + this.pnlTitulo.Height + 10),
             };

             var lblEditorial = new Label()
             {
                 Location = new Point(Left, this.pnlTitulo.Top + this.pnlTitulo.Height + 10),
                 Text = "Editorial:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbEditorial = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Text = this.publicacion.EditorialP.ToString(),
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbEditorial.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Editorial.ToString());

                 invalid = invalid || this.tbEditorial.Text == "";

                 if (invalid || this.tbEditorial.Text == "")
                 {

                     string mensaje = "la editorial no puede estar vacía";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbEditorial.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlEditorial.MaximumSize = new Size(int.MaxValue, tbEditorial.Height * 2);

             pnlEditorial.Controls.Add(this.tbEditorial);
             pnlEditorial.Controls.Add(lblEditorial);

             return pnlEditorial;
         }
         
         Panel BuildRegEditorial()
         {
             this.pnlRegEditorial = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlEditorial.Top + this.pnlEditorial.Height + 10),
             };

             var lblRegEditorial = new Label()
             {
                 Location = new Point(Left, this.pnlEditorial.Top + this.pnlEditorial.Height + 10),
                 Text = "Registro editorial o ciudad:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbRegEditorial = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Text = this.publicacion.RegEditorialP1.ToString(),
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbRegEditorial.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.RegEditorial.ToString());

                 invalid = invalid || this.tbRegEditorial.Text == "";

                 if (invalid || this.tbRegEditorial.Text == "")
                 {

                     string mensaje = " no puede estar vacia";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbRegEditorial.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlRegEditorial.MaximumSize = new Size(int.MaxValue, tbRegEditorial.Height * 2);

             pnlRegEditorial.Controls.Add(this.tbRegEditorial);
             pnlRegEditorial.Controls.Add(lblRegEditorial);

             return pnlRegEditorial;
         }
         
         
         private Publicacion publicacion;

         private ComboBox tbTipo;


         private Panel pnlPublicacion;
  
         private Panel pnlTipo;

         private Panel pnlInserta;

         public string Tipo => this.tbTipo.Text;

         public string Issn => this.mtbIssn.Text;
         
         public string Titulo => this.tbTitulo.Text;

         public string Editorial => this.tbEditorial.Text;

         public string RegEditorial => this.tbRegEditorial.Text;
         

        
         private MainMenu mPpal;
         public MenuItem mArchivo;
         public MenuItem opVolver;
         public MenuItem opSalir;
         
         private Panel pnlTitulo;
         private TextBox tbTitulo;
         private Panel pnlIssn;
         private Panel pnlRegEditorial;
         private Panel pnlEditorial;

         private TextBox tbRegEditorial;
         private TextBox mtbIssn;
         private TextBox tbEditorial;

         public string Mask { get; set; }

         private GestionPublicacion gestionPublicaciones;
        
        
        
        
    }
}