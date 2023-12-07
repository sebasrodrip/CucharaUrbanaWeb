namespace Frontend.Models
{
    public class FacturaViewModel
    {

        public int FacturaId { get; set; }
        public DateTime FechaFactura { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }
        public int? PagoId { get; set; }
        public int? MetodoPagoId { get; set; }
        public string? EstadoPago { get; set; }
        public int? TipoPagoId { get; set; }
    }
}
