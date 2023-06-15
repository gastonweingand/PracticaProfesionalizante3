using System.Collections.Generic;
using System.Globalization;

namespace Services.DAL
{
    internal interface IIdiomaRepository
    {
        List<CultureInfo> GetIdiomasDisponibles();
        string Traducir(string key);
    }
}