using Entities.Entities;

namespace Backend.Models
{
    public class FacturaModel
    {

        public int FacturaId { get; set; }
        public string? Detalle { get; set; }
        public int? CarritoId { get; set; }
        public decimal Subtotal { get; set; }
        public int? TipoPagoId { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Carrito? Carrito { get; set; }
        public virtual TipoPago? TipoPago { get; set; }

    }
}
