using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using proyectoIndividual.Core;

namespace proyectoIndividual.Core
{
    public class GestionMiembros 
    {
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
        
        
    }
}