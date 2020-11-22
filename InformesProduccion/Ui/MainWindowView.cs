using System.Windows.Forms.Design;

namespace InformesProduccion.Ui
{
    using WForms =  System.Windows.Forms;
    using Draw =  System.Drawing;

    public class MainWindowView: WForms.Form
    {
        public MainWindowView()
        {
            this.Build();
        }

        void Build()
        {
            var pnlMain = new WForms.TableLayoutPanel()
            {
                Dock = WForms.DockStyle.Fill
            };
            
            pnlMain.Controls.Add(this.BuildInfAnual());
            pnlMain.Controls.Add(this.BuildBtInfAnual());
            pnlMain.Controls.Add(this.BuildInfMensual());
            pnlMain.Controls.Add(this.BuildBtInfMensual());
            pnlMain.Controls.Add(this.BuildPanelLista());
            pnlMain.Controls.Add(this.BuildBtnTodos());
            
            
            this.Controls.Add(pnlMain);
            this.Text = "Informes científicos";
            this.MinimumSize = new Draw.Size(500,500);

        }

        WForms.Panel BuildInfAnual()
        {
            var toret = new WForms.Panel
            {
                Dock = WForms.DockStyle.Top
            };

            this.InfAnual = new WForms.TextBox
            {
                Dock = WForms.DockStyle.Fill,
                Text = "Año",
                TextAlign = WForms.HorizontalAlignment.Center
            };
            toret.Controls.Add(this.InfAnual);
            return toret;
        }

        WForms.Button BuildBtInfAnual()
        {
            this.BtInfAnual = new WForms.Button
            {
                Dock = WForms.DockStyle.Top,
                Text = "Informe Anual"
            };
            
            return BtInfAnual;
        }

        WForms.Panel BuildInfMensual()
        {
            var toret = new WForms.Panel
            {
                Dock = WForms.DockStyle.Top
            };
            this.InfMensual = new WForms.ComboBox
            {
                Dock = WForms.DockStyle.Fill,
                DropDownStyle = WForms.ComboBoxStyle.DropDownList
            };
            
            this.InfMensual.Items.AddRange(new []
            {
                "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre",
                "noviembre", "diciembre"
            });
            this.InfMensual.Text = (string) this.InfMensual.Items[0];
            toret.Controls.Add(this.InfMensual);
            toret.MaximumSize = new Draw.Size(int.MaxValue, this.InfMensual.Height);
            return toret;
        }
        WForms.Button BuildBtInfMensual()
        {
            this.BtInfAnual = new WForms.Button
            {
                Dock = WForms.DockStyle.Top,
                Text = "Informe Mensual"
            };
            return BtInfAnual;
        }
        
        WForms.Button BuildBtnTodos()
        {
            this.BtInfAnual = new WForms.Button
            {
                Dock = WForms.DockStyle.Top,
                Text = "MostrarTodos"
            };
            
            return BtInfAnual;
        }
        
        WForms.Panel BuildPanelLista()
        {
            var pnlLista = new WForms.Panel();
            pnlLista.SuspendLayout();
            pnlLista.Dock = WForms.DockStyle.Fill;

            // Crear gridview
            this.PanelLista = new WForms.DataGridView()
            {
                Dock = WForms.DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = WForms.DataGridViewSelectionMode.FullRowSelect
            };
            
            this.PanelLista.ColumnHeadersDefaultCellStyle.ForeColor = Draw.Color.Black;
            this.PanelLista.ColumnHeadersDefaultCellStyle.BackColor = Draw.Color.LightGray;
            
            var textCellTemplate0 = new WForms.DataGridViewTextBoxCell();
            var textCellTemplate1 = new WForms.DataGridViewTextBoxCell();
            var textCellTemplate2 = new WForms.DataGridViewTextBoxCell();
            var textCellTemplate3 = new WForms.DataGridViewTextBoxCell();
            var textCellTemplate4 = new WForms.DataGridViewTextBoxCell();
            textCellTemplate0.Style.BackColor = Draw.Color.LightGray;
            textCellTemplate0.Style.ForeColor = Draw.Color.Black;
            textCellTemplate1.Style.BackColor = Draw.Color.Wheat;
            textCellTemplate1.Style.ForeColor = Draw.Color.Black;
            textCellTemplate1.Style.Alignment = WForms.DataGridViewContentAlignment.MiddleRight;
            textCellTemplate2.Style.BackColor = Draw.Color.Wheat;
            textCellTemplate2.Style.ForeColor = Draw.Color.Black;
            textCellTemplate3.Style.BackColor = Draw.Color.Wheat;
            textCellTemplate3.Style.ForeColor = Draw.Color.Black;
            textCellTemplate4.Style.BackColor = Draw.Color.Wheat;
            textCellTemplate4.Style.ForeColor = Draw.Color.Black;
            
            var column0 = new WForms.DataGridViewTextBoxColumn {
                SortMode = WForms.DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "DOI",
                Width = 50,
                ReadOnly = true
            };
            
            var column1 = new WForms.DataGridViewTextBoxColumn {
                SortMode = WForms.DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "ISSN",
                Width = 50,
                ReadOnly = true
            };
            
            var column2 = new WForms.DataGridViewTextBoxColumn {
                SortMode = WForms.DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate2,
                HeaderText = "Año",
                Width = 50,
                ReadOnly = true
            };
            
            var column3 = new WForms.DataGridViewTextBoxColumn {
                SortMode = WForms.DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate3,
                HeaderText = "Paginas",
                Width = 50,
                ReadOnly = true
            };
            
            var column4 = new WForms.DataGridViewTextBoxColumn {
                SortMode = WForms.DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "Autor",
                Width = 50,
                ReadOnly = true
            };
            
            this.PanelLista.Columns.AddRange( new WForms.DataGridViewColumn[] {
                column0, column1, column2, column3, column4
            } );
            
            return pnlLista;
        }
        
        

        public WForms.TextBox InfAnual
        {
            get;
            private set;
        }

        public WForms.Button BtInfAnual
        {
            get; private set;
        }

        public WForms.ComboBox InfMensual
        {
            get;
            private set;
        }

        public WForms.Button BtInfMensual
        {
            get;
            private set;
        }

        public WForms.DataGridView PanelLista
        {
            get;
            private set;
        }

        public WForms.Button BtnInfTodos
        {
            get;
            private set;
        }
        
    }
}