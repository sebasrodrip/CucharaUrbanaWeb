using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {

        IFacturaDAL _facturaDAL { get; }
        ICategoriumDAL _categoriumDAL { get; }      
        IProductoDAL _productoDAL { get; }
        IPedidoDAL _pedidosDAL { get; }
        IReservacionDAL _reservacionDAL { get; }

        ICarritoDAL _carritoDAL { get; }

        bool Complete();
    }
}
