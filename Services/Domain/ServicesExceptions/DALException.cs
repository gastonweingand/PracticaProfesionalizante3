using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.ServicesExceptions
{
    public class DALException : Exception
    {
        //public DALException() : base()
        //{
        //    HelpLink = ""; //Se puede referenciar a documentación en la nube o localhost
        //}

        public DALException(Exception exBase) : base("Exception generado por Acceso datos".Traducir(), exBase)
        {

        }
    }
}
