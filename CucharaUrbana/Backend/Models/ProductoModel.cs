namespace Backend.Models
{
    public class ProductoModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CategoriaId { get; set; }
        public decimal? Precio { get; set; }
    }
}
