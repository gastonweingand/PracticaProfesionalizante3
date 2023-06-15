using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Interfaces
{
    /// <summary>
    /// Interface para exponer el repositorio genérico
    /// </summary>
    /// <typeparam name="T">Tipo genérico que será implementado por los Implementations</typeparam>
    internal interface IGenericRepository<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(Guid id);

        List<T> GetAll();

        T GetById(Guid id);

    }
}
