using System;

namespace proyectoIndividual.Core
{
    public class Publicacion
    {
        private string tipo;
        private string issnP;
        private string tituloP;
        private string editorialP;
        private string RegEditorialP;

        public Publicacion(string tipo, string issnP, string tituloP, string editorialP, string regEditorialP)
        {
            this.tipo = tipo;
            this.issnP = issnP;
            this.tituloP = tituloP;
            this.editorialP = editorialP;
            this.RegEditorialP = regEditorialP;
        }

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public string IssnP
        {
            get => issnP;
            set => issnP = value;
        }

        public string TituloP
        {
            get => tituloP;
            set => tituloP = value;
        }

        public string EditorialP
        {
            get => editorialP;
            set => editorialP = value;
        }

        public string RegEditorialP1
        {
            get => RegEditorialP;
            set => RegEditorialP = value;
        }


        public override string ToString()
        {
           
            return String.Format( "(Publicacion) ISSN: {0}, Titulo: {1}, Editorial: {2}, Registro_Editorial: {3}, Tipo: {4}\n",
                this.issnP,
                this.tituloP,
                this.editorialP,
                this.RegEditorialP,
                this.tipo);
        }
    }
}