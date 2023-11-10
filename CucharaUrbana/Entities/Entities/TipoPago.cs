using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
            Facturas = new HashSet<Factura>();
        }

        public int MetodoPagoId { get; set; }
        public string TipoPago1 { get; set; } = null!;

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
