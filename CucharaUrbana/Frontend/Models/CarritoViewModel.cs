namespace Frontend.Models
{
    public class CarritoViewModel
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public IEnumerable<ProductoViewModel> Productos { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
