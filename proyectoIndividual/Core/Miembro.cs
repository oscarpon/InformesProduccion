namespace proyectoIndividual.Core
{
    using System;
    using System.Text;
    using System.Xml.Linq;
    
    public class Miembro
    {
        
        /// <summary>
        /// Crea un nuevo <see cref="Miembro"/>.
        /// </summary>
        /// <param name="dni">El nuevo dni, como entero.</param>
        /// <param name="nombre">El nuevo nombre, como texto.</param>
        /// <param name="telefono">El teléfono, como entero.</param>
        /// <param name="email">El email, como texto.</param>
        /// <param name="direccionPostal">El email, como texto.</param>
       
        
        public Miembro(string dni, string nombre, long telefono, string email, string direccionPostal)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.DireccionPostal = direccionPostal;
        }
        
        public string Dni {
            get;
            set;
        }
        
        public string Nombre
        {
            get;
             set;
        }

        public long Telefono
        {
            get;
             set;
        }
        
        public string Email {
            get;
            set;
        }

        public string DireccionPostal
        {
            get;
            set;
        }
        
        public override string ToString()
        {
           
            return String.Format( "(Miembro) DNI: {0}, nombre: {1}, teléfono: {2}, email: {3}, dirección postal - {4}\n",
                this.Dni,
                this.Nombre,
                this.Telefono,
                this.Email,
                this.DireccionPostal);
        }
        
        
        
        
    }
}