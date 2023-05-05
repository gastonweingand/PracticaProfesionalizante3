using Services.Domain.ServicesExceptions;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessExceptions
{
    public class ClienteNoExisteException : BLLException
    {
        public ClienteNoExisteException(): base("El cliente no existe".Traducir() , true)
        {
            
        }
    }
}
