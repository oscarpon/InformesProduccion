using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using WForms = System.Windows.Forms;

namespace proyectoIndividual
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var mainForm = new MainWindowCore().View;
            WForms.Application.Run(mainForm);
        }
    }
}