using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.ServicesExceptions
{
    public class BLLException : Exception
    {
        public bool IsBusinessException { get; set; }

        public BLLException(Exception exBase, bool isBusinessException = false) : base ("", exBase)
        {
            IsBusinessException = isBusinessException;
            
        }

        public BLLException(string message, bool isBusinessException = false) : base (message)
        {
            IsBusinessException = isBusinessException;
        }
    }
}
