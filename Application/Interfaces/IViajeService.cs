﻿using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeService
    {
        ViajeResponse GetViajeById(int viajeId);
        List<Viaje> GetViajeList();
        List<ViajeResponse> GetViajeListFilters(string tipo, string fechaSalida, string fechaLlegada, int empresaId);
        ViajeResponse CreateViaje(ViajeRequest viaje);
        ViajeResponse RemoveViaje(int viajeId);
        ViajeResponse UpdateViaje(int viajeId, ViajeRequest request);
    }
}
