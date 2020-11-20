namespace InformesProduccion.Ui
{
    using WForms = System.Windows.Forms;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            WForms.Application.Run(new MainWindowCtrl().View );
        }
    }
}