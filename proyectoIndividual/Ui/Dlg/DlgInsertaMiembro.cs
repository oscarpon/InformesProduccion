
using System.Collections.Generic;
using proyectoIndividual.Core;
using System;

namespace proyectoIndividual.Ui.Dlg
{
    
    using System.Windows.Forms;
    using System.Drawing;
   
    public class DlgInsertaMiembro : Form
    {
        
        
        public DlgInsertaMiembro()
        {
            this.Build();
            this.CenterToScreen();
        }

        public DlgInsertaMiembro(GestionMiembros miembros)
        {
            
            this.Miembros = miembros;
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
            
            var pnlMiembro = this.BuildMiembro();
            pnlInserta.Controls.Add(pnlMiembro);
            
            //DNI
            var pnlDNI = this.BuildDNI();
            pnlInserta.Controls.Add(pnlDNI);
            
            //Nombre
            var pnlNombre = this.BuildNombre();
            pnlInserta.Controls.Add(pnlNombre);

            //Telefono
            var pnlTelef = this.BuildTelefono();
            pnlInserta.Controls.Add(pnlTelef);


            //Email
            var pnlEmail = this.BuildEmail();
            pnlInserta.Controls.Add(pnlEmail);


            //Direccion Postal
            var pnlDirPostal = this.BuildDirPostal();
            pnlInserta.Controls.Add(pnlDirPostal);

            
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
        
         Panel BuildMiembro()
        {
            
            this.pnlMiembro = new Panel()
            {
                Dock = DockStyle.Fill,
                MaximumSize = new Size(int.MaxValue, 30),
                Height = 30,
            };

            var lblMiembro = new Label()
            {
                Text = "Datos del Miembro",
                Dock = DockStyle.Top,
                Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopCenter,
            };

            
            pnlMiembro.Controls.Add(lblMiembro);

            return pnlMiembro;

        }
         
         Panel BuildDNI()
         {
             this.pnlDNI = new Panel()
             {
                 Dock = DockStyle.Fill,
                 
             };

             var lblDNI = new Label()
             {
                 Text = "DNI:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbDNI = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbDNI.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.DNI);
                 

                 invalid = invalid || this.tbDNI.Text == "";

                 if (invalid || this.tbDNI.Text == "")
                 {

                     string mensaje = "El DNI no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbDNI.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlDNI.MaximumSize = new Size(int.MaxValue, tbDNI.Height * 2);

             pnlDNI.Controls.Add(this.tbDNI);
             pnlDNI.Controls.Add(lblDNI);

             return pnlDNI;
         }
         
         Panel BuildNombre()
         {
             this.pnlNombre = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlDNI.Top + this.pnlDNI.Height + 10),
             };

             var lblNombre = new Label()
             {
                 Location = new Point(Left, this.pnlDNI.Top + this.pnlDNI.Height + 10),
                 Text = "Nombre:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbNombre = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbNombre.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Nombre);

                 invalid = invalid || this.tbNombre.Text == "";

                 if (invalid || this.tbNombre.Text == "")
                 {

                     string mensaje = "El nombre no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbNombre.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlNombre.MaximumSize = new Size(int.MaxValue, tbNombre.Height * 2);

             pnlNombre.Controls.Add(this.tbNombre);
             pnlNombre.Controls.Add(lblNombre);

             return pnlNombre;
         }
         
         Panel BuildTelefono()
         {
             this.pnlTelef = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlNombre.Top + this.pnlNombre.Height + 10),
             };

             var lblTelef = new Label()
             {
                 Location = new Point(Left, this.pnlNombre.Top + this.pnlNombre.Height + 10),
                 Text = "Teléfono:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.mtbTelef = new MaskedTextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
                 Mask = "000000000"
             };
             
             this.mtbTelef.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 /*bool invalid = string.IsNullOrEmpty(this.Telefono.ToString());

                 invalid = invalid || this.mtbTelef.Text == "";
*/
                 if (this.mtbTelef.Text == "")
                 {

                     string mensaje = "El teléfono no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.mtbTelef.Focus();
                 }

                 //btAccept.Enabled = !invalid;
             };
           
             pnlTelef.MaximumSize = new Size(int.MaxValue, mtbTelef.Height * 2);

             pnlTelef.Controls.Add(this.mtbTelef);
             pnlTelef.Controls.Add(lblTelef);

             return pnlTelef;
         }
         
         Panel BuildEmail()
         {

             this.pnlEmail = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlTelef.Top + this.pnlTelef.Height + 10),
             };

             var lblEmail = new Label()
             {
                 Location = new Point(Left, this.pnlTelef.Top + this.pnlTelef.Height + 10),
                 Text = "Email:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };


             this.tbEmail = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbEmail.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.Email);

                 invalid = invalid || this.tbEmail.Text == "";

                 if (invalid || this.tbEmail.Text == "")
                 {

                     string mensaje = "El email no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbEmail.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlEmail.MaximumSize = new Size(int.MaxValue, tbEmail.Height * 2);

             pnlEmail.Controls.Add(this.tbEmail);
             pnlEmail.Controls.Add(lblEmail);

             return pnlEmail;
         }
         
         Panel BuildDirPostal()
         {
             this.pnlDirPostal = new Panel()
             {
                 Dock = DockStyle.Fill,
                 Location = new Point(Left, this.pnlEmail.Top + this.pnlEmail.Height + 10),
             };

             var lblDirPostal = new Label()
             {
                 Location = new Point(Left, this.pnlEmail.Top + this.pnlEmail.Height + 10),
                 Text = "Dirección Postal:",
                 Dock = DockStyle.Left,
                 ForeColor = Color.White,
                 Width = 150,
                 TextAlign = ContentAlignment.TopRight,
             };

             this.tbDirPostal = new TextBox()
             {
                 Left = 0,
                 Width = 250,
                 Anchor = AnchorStyles.Bottom,
             };

             this.tbDirPostal.Validating += (sender, cancelArgs) =>
             {
                 var btAccept = (Button)this.AcceptButton;
                 bool invalid = string.IsNullOrEmpty(this.DirPostal);

                 invalid = invalid || this.tbDirPostal.Text == "";

                 if (invalid || this.tbDirPostal.Text == "")
                 {

                     string mensaje = "La dirección postal no puede estar vacía";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbDirPostal.Focus();
                 }

                 btAccept.Enabled = !invalid;
             };

             pnlDirPostal.MaximumSize = new Size(int.MaxValue, tbDirPostal.Height * 2);

             pnlDirPostal.Controls.Add(this.tbDirPostal);
             pnlDirPostal.Controls.Add(lblDirPostal);

             return pnlDirPostal;
         }

         
         
         
         public void Salir()
         {
             Console.WriteLine("Guardar y Salir");
            // this.Miembros.GuardarXml();
         
             Application.Exit();
         }
         
         void OnQuit()
         {
             Application.Exit();
         }
        
         
         
        private ComboBox cbDniMiembroList;
        
        private TextBox tbDNI;
        private Panel pnlMiembro;
        private Panel pnlDNI;
        private Panel pnlNombre;
        private Panel pnlEmail;
        private Panel pnlTelef;
        private Panel pnlDirPostal;
        private Panel pnlInserta;
        private Button btnAddMiembro;
        
        public string DNI => this.tbDNI.Text;
        public string Nombre => this.tbNombre.Text;

        public long Telefono => Convert.ToInt64(this.mtbTelef.Text);
        public string Email => this.tbEmail.Text;

        public string DirPostal => this.tbDirPostal.Text;

        
        public StatusBar SbStatus;
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;
        public MenuItem opSalir;
        public MenuItem mBuscar;
        
        private TextBox tbNombre;
        private TextBox tbEmail;
        private TextBox tbDirPostal;

        private MaskedTextBox mtbTelef;
        
        private GestionMiembros Miembros;

    }
}