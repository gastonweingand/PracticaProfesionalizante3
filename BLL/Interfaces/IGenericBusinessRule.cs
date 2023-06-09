using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericBusinessRule <T>
    {
        void Add(T obj);

        void Update(T obj);

        List<T> GetAll();
    }
}
