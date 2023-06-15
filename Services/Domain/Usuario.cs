using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class Usuario
    {  

        public Guid IdUsuario { get; set; }

        public String Nombre { get; set; }

        public DateTime FechaNac { get; set; }

        public Usuario(String nombre, DateTime fechaNac)
        {
            IdUsuario = Generar();
            Nombre = nombre;
            FechaNac = fechaNac;
        }

        public Guid Generar()
        {
            return Guid.NewGuid();
        }
    }
}
