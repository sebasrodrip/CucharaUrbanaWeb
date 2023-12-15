namespace Frontend.Models
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int MesaPedido { get; set; }
        public string? EstadoPedido { get; set; }
        public int? ProductoId { get; set; }
        public IEnumerable<ProductoViewModel> Productos { get; set; }
    }
}
