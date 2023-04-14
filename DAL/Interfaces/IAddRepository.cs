using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAddRepository<T>
    {
        /// <summary>
        /// Método genérico para agregar un objeto a un Repositorio
        /// </summary>
        /// <param name="obj">Intancia esperada...</param>   
        void Add(T obj);
    }
}
