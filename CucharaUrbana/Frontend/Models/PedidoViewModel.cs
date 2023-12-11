using Entities.Entities;

namespace Frontend.Models
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int MesaPedido { get; set; }
        public int? UsuarioId { get; set; }
        public string? EstadoPedido { get; set; }
        public int? ProductoId { get; set; }

        public virtual Producto? Producto { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
