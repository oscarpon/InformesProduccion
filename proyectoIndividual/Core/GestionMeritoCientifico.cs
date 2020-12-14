using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace proyectoIndividual.Core
{
    public class GestionMeritoCientifico
    {
        public const string ArchivoXML = "meritos.xml";
        public const string EtqMeritos = "meritos_cientificos";
        public const string EtqMerito = "merito_cientifico";
        public const string EtqTipo = "tipo";
        public const string EtqDOI = "doi";
        public const string EtqISSN = "issn";
        public const string EtqAño = "año";
        public const string EtqPagIn = "pagina_inicio";
        public const string EtqPagFin = "pagina_final";
        public const string EtqAutor = "autor";
        
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
            TextWriter tw = new StreamWriter($"Informe{Año}.txt");
            tw.Write("Informe del año:");
            tw.WriteLine(Año);
            foreach (MeritoCientifico merito in this.listaMeritoCientificos)
            {
                if (merito.Año == Año)
                {
                    System.Console.WriteLine(merito);
                    tw.WriteLine(merito);
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
        
        public List<string> getListAños()
        {
            List<string> años = new List<string>();
            foreach (MeritoCientifico merito in this.listaMeritoCientificos)
            {
                años.Add(merito.Año.ToString());
                System.Console.WriteLine(merito.Autor);
            }
            

            return años;
        }
        
        public int[] getNumeroVecesAño()
        {
            string[] años = getListAños().ToArray();
            int[] count = new int[años.Length];

            for (int i = 0; i < años.Length; i++)
            {
                for (int j = 0; j < años.Length; j++)
                {
                    if (String.Compare(años[i], años[j], StringComparison.Ordinal) == 0)
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
        
        public void GuardarXml()
        {
            this.GuardarXml(ArchivoXML);
        }
        public void GuardarXml(String n)
        {
            Console.WriteLine("GuardaXML meritos\nEGuarda en el fichero: "+n);
            var doc = new XDocument();
            var root = new XElement(EtqMeritos);

            foreach (MeritoCientifico m in listaMeritoCientificos)
            {
                XElement merito = new XElement(EtqMerito,
                    new XAttribute(EtqTipo, m.Tipo),
                    new XAttribute(EtqDOI, m.Doi),
                    new XAttribute(EtqISSN, m.Issn),
                    new XAttribute(EtqAño, m.Año),
                    new XAttribute(EtqPagIn, m.PagIn),
                    new XAttribute(EtqPagFin, m.PagFin),
                    new XAttribute(EtqAutor, m.Autor)
                );

                root.Add(merito);
            }
            doc.Add(root);
            doc.Save(n);
        } 
        public static GestionMeritoCientifico RecuperarXml()
        {
            return RecuperarXml(ArchivoXML);
        }
        public static GestionMeritoCientifico RecuperarXml(String n)
        {
            var toret = new GestionMeritoCientifico();
            //Console.WriteLine("creo variable toret");
            try
            {
                //Console.WriteLine("entro dentro del try");
                var doc = XDocument.Load(n);
                //Console.WriteLine("hago el load del xml");
                Console.WriteLine("Cargando del fichero: " + n);
                if (doc.Root != null && doc.Root.Name == EtqMeritos)
                {
                    //Console.WriteLine("entro dentro del if");
                    var meritos = doc.Root.Elements(EtqMerito);
                    //Console.WriteLine("creo la variable meritos");
                    foreach (XElement meritoXml in meritos)
                    {
                        
                        toret.añadirMeritoCientifico( new MeritoCientifico(
                                (string) meritoXml.Attribute( EtqTipo ),
                                (int) meritoXml.Attribute( EtqDOI ),
                                (string) meritoXml.Attribute( EtqISSN ),
                                (int) meritoXml.Attribute( EtqAño ),
                                (int) meritoXml.Attribute( EtqPagIn ),
                                (int) meritoXml.Attribute( EtqPagFin ),
                                (string) meritoXml.Attribute( EtqAutor )
                            )
                        );
                    }
                }
            }
            catch (XmlException)
            {
                toret.VaciarLista();
            }
            catch (IOException)
            {
                toret.VaciarLista();
            }
            return toret;
        }
        
    }
}