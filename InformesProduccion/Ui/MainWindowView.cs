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
            
            
        }
        
    }
}