using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Factura
    {
        public int FacturaId { get; set; }
        public string? Detalle { get; set; }
        public int? CarritoId { get; set; }
        public decimal Subtotal { get; set; }
        public int? TipoPagoId { get; set; }

        public virtual Carrito? Carrito { get; set; }
        public virtual TipoPago? TipoPago { get; set; }
    }
}
