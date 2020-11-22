namespace InformesProduccion.Core
{
    public class Merito
    {
        public Merito(int doi, int issn, int ano, string paginas, string autor)
        {
            this.Doi = doi;
            this.Issn = issn;
            this.Ano = ano;
            this.Pagina = paginas;
            this.Autor = autor;
        }
        public int Doi { get; set; }
        public int Issn { get; set; }
        public int Ano { get; set; }
        public string Pagina { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Doi: {0}, ISSN: {1}, Año: {2}, Paginas: {3}, Autor: {4}",
                this.Doi, this.Issn, this.Ano, this.Pagina, this.Autor
            );
        }
    }
}