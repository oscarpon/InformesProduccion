using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace InformesProduccion.Ui
{
    using System;
    using System.Windows.Forms;
    using Core;

    public class MainWindowCore: Form
    {
        public const int ColDoi = 0;
        public const int ColIssn = 1;
        public const int ColAno = 3;
        public const int ColPagina = 4;
        public const int ColAutor = 5;

        public void MainWindow()
        {
            this.Build();
            
        }
    }
}