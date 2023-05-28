using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IApi
{
    public interface IDestinoApi
    {
        dynamic GetDestinoById(int destinoId);
    }
}
