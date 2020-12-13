using System.Windows.Forms;
using proyectoIndividual.Core;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace proyectoIndividual.Ui.Dlg
{
    public class DlgConsultaMiembro : Form
    {
        
        public DlgConsultaMiembro(GestionMiembros Miembros)
        {
            this.mainWindowCore = new MainWindowCore();
            this.Miembros = Miembros;
            this.BuildGUI();
            this.CenterToScreen();
            


            
            this.GrdLista.Click += (sender, e) => ClickLista();
            this.opGuardar.Click += (sender, e) => this.Guardar();
            this.opVaciarMiembros.Click += (sender, e) => this.VaciarListaDeMiembros();
            this.opSalir.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Salir(); };
            this.opVolver.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;
        }
        
        private void BuildGUI()
        {
            this.BuildStatus();
            this.BuildMenu();

            this.SuspendLayout();
            this.pnlPpal = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(49, 66, 82),

            };

            this.pnlPpal.SuspendLayout();
            this.Controls.Add(this.pnlPpal);
            this.pnlPpal.Controls.Add(this.BuildPanelLista());
            this.pnlPpal.Controls.Add(this.BuildPanelDetalle());
            this.pnlPpal.ResumeLayout(false);

            this.MinimumSize = new Size(1000, 400);
            this.Resize += (obj, e) => this.ResizeWindow();
            this.Text = "Gestion de Miembros - Consulta Miembros";

            this.Actualiza();
            this.ResumeLayout(true);
            this.ResizeWindow();
        }

        private void BuildMenu()
        {
            this.mPpal = new MainMenu();
            this.mArchivo = new MenuItem("&Archivo");
            this.opGuardar = new MenuItem("&Guardar");
            this.opVaciarMiembros = new MenuItem("&Vaciar Miembros");
            this.opSalir = new MenuItem("&Salir");
            this.opVolver = new MenuItem("&Volver");
            this.opSalir.Shortcut = Shortcut.CtrlQ;
           
            
            this.mArchivo.MenuItems.Add(this.opVolver);
            this.mArchivo.MenuItems.Add(this.opGuardar);
            this.mArchivo.MenuItems.Add(this.opVaciarMiembros);
            this.mArchivo.MenuItems.Add(this.opSalir);
            

            this.mPpal.MenuItems.Add(this.mArchivo);
           

            this.Menu = mPpal;
        }
        



        private Panel BuildPanelDetalle()
        {
            var pnlDetalle = new Panel {
                Dock = DockStyle.Bottom,
                Height = 110

            };
            pnlDetalle.SuspendLayout();

            this.edDetalle = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font(FontFamily.GenericMonospace, 10),
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(104, 168, 216),
            };

            
            pnlDetalle.Controls.Add(this.edDetalle);
            pnlDetalle.ResumeLayout(false);
            return pnlDetalle;
        }
        
        private void BuildStatus()
        {
            this.SbStatus = new StatusBar();
            this.SbStatus.Dock = DockStyle.Bottom;
            this.Controls.Add(this.SbStatus);
        }
        
         private Panel BuildPanelLista()
        {
            var pnlLista = new Panel
            {
                Dock = DockStyle.Fill
            };
            
            pnlLista.SuspendLayout();
            pnlLista.Dock = DockStyle.Fill;

            // Crear gridview
            this.GrdLista = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                //BackColor = Color.FromArgb(113, 162, 208),
            };

            this.GrdLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.GrdLista.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 160, 219);
            this.GrdLista.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GrdLista.ColumnHeadersHeight = 30;
            this.GrdLista.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);

            //texto
            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();
            var textCellTemplate4 = new DataGridViewTextBoxCell();
            var textCellTemplate5 = new DataGridViewTextBoxCell();
            

            //botones
            var buttonCellTemplate6 = new DataGridViewButtonCell();
            var buttonCellTemplate7 = new DataGridViewButtonCell();
            var buttonCellTemplate8 = new DataGridViewButtonCell();


            //texto
            Color colorCeldasDatos = Color.PapayaWhip;

            textCellTemplate0.Style.BackColor = Color.FromArgb(104, 168, 216);
            textCellTemplate0.Style.ForeColor = Color.Black;

            textCellTemplate1.Style.BackColor = Color.FromArgb(104, 168, 216);
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            textCellTemplate2.Style.BackColor = colorCeldasDatos;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            textCellTemplate3.Style.BackColor = colorCeldasDatos;
            textCellTemplate3.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            textCellTemplate4.Style.BackColor = colorCeldasDatos;
            textCellTemplate4.Style.ForeColor = Color.Black;
            textCellTemplate4.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            textCellTemplate5.Style.BackColor = colorCeldasDatos;
            textCellTemplate5.Style.ForeColor = Color.Black;
            textCellTemplate5.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            //botones
            buttonCellTemplate6.Style.BackColor = Color.FromArgb(80, 80, 80);

            buttonCellTemplate6.Style.ForeColor = Color.White;
            buttonCellTemplate6.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            buttonCellTemplate6.Style.Font = new Font(FontFamily.GenericMonospace, 11, FontStyle.Regular);

            buttonCellTemplate7.Style.BackColor = Color.FromArgb(219, 43, 43);
            buttonCellTemplate7.Style.ForeColor = Color.White;
            buttonCellTemplate7.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            buttonCellTemplate7.Style.Font = new Font(FontFamily.GenericMonospace, 11, FontStyle.Regular);

            buttonCellTemplate8.Style.BackColor = colorCeldasDatos;
            buttonCellTemplate8.Style.ForeColor = Color.Black;
            buttonCellTemplate8.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            buttonCellTemplate8.Style.Font = new Font(FontFamily.GenericMonospace, 11, FontStyle.Regular);



            var columna0 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                Width = 5,
                ReadOnly = true
            };

            var columna1 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "DNI",
                Width = 20,
                ReadOnly = true
            };

            var columna3 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate2,
                HeaderText = "Email",
                Width = 20,
                ReadOnly = true
            };

            var columna2 = new DataGridViewTextBoxColumn  
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate3,
                HeaderText = "Nombre",
                Width = 15,
                ReadOnly = true
            };

            var columna4 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "Teléfono",
                Width = 15,
                ReadOnly = true
            };
            

            
            var columna5 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "Dirección",
                Width = 15,
                ReadOnly = true
            };

            

            var columna6 = new DataGridViewButtonColumn  
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = buttonCellTemplate6,
                HeaderText = "Editar",
                Width = 20,
                ReadOnly = true,
            };

            var columna7 = new DataGridViewButtonColumn  
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = buttonCellTemplate7,
                HeaderText = "Eliminar",
                Width = 20,
                ReadOnly = true,
            };
            

            
            this.GrdLista.Columns.AddRange(new DataGridViewColumn[] {
                columna0, columna1, columna2, columna3, columna4,columna5,columna6,columna7
            });
        
            this.GrdLista.SelectionChanged += (sender, e) => this.FilaSeleccionada();

            pnlLista.Controls.Add(this.GrdLista);
            pnlLista.ResumeLayout(false);
            return pnlLista;
        }
         
         private void FilaSeleccionada()
         {

             try
             {
                 
                 int fila = System.Math.Max(0, this.GrdLista.CurrentRow.Index);
                 int posicion = this.GrdLista.CurrentCellAddress.X;

                
                 if (posicion < 5 && this.Miembros.List.Count > fila)
                 {
                     this.edDetalle.Text = this.Miembros.List[fila].ToString();
                     this.edDetalle.SelectionStart = this.edDetalle.Text.Length;
                     this.edDetalle.SelectionLength = 0;
                 }
                 else
                 {
                     this.edDetalle.Clear();
                     
                 }
             }
             catch(Exception)
             {
                 
                 this.edDetalle.Clear();
                 
             }
            

             return;
         }
         
         private void ResizeWindow()
         {
             // Tomar las nuevas medidas
             int width = this.pnlPpal.ClientRectangle.Width;

             // Redimensionar la tabla
             this.GrdLista.Width = width;
             this.GrdLista.Height = 15;



             this.GrdLista.Columns[0].Width =
                 (int)System.Math.Floor(width * .03); // Número de miembro
             this.GrdLista.Columns[1].Width =
                 (int)System.Math.Floor(width * .10); // DNI
             this.GrdLista.Columns[2].Width =
                 (int)System.Math.Floor(width * .20); // Email
             this.GrdLista.Columns[3].Width =
                 (int)System.Math.Floor(width * .14); // Nombre
             this.GrdLista.Columns[4].Width =
                 (int)System.Math.Floor(width * .14); // Telefono
             this.GrdLista.Columns[5].Width =
                 (int)System.Math.Floor(width * .12); // Calle
             this.GrdLista.Columns[6].Width =
                 (int)System.Math.Floor(width * .12); // Editar
             this.GrdLista.Columns[7].Width =
                 (int)System.Math.Floor(width * .15); // Eliminar
         }
         
     
         void Actualiza()
         {
             Console.WriteLine("Aquí es cuando se actualiza la lista");

             // var consultaGestion = new DlgConsultaMiembro();


             int numElementos = this.Miembros.List.Count;
             Console.WriteLine("Número de miembros: " + numElementos);

             this.SbStatus.Text = ("Número de miembros actuales: " + numElementos);

             for (int i = 0; i < numElementos; i++)
             {
                 if (this.GrdLista.Rows.Count <= i)
                 {
                     this.GrdLista.Rows.Add();
                 }
                 this.ActualizaFilaDeLista(i);
             }

             // Eliminar filas sobrantes
             int numExtra = this.GrdLista.Rows.Count - numElementos;
             for (; numExtra > 0; --numExtra)
             {
                 this.GrdLista.Rows.RemoveAt(numElementos);
             }
         }
         
         private void ActualizaFilaDeLista(int numFila)
         {
             Console.WriteLine("Aquí se actualiza la fila de la lista");

             if (numFila < 0
                 || numFila > this.GrdLista.Rows.Count)
             {
                 throw new System.ArgumentOutOfRangeException(
                     "Fila por encima del index: " + nameof(numFila));
             }

             DataGridViewRow fila = this.GrdLista.Rows[numFila];
             Miembro miembro = this.Miembros.List[numFila];


             fila.Cells[0].Value = (numFila + 1).ToString().PadLeft(4, ' ');
             fila.Cells[1].Value = miembro.Dni; 
             fila.Cells[2].Value = miembro.Nombre; 
             fila.Cells[3].Value = miembro.Email;
             fila.Cells[4].Value = miembro.Telefono; 
             fila.Cells[5].Value = miembro.DireccionPostal;
            
             
             
             fila.Cells[6].Value = "Editar";
             fila.Cells[7].Value = "Eliminar";


             foreach (DataGridViewCell celda in fila.Cells)
             {
                 if (celda.ColumnIndex < 6)
                 {
                     celda.ToolTipText = miembro.ToString();
                 }
             }
         }
         
         public void ClickLista()
         {
             try
             {
                 Console.WriteLine("Elemento seleccionado : " + this.GrdLista.CurrentCell.ColumnIndex);

                 if (this.GrdLista.CurrentCell.ColumnIndex == 6)
                 {
                     int fila = this.GrdLista.CurrentCell.RowIndex;
                     
                     Console.WriteLine("Elemento seleccionado  DNI: " + (string)this.GrdLista.Rows[fila].Cells[1].Value);
                     this.ModificaMiembro((string)this.GrdLista.Rows[fila].Cells[1].Value);
                 }
                 else if (this.GrdLista.CurrentCell.ColumnIndex == 7)
                 {
                     this.EliminaMiembro();
                 }

                 this.Actualiza();
             }
             catch (Exception) { }
         }
        
         
         public void EliminaMiembro()
         {
             Console.WriteLine("Eliminar Miembro");
             var dni = (string)this.GrdLista.CurrentRow.Cells[1].Value;
             var nombre = (string)this.GrdLista.CurrentRow.Cells[2].Value;
             Console.WriteLine(nombre + " va a ser borrado");


             //Dialogo de confirmación de eliminación
             DialogResult result;
             string mensaje = "¿Está seguro de que desea eliminar a " + nombre + ", del listado de miembros?";
             string tittle = "Eliminar miembro";
            
             result = MessageBox.Show(mensaje, tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            

             if (result == DialogResult.Yes)
             {
                 this.Miembros.borrarMiembro(this.Miembros.getMiembro(dni));
             
             }
         }
         
         public void ModificaMiembro(String dni)
         {
             Console.WriteLine("Modifica Miembro");
             Miembro miembroModificado = this.Miembros.getMiembro(dni);
             Console.WriteLine("Miembro modificado: " + miembroModificado.ToString());
             
             var dlgModificar = new DlgModificaMiembro(miembroModificado);
             

             this.Hide();
             if (dlgModificar.ShowDialog() == DialogResult.OK)
             {
                 this.Miembros.borrarMiembro(miembroModificado);
                 string DNI = dlgModificar.DNI;
                 string Nombre = dlgModificar.Nombre;
                 long Telefono = dlgModificar.Telefono;
                 string Email = dlgModificar.Email;
                 string DireccionPostal = dlgModificar.DirPostal;

                 Miembro m = new Miembro(DNI, Nombre, Telefono, Email, DireccionPostal);
                 Console.WriteLine("Miembro modificado: " + m.ToString());
                 this.Miembros.añadirMiembro(m);
                 this.Actualiza();

             }

             if (!this.IsDisposed) { this.Show(); }
             else { Application.Exit(); }
         }

        public void Guardar()
        {
            Console.WriteLine("Guardado en XML");
            //this.Miembros.GuardarXml();
        }

        public void VaciarListaDeMiembros()
        {
            this.Miembros.VaciarLista();
            this.Actualiza();
            Console.WriteLine("Lista vaciada");
            
        }
        public void Salir()
        {
            Console.WriteLine("Guardar y salir");
            //this.Miembros.GuardarXml();
            Application.Exit();
        }
        
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVaciarMiembros;
        public MenuItem opGuardar;
        public MenuItem opSalir;
        public MenuItem opVolver;
     


        public StatusBar SbStatus;
        private Panel pnlPpal;
        private TextBox edDetalle;
        public DataGridView GrdLista;


        private GestionMiembros Miembros;
   

        private MainWindowCore mainWindowCore;
        
        
    }
}