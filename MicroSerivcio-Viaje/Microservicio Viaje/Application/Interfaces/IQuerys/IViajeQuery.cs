using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IQuerys
{
    public interface IViajeQuery
    {
        IEnumerable<Viaje> GetAll();
        Viaje GetById(int viajeId);
        List<Pasajero> GetAllPasajerosById(int viajeId);
        IEnumerable<Viaje> GetViajes(string? tipo, string? fechaSalida, string? fechaLlegada);

        IEnumerable<Viaje> GetViajesWithLocation(List<int> viajesIds);
    }
}
