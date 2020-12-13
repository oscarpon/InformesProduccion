using System;

namespace proyectoIndividual.Core
{
    public class MeritoCientifico
    {
        private string tipo;
        private int DOI;
        private string ISSN;
        private int año;
        private int pagIn;
        private int pagFin;
        private string autor;

        public MeritoCientifico(string tipo,int doi, string issn, int año, int pagIn, int pagFin, string autor)
        {
            this.tipo = tipo;
            this.DOI = doi;
            this.ISSN = issn;
            this.año = año;
            this.pagIn = pagIn;
            this.pagFin = pagFin;
            this.autor = autor;
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Doi
        {
            get { return DOI; }
        }


        public string Issn
        {
            get => ISSN;
            set => ISSN = value;
        }

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        public int PagIn
        {
            get { return pagIn; }
            set { pagIn = value; }
        }

        public int PagFin
        {
            get { return pagFin; }
            set { pagFin = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public string devolverISSN()
        {
            return ISSN;
        }
        
        public override string ToString()
        {
            return String.Format( "(MeritoCientifico) Tipo: {0}, DOI: {1}, ISSN: {2}, Año de publicacion: {3},  pagina de inicio: {4}, pagina de final {5}, autor: {6}\n",
                this.tipo,
                this.Doi,
                this.Issn,
                this.año,
                this.pagIn,
                this.pagFin,
                this.autor);
        }
    }
}