using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IQuerys
{
    public interface IPasajeroQuery
    {
        IEnumerable<Pasajero> GetAll();
        Pasajero GetById(int pasajeroId);

    }
}
