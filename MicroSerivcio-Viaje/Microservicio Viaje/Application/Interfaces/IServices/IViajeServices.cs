using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IViajeServices
    {
        ViajeResponse CreateViaje(ViajeRequest viajeRequest);
        IEnumerable<ViajeResponse> GetAllViajes();
        ViajeResponse GetViajeById(int viajeId);
        IEnumerable<ViajeResponse> GetViajes(string? tipo, DateTime? fechaSalida, DateTime? fechaLlegada);
        ViajeResponse AddViaje(Viaje viaje);
        ViajeResponse UpdateViaje(int viajeId, ViajeRequest viajeRequest);
        ViajeResponse DeleteViaje(int viajeId);

        List<GetAllPasajerosByIdResponse> GetAllPasajerosById(int viajeId);
    }
}
