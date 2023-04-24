using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.BusinessExceptions
{
    class PalabraNoEncontradaExcepcion : Exception
    {
        public PalabraNoEncontradaExcepcion() : base("La palabra no ha sido encontrada")
        {
            
        }
    }
}
