namespace InformesProduccion.Ui
{
    using WForms = System.Windows.Forms;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var f = new MainWindow();
            
            WForms.Application.Run(f);
        }
    }
}