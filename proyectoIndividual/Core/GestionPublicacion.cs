using System;
using System.Collections.Generic;
 using System.IO;
 using System.Text;
 using System.Xml;
 using System.Xml.Linq;

 namespace proyectoIndividual.Core
{
    public class GestionPublicacion
    {
        public const string ArchivoXML = "publicaciones.xml";
        public const string EtqPublicaciones = "publicaciones_cientificas";
        public const string EtqPublicacion = "publicacion_cientifica";
        public const string EtqTipo = "tipo";
        public const string EtqISSN = "issn";
        public const string EtqTitulo = "titulo";
        public const string EtqEditorial = "editorial";
        public const string EtqRegeditorial = "registro_editorial_o_ciudad";

        private List<Publicacion> listaPublicaciones;

        public List<Publicacion> List
        {
            get
            {
                return this.listaPublicaciones;
            }
        }


        public GestionPublicacion()
        {
            listaPublicaciones = new List<Publicacion>();
        }
        
        public GestionPublicacion(IEnumerable<Publicacion> publicaciones) : this()
        {
            this.listaPublicaciones.AddRange(publicaciones);
        }
        

        public Publicacion getPublicaciones(string ISSN)
        {
            foreach (Publicacion publicacion in this.listaPublicaciones)
            {
                if (publicacion.IssnP == ISSN)
                {
                    return publicacion;
                }
            }

            return null;
        }

        public void VaciarLista()
        {
            this.listaPublicaciones.Clear();
        }
        
        public void añadirPublicacion(Publicacion publicacion)
        {

            if (!listaPublicaciones.Contains(publicacion))
            {
                listaPublicaciones.Add(publicacion);
            }
            else
            {
                System.Console.WriteLine( "Ya existe la publicación con ISSN" + publicacion.IssnP );
            }
            
        }

        public void borrarPublicacion(Publicacion publicacion)
        {
            if(!listaPublicaciones.Contains(publicacion))
            {
                System.Console.WriteLine("No existe ninguna publicación con ISSN " + publicacion.IssnP );
            }
            else
            {
                listaPublicaciones.Remove(publicacion);
            }
            
            
        }

        public void editarPublicacion(Publicacion publicacion)
        {

            if (!listaPublicaciones.Contains(publicacion))
            {
                System.Console.WriteLine("No existe ningun publicacion con ISSN " + publicacion.IssnP );

            }
            else
            {
                foreach (Publicacion p in this.listaPublicaciones)
                {
                    if (p.Equals(publicacion))
                    {

                        System.Console.WriteLine("introduce los nuevos datos");
                        
                        System.Console.Write("ISSN:");
                        string Issn = System.Console.ReadLine();
                        p.IssnP = Issn;
                        
                        System.Console.Write("Título:");
                        string Titulo = System.Console.ReadLine();
                        p.TituloP = Titulo;
                        
                        System.Console.Write("Editorial:");
                        string Editorial = System.Console.ReadLine();
                        p.EditorialP = Editorial;
                        
                        System.Console.Write("Registro_Editorial:");
                        string RegEditorial = System.Console.ReadLine();
                        p.RegEditorialP1 = RegEditorial;
                        
                        
                    }
                    
                    
                }
                
                
            }
        }
        
        public override string ToString()
        {
            var toret = new StringBuilder();
            foreach (Publicacion publicacion in this.listaPublicaciones)
            {
                toret.Append(publicacion);
            }

            return toret.ToString();
        }
        
        public void GuardarXml()
        {
            this.GuardarXml(ArchivoXML);
        }
        public void GuardarXml(String n)
        {
            Console.WriteLine("GuardaXML publicaciones\nEGuarda en el fichero: "+n);
            var doc = new XDocument();
            var root = new XElement(EtqPublicaciones);

            foreach (Publicacion p in listaPublicaciones)
            {
                XElement publicacion = new XElement(EtqPublicacion,
                    new XAttribute(EtqTipo, p.Tipo),
                    new XAttribute(EtqISSN, p.IssnP),
                    new XAttribute(EtqTitulo, p.TituloP),
                    new XAttribute(EtqEditorial, p.EditorialP),
                    new XAttribute(EtqRegeditorial, p.RegEditorialP1)
                );

                root.Add(publicacion);
            }
            doc.Add(root);
            doc.Save(n);
        }
        
        public static GestionPublicacion RecuperarXml()
        {
            return RecuperarXml(ArchivoXML);
        }
        public static GestionPublicacion RecuperarXml(String n)
        {
            var toret = new GestionPublicacion();
            Console.WriteLine("creo variable toret");
            try
            {
                Console.WriteLine("entro dentro del try");
                var doc = XDocument.Load(n);
                Console.WriteLine("hago el load del xml");
                Console.WriteLine("Cargando del fichero: " + n);
                Console.WriteLine(doc.Root);
                Console.WriteLine("diferenciando");
                Console.WriteLine(doc.Root.Name);
                if (doc.Root != null && doc.Root.Name == EtqPublicaciones)
                {
                    Console.WriteLine("entro dentro del if");
                    var publicaciones = doc.Root.Elements(EtqPublicacion);
                    Console.WriteLine("creo la variable meritos");
                    foreach (XElement publicacioneXml in publicaciones)
                    {
                        
                        toret.añadirPublicacion( new Publicacion(
                                (string) publicacioneXml.Attribute( EtqTipo ),
                                (string) publicacioneXml.Attribute( EtqISSN ),
                                (string) publicacioneXml.Attribute( EtqTitulo ),
                                (string) publicacioneXml.Attribute( EtqEditorial ),
                                (string) publicacioneXml.Attribute( EtqRegeditorial )
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