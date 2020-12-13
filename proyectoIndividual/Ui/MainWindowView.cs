using System.Windows.Forms.VisualStyles;

namespace proyectoIndividual
{
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;

    public class MainWindowView : WForms.Form
    {
        
        public MainWindowView()
        {
            this.BuildGUI();
            this.CenterToScreen();
        }
        
        private void BuildGUI()
        {
            //this.BuildStatus();
            this.BuildMenu();

            this.SuspendLayout();
            
            this.pnlPanel = new WForms.Panel()
            {
                Size = new Draw.Size(442, 440), 
                Dock = WForms.DockStyle.Fill,
                BackColor = Draw.Color.FromArgb(23, 160, 219),
            };


            this.pnlPanel.SuspendLayout();
            this.Controls.Add(pnlPanel);
            

            this.pnlPanel.ResumeLayout(false);

            this.MinimumSize = new Draw.Size(600, 400);
            this.MaximumSize = new Draw.Size(600, 400);
            this.MaximizeBox = false;
            this.Text = "Gestión de Meritos Cientificos";

            this.ResumeLayout(false);
        }

        private void BuildMenu()
        {
            this.mPpal = new WForms.MainMenu();
            
            this.opGuardar = new WForms.MenuItem("&Guardar");
            this.opSalir = new WForms.MenuItem("&Salir");
            this.opSalir.Shortcut = WForms.Shortcut.CtrlQ;
            

            this.mMerito = new WForms.MenuItem("&Merito");
            this.opInsertarMerito = new WForms.MenuItem("&Insertar");
            this.opConsultaMerito = new WForms.MenuItem("&Consulta");
            this.mInforme = new WForms.MenuItem("&Informe");
            this.opInfAnual = new WForms.MenuItem("&Anual");
            this.opInfMensual = new WForms.MenuItem("&Mensual");
            this.opTodos = new WForms.MenuItem("&Todos");

            this.mInforme.MenuItems.Add(this.opInfAnual);
            this.mInforme.MenuItems.Add(this.opInfMensual);
            this.mInforme.MenuItems.Add(this.opTodos);

            this.mPpal.MenuItems.Add(this.mInforme);
            
            
            this.mMerito.MenuItems.Add(this.opInsertarMerito);
            this.mMerito.MenuItems.Add(this.opConsultaMerito);
            this.mMerito.MenuItems.Add(this.mInforme);
            
          
            this.mPpal.MenuItems.Add(this.mMerito);
            
            this.mMiembro = new WForms.MenuItem("&Miembro");
            this.opInsertarMiembro = new WForms.MenuItem("&Insertar");
            this.opConsultaMiembro = new WForms.MenuItem("&Consulta");
            
            this.mMiembro.MenuItems.Add(this.opInsertarMiembro);
            this.mMiembro.MenuItems.Add(this.opConsultaMiembro);
            
          
            this.mPpal.MenuItems.Add(this.mMiembro);
            

            this.Menu = mPpal;


        }
     
        public WForms.MenuItem mView { get; private set; }
        
        public WForms.Button btnAddMerito;
        public WForms.Button btnEditarMerito;
        public WForms.Button btnEliminarMerito;
        
        public WForms.MenuItem opConsultaMerito;
        
        public WForms.MenuItem mMerito;
        private WForms.MainMenu mPpal;
        public WForms.MenuItem opGuardar;
        public WForms.MenuItem opInsertarMerito;
        public WForms.MenuItem opSalir;
        public WForms.MenuItem mMiembro;
        public WForms.MenuItem opInsertarMiembro;
        public WForms.MenuItem opConsultaMiembro;
        public WForms.MenuItem mInforme;
        public WForms.MenuItem opInfAnual;
        public WForms.MenuItem opInfMensual;
        public WForms.MenuItem opTodos;
        
        
        
        private WForms.Panel pnlPanel;
    }

}