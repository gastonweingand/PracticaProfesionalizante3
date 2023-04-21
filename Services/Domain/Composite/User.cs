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

        public List<Component> Permisos { get; set; } = new List<Component>();//Esto me permite poder agregarle al usuario Patentes o Familias indistintamente...

        public List<Patente> GetPatentes()
        {
            List<Patente> aux = new List<Patente>();
            //LLamar al método recursivo
            ObtenerHijos(Permisos, aux);
            return aux;
        }

        public List<Familia> GetFamilias()
        {
            List<Familia> aux = new List<Familia>();
            //LLamar al método recursivo
            
            return aux;
        }

        private void ObtenerHijos(List<Component> components, List<Patente> patentes)
        {
            foreach (var component in components)
            {
                if(component.CountChild()==0)
                {
                    if(!patentes.Exists(o => o.Id == component.Id))
                        patentes.Add(component as Patente);
                    else
                        Console.WriteLine($"Esta patente ya fue cargada: {component.Id}");
                }
                else
                {
                    //Si esto acá, yo sé que component es de tipo Familia
                    ObtenerHijos((component as Familia).GetAll(), patentes);
                }
            }
        }

    }
}
