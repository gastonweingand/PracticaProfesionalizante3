using System.Collections.Generic;
using System.Globalization;

namespace Services.DAL
{
    public interface IIdiomaRepository
    {
        List<CultureInfo> GetIdiomasDisponibles();
        string Traducir(string key);
    }
}