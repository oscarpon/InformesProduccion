using System;
using System.Drawing;
using System.Windows.Forms;
using proyectoIndividual.Core;

namespace proyectoIndividual.Ui.Dlg
{
    public class DlgInformeTodos: Form
    {
        public DlgInformeTodos()
        {
            this.Build();
            this.CenterToScreen();
        }

        public DlgInformeTodos(GestionMeritoCientifico meritos)
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
            
            this.pnlInforme = new TableLayoutPanel
            {
                Size = new Size(500,500),
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(23, 160, 219),
            };
            
            pnlInforme.SuspendLayout();
            this.Controls.Add(pnlInforme);
            
            var pnlMiembro = this.BuildAñoMerito();
            pnlInforme.Controls.Add(pnlMiembro);
            
            //DNI
            var pnlAño = this.BuildAño();
            pnlInforme.Controls.Add(pnlAño);


            var pnlBotones = this.BuildBotonesPanel();
            pnlInforme.Controls.Add(pnlBotones);
            
            pnlInforme.ResumeLayout(true);
            
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
            

            var btConsulta = new Button()
            {
                Text = "&Consulta",
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(69, 93, 117),
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.Silver,
            };

            pnlBotones.Controls.Add(btConsulta);
            

            this.AcceptButton = btConsulta;
            

            pnlBotones.Controls.Add(btConsulta);

            return pnlBotones;
        }
        
         Panel BuildAñoMerito()
        {
            
            this.pnlMiembro = new Panel()
            {
                Dock = DockStyle.Fill,
                MaximumSize = new Size(int.MaxValue, 30),
                Height = 30,
            };

            var lblMiembro = new Label()
            {
                Text = "Año del merito",
                Dock = DockStyle.Top,
                Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopCenter,
            };

            
            pnlMiembro.Controls.Add(lblMiembro);

            return pnlMiembro;

        }
         
         Panel BuildAño()
         {
             this.pnlAño = new Panel()
             {
                 Dock = DockStyle.Fill,
                 
             };

             var lblAño = new Label()
             {
                 Text = "AÑO:",
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
                 

                 if (this.tbAño.Text == "")
                 {

                     string mensaje = "El Año no puede estar vacío";
                     MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     this.tbAño.Focus();
                 }

                 //btAccept.Enabled = !invalid;
             };

             pnlAño.MaximumSize = new Size(int.MaxValue, tbAño.Height * 2);

             pnlAño.Controls.Add(this.tbAño);
             pnlAño.Controls.Add(lblAño);

             return pnlAño;
         }

         public void ClickConsulta()
         {
             Console.Write("lLEGO AQUÍ");
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
         
        private TextBox tbAño;
        private Panel pnlMiembro;
        private Panel pnlAño;
        private Panel pnlInforme;

        public int Año => (int) Convert.ToInt64(this.tbAño.Text);


        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVolver;
        public MenuItem opSalir;
        public MenuItem mBuscar;

        private GestionMeritoCientifico Meritos;
    }
}