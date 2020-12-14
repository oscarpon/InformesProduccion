using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace proyectoIndividual.Core
{
    public class GestionMeritoCientifico
    {
        private List<MeritoCientifico> listaMeritoCientificos;

        public List<MeritoCientifico> List
        {
            get
            {
                return this.listaMeritoCientificos;
            }
        }


        public GestionMeritoCientifico()
        {
            listaMeritoCientificos = new List<MeritoCientifico>();
        }
        
        public GestionMeritoCientifico(IEnumerable<MeritoCientifico> meritos) : this()
        {
            this.listaMeritoCientificos.AddRange(meritos);
        }
        

        public MeritoCientifico getMeritoCientifico(string ISSN)
        {
            foreach (MeritoCientifico merito in this.listaMeritoCientificos)
            {
                if (merito.Issn == ISSN)
                {
                    return merito;
                }
            }

            return null;
        }

        public MeritoCientifico getMeritoAño(int Año)
        {
            TextWriter tw = new StreamWriter("SavedList.txt");
            tw.Write("Informe del año:");
            tw.WriteLine(Año);
            foreach (MeritoCientifico merito in this.listaMeritoCientificos)
            {
                if (merito.Año == Año)
                {
                    System.Console.WriteLine(merito);
                    tw.WriteLine(merito);
                    getListAutores();
                }
                
            }
            
            tw.Close();

            return null;
        }

        public List<string> getListAutores()
        {
            List<String> autores = new List<string>();
            foreach (MeritoCientifico merito in this.listaMeritoCientificos)
            {
                autores.Add(merito.Autor);
                System.Console.WriteLine(merito.Autor);
            }
            

            return autores;
        }

        public int[] getNumeroVeces()
        {
            String[] palabras = getListAutores().ToArray();
            int[] count = new int[palabras.Length];

            for (int i = 0; i < palabras.Length; i++)
            {
                for (int j = 0; j < palabras.Length; j++)
                {
                    if (String.Compare(palabras[i], palabras[j], StringComparison.Ordinal) == 0)
                    {
                        count[i]++;
                    }
                    
                }
            }

            return count;
        }

        public void VaciarLista()
        {
            this.listaMeritoCientificos.Clear();
        }
        
        public void añadirMeritoCientifico(MeritoCientifico merito)
        {
            if (!listaMeritoCientificos.Contains(merito))
            {
                listaMeritoCientificos.Add(merito);
            }
            else
            {
                System.Console.WriteLine( "Ya existe el merito cientifico con ISSN" + merito.Issn );
            }
            
        }

        public void borrarMeritoCientifico(MeritoCientifico merito)
        {
            if(!listaMeritoCientificos.Contains(merito))
            {
                System.Console.WriteLine("No existe ningun merito cientifico con ISSN " + merito.Issn );
            }
            else
            {
                listaMeritoCientificos.Remove(merito);
            }
            
            
        }

        public void editarMeritoCientifico(MeritoCientifico merito)
        {

            if (!listaMeritoCientificos.Contains(merito))
            {
                System.Console.WriteLine("No existe ningun merito cientifico con ISSN " + merito.Issn );

            }
            else
            {
                foreach (MeritoCientifico m in this.listaMeritoCientificos)
                {
                    if (m.Equals(merito))
                    {

                        System.Console.WriteLine("introduce los nuevos datos");
                        
                        System.Console.Write("ISSN:");
                        string Issn = System.Console.ReadLine();
                        m.Issn = Issn;
                        
                        System.Console.Write("Año:");
                        int año = Int32.Parse(System.Console.ReadLine());
                        m.Año = año;
                        
                        System.Console.Write("Pagina de inicio:");
                        int pagIn = Int32.Parse(System.Console.ReadLine());
                        m.PagIn = pagIn;
                        
                        System.Console.Write("Pagina de final:");
                        int pagFin = Int32.Parse(System.Console.ReadLine());
                        m.PagFin = pagFin;
                        
                        System.Console.Write("Autor:");
                        string autor = System.Console.ReadLine();
                        m.Autor = autor;
                        
                        
                    }
                    
                    
                }
                
                
            }
        }
        
        public override string ToString()
        {
            var toret = new StringBuilder();
            foreach (MeritoCientifico merito in this.listaMeritoCientificos)
            {
                toret.Append(merito);
            }

            return toret.ToString();
        }
        
        
    }
}