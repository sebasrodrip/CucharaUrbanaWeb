using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class DetalleFactura
    {
        public int DetalleId { get; set; }
        public int? FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public string? NombreProducto { get; set; }
        public int? TipoPagoId { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual Producto Producto { get; set; } = null!;
        public virtual TipoPago? TipoPago { get; set; }
    }
}
