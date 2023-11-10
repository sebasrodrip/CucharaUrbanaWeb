using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int FacturaId { get; set; }
        public DateTime FechaFactura { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }
        public int? PagoId { get; set; }
        public int? MetodoPagoId { get; set; }
        public string? EstadoPago { get; set; }
        public int? TipoPagoId { get; set; }

        public virtual TipoPago? MetodoPago { get; set; }
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
