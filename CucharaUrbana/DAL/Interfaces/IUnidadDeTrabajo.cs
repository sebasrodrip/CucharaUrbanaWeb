using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {

        IPedidosDAL _pedidosDAL { get; }
        IReservacionDAL _reservacionDAL { get; }
        bool Complete();
    }
}
