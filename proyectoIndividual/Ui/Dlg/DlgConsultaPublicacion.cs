using System.Windows.Forms;
using proyectoIndividual.Core;
using System;
using System.Drawing;
using proyectoIndividual;

namespace proyectoIndividual.Ui.Dlg
{
    public class DlgConsultaPublicacion : Form
    {
        
        public DlgConsultaPublicacion(GestionPublicacion Publicaciones)
        {
            this.mainWindowCore = new MainWindowCore();
            this.publicaciones = Publicaciones;
            this.BuildGUI();
            this.CenterToScreen();
            


            
            this.GrdLista.Click += (sender, e) => ClickLista();
            this.opGuardar.Click += (sender, e) => this.Guardar();
            this.opVaciarPublicaciones.Click += (sender, e) => this.VaciarListaDePublicaciones();
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
            this.Text = "Gestion de Publicaciones - Consultar Publicaciones";

            this.Actualiza();
            this.ResumeLayout(true);
            this.ResizeWindow();
        }

        private void BuildMenu()
        {
            this.mPpal = new MainMenu();
            this.mArchivo = new MenuItem("&Archivo");
            this.opGuardar = new MenuItem("&Guardar");
            this.opVaciarPublicaciones = new MenuItem("&Vaciar Publicaciones");
            this.opSalir = new MenuItem("&Salir");
            this.opVolver = new MenuItem("&Volver");
            this.opSalir.Shortcut = Shortcut.CtrlQ;
           
            
            this.mArchivo.MenuItems.Add(this.opVolver);
            this.mArchivo.MenuItems.Add(this.opGuardar);
            this.mArchivo.MenuItems.Add(this.opVaciarPublicaciones);
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
                HeaderText = "tipo",
                Width = 20,
                ReadOnly = true
            };
            var columna2 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate2,
                HeaderText = "Issn",
                Width = 20,
                ReadOnly = true
            };

            var columna3 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "Titulo",
                Width = 15,
                ReadOnly = true
            };
            

            
            var columna4 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "Editorial",
                Width = 15,
                ReadOnly = true
            };
            
            var columna5 = new DataGridViewTextBoxColumn 
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "RegEditorial",
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

                
                 if (posicion < 6 && this.publicaciones.List.Count > fila)
                 {
                     this.edDetalle.Text = this.publicaciones.List[fila].ToString();
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
                 (int)System.Math.Floor(width * .03); // Número de Publicacion
             this.GrdLista.Columns[1].Width =
                 (int)System.Math.Floor(width * .10); // Tipo
             this.GrdLista.Columns[2].Width =
                 (int)System.Math.Floor(width * .20); // Issn
             this.GrdLista.Columns[3].Width =
                 (int)System.Math.Floor(width * .14); // Titulo
             this.GrdLista.Columns[4].Width =
                 (int)System.Math.Floor(width * .14); // Editorial
             this.GrdLista.Columns[5].Width =
                 (int)System.Math.Floor(width * .12); // RegEditorial
             this.GrdLista.Columns[6].Width =
                 (int)System.Math.Floor(width * .12); // Editar
             this.GrdLista.Columns[7].Width =
                 (int)System.Math.Floor(width * .15); // Eliminar
         }
         
     
         void Actualiza()
         {
             Console.WriteLine("Aquí es cuando se actualiza la lista");




             int numElementos = this.publicaciones.List.Count;
             Console.WriteLine("Número de Publicaciones: " + numElementos);

             this.SbStatus.Text = ("Número de Publicaciones actuales: " + numElementos);

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
             Publicacion publicacion = this.publicaciones.List[numFila];
             
             
             fila.Cells[0].Value = (numFila + 1).ToString().PadLeft(4, ' ');
             fila.Cells[1].Value = publicacion.Tipo;
             fila.Cells[2].Value = publicacion.IssnP;
             fila.Cells[3].Value = publicacion.TituloP;
             fila.Cells[4].Value = publicacion.EditorialP;
             fila.Cells[5].Value = publicacion.RegEditorialP1;

             fila.Cells[6].Value = "Editar";
             fila.Cells[7].Value = "Eliminar";


             foreach (DataGridViewCell celda in fila.Cells)
             {
                 if (celda.ColumnIndex < 6)
                 {
                     celda.ToolTipText = publicacion.ToString();
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
                     
                     Console.WriteLine("Elemento seleccionado  ISSN: " + (string)this.GrdLista.Rows[fila].Cells[3].Value);
                     this.ModificaPublicacion((string)this.GrdLista.Rows[fila].Cells[3].Value);
                 }
                 else if (this.GrdLista.CurrentCell.ColumnIndex == 7)
                 {
                     this.EliminaPublicacion();
                 }

                 this.Actualiza();
             }
             catch (Exception exc) { Console.WriteLine(exc.Message);}
         }
        
         
         public void EliminaPublicacion()
         {
             Console.WriteLine("Eliminar Publicacion");
             var Issn = (string)this.GrdLista.CurrentRow.Cells[2].Value;
             Console.WriteLine(Issn + " va a ser borrado");


             //Dialogo de confirmación de eliminación
             DialogResult result;
             string mensaje = "¿Está seguro de que desea eliminar a " + Issn + " de los meritos cientificos?";
             string tittle = "Eliminar merito cientifico";
            
             result = MessageBox.Show(mensaje, tittle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            

             if (result == DialogResult.Yes)
             {
                 this.publicaciones.borrarPublicacion(this.publicaciones.getPublicaciones(Issn));
             }
         }
         
         public void ModificaPublicacion(String Issn)
         {
             Console.WriteLine("Modificar Publicacion");
             //Console.WriteLine(this.meritos.getMeritoCientifico(Issn));
             Publicacion publicacionModificada = this.publicaciones.getPublicaciones(Issn);
             Console.WriteLine("Publicacion modificado: " + publicacionModificada.ToString());
             
             var dlgModificar = new DlgModificaPublicacion(publicacionModificada);
             //Console.WriteLine("aqui llego");
             //Console.WriteLine(dlgModificar.ToString());

             this.Hide();
             if (dlgModificar.ShowDialog() == DialogResult.OK)
             {
                 
                 this.publicaciones.borrarPublicacion(publicacionModificada);
                 
                 //Console.WriteLine("aqui llego1");
                 string tipo = dlgModificar.Tipo;
                 string ISSN = dlgModificar.Issn;
                 string titulo = dlgModificar.Titulo;
                 string editorial = dlgModificar.Editorial;
                 string regeditorial = dlgModificar.RegEditorial;
                 Console.WriteLine("aqui llego");
                 Publicacion p = new Publicacion(tipo,ISSN, titulo, editorial, regeditorial);
                 Console.WriteLine(p.ToString());
                 Console.WriteLine("Publicacion modificada: " + p.ToString());
                 this.publicaciones.añadirPublicacion(p);
                 this.Actualiza();

             }

             if (!this.IsDisposed)
             {
                 this.Show();
             }else { Application.Exit(); }
         }

        public void Guardar()
        {
            Console.WriteLine("Guardado en XML");
            this.publicaciones.GuardarXml();

        }

        public void VaciarListaDePublicaciones()
        {
            this.publicaciones.VaciarLista();
            this.Actualiza();
            Console.WriteLine("Lista vaciada");
            
        }
        public void Salir()
        {
            Console.WriteLine("Guardar y salir");
            this.publicaciones.GuardarXml();
            Application.Exit();
        }
        
        private MainMenu mPpal;
        public MenuItem mArchivo;
        public MenuItem opVaciarPublicaciones;
        public MenuItem opGuardar;
        public MenuItem opSalir;
        public MenuItem opVolver;
     


        public StatusBar SbStatus;
        private Panel pnlPpal;
        private TextBox edDetalle;
        public DataGridView GrdLista;


        private GestionPublicacion publicaciones;
   

        private MainWindowCore mainWindowCore;
        
        
    }
}