using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Composite
{
    public class User
    {
        public Guid Id { get; set; }
        public String Password { get; set; }

        public String UserName { get; set; }

        public String Email { get; set; }

        //Preguntas de seguridad, contador de accesos, enabled True/False

        public List<Component> Permiso { get; set; } //Esto me permite poder agregarle al usuario Patentes o Familias indistintamente...


    }
}
