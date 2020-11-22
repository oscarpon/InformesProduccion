namespace InformesProduccion.Ui
{
    using WForms = System.Windows.Forms;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var f = new MainWindowCtrl().View;
            
            WForms.Application.Run(f);
        }
    }
}