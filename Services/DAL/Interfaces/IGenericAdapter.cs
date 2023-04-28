using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Interfaces
{
    interface IGenericAdapter<T>
    {
        T Adapt(object[] obj);
    }
}
