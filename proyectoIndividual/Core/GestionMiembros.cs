using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using proyectoIndividual.Core;

namespace proyectoIndividual.Core
{
    public class GestionMiembros 
    {
        public const string ArchivoXML = "miembros.xml";
        public const string EtqMiembros = "miembros";
        public const string EtqMiembro = "miembro";
        public const string EtqDni = "dni";
        public const string EtqNombre = "nombre";
        public const string EtqTelefono = "telefono";
        public const string EtqEmail = "email";
        public const string EtqDireccion = "direccion_postal";

        private List<Miembro> listaMiembros;

        public List<Miembro> List
        {
            get
            {
                return this.listaMiembros;
            }
        }


        public GestionMiembros()
        {
            listaMiembros = new List<Miembro>();
        }
        
        public int Count
        {
            get { return this.listaMiembros.Count; }
        }
        
        public GestionMiembros(IEnumerable<Miembro> miembros) : this()
        {
            this.listaMiembros.AddRange(miembros);
        }
        

        public Miembro getMiembro(string dni)
        {
            foreach (Miembro miembro in this.listaMiembros)
            {
                if (miembro.Dni == dni)
                {
                    return miembro;
                }
            }

            return null;
        }
        
        public Miembro getMiembroInt(int i)
        {
            return this.listaMiembros[i];
        }

        public void VaciarLista()
        {
            this.listaMiembros.Clear();
        }
        
        public void añadirMiembro(Miembro m1)
        {
            if (!listaMiembros.Contains(m1))
            {
                listaMiembros.Add(m1);
            }
            else
            {
                System.Console.WriteLine("El miembro con dni: " + m1.Dni + " ya se encuentra en la aplicación" );
            }
            
        }

        public void borrarMiembro(Miembro m1)
        {
            if(!listaMiembros.Contains(m1))
            {
                System.Console.WriteLine("El miembro con dni: " + m1.Dni + " no se encuentra en la aplicación");
            }
            else
            {
                listaMiembros.Remove(m1);
            }
            
            
        }
        

        public void editarMiembro(Miembro m1)
        {

            if (!listaMiembros.Contains(m1))
            {
                System.Console.WriteLine("El miembro con dni: " + m1.Dni +
                                         " no se encuentra en la aplicación, no se puede editar");

            }
            else
            {
                foreach (Miembro miembro in this.listaMiembros)
                {
                    if (miembro.Equals(m1))
                    {
                        
                        /*this.Dni = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.DireccionPostal = direccionPostal;*/
                        
                        System.Console.WriteLine("Miembro encontrado, modifica los datos");
                        
                        System.Console.Write("Dni:");
                        string dni = System.Console.ReadLine();
                        miembro.Dni = dni;
                        
                        System.Console.Write("Nombre:");
                        string nombre = System.Console.ReadLine();
                        miembro.Nombre = nombre;
                        
                        System.Console.Write("Teléfono:");
                        int telefono = Int32.Parse(System.Console.ReadLine());
                        miembro.Telefono = telefono;
                        
                        System.Console.Write("Email:");
                        string email = System.Console.ReadLine();
                        miembro.Email = email;
                        
                        System.Console.Write("Dirección Postal:");
                        string direccionPostal = System.Console.ReadLine();
                        miembro.DireccionPostal = direccionPostal;
                        
                        
                    }
                    
                    
                }
                
                
            }
        }
        
        public override string ToString()
        {
            var toret = new StringBuilder();
            foreach (Miembro miembro in this.listaMiembros)
            {
                toret.Append(miembro);
            }

            return toret.ToString();
        }
        
        
        public void GuardarXml()
        {
            this.GuardarXml(ArchivoXML);
        }
        
        
        public void GuardarXml(String n)
        {
            Console.WriteLine("GuardaXML miembros\nEGuarda en el fichero: "+n);
            var doc = new XDocument();
            var root = new XElement(EtqMiembros);

            foreach (Miembro m in listaMiembros)
            {
                XElement miembro = new XElement(EtqMiembro,
                    new XAttribute(EtqDni, m.Dni),
                    new XAttribute(EtqNombre, m.Nombre),
                    new XAttribute(EtqTelefono, m.Telefono),
                    new XAttribute(EtqEmail, m.Email),
                    new XAttribute(EtqDireccion, m.DireccionPostal)
                );

                root.Add(miembro);
            }
            doc.Add(root);
            doc.Save(n);
        }
        
        public static GestionMiembros RecuperarXml()
        {
            return RecuperarXml(ArchivoXML);
        }
        public static GestionMiembros RecuperarXml(String n)
        {
            var toret = new GestionMiembros();
            try
            {
                var doc = XDocument.Load(n);
                Console.WriteLine("Cargando del fichero: " + n);
                if (doc.Root != null && doc.Root.Name == EtqMiembros)
                {
                    var meritos = doc.Root.Elements(EtqMiembro);
                    foreach (XElement meritoXml in meritos)
                    {
                        
                        toret.añadirMiembro( new Miembro(
                                (string) meritoXml.Attribute( EtqDni ),
                                (string) meritoXml.Attribute( EtqNombre ),
                                (long) meritoXml.Attribute( EtqTelefono ),
                                (string) meritoXml.Attribute( EtqEmail ),
                                (string) meritoXml.Attribute( EtqDireccion )
                                
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