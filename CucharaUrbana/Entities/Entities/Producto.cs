using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
            DetalleFacturas = new HashSet<DetalleFactura>();
            Pedidos = new HashSet<Pedido>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CategoriaId { get; set; }
        public decimal? Precio { get; set; }

        public virtual Categorium? Categoria { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
