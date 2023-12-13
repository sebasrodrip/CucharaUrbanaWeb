namespace Frontend.Models
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? CategoriaId { get; set; }
        public IEnumerable<CategoriumViewModel> Categorium { get; set; }
        public decimal? Precio { get; set; }
    }
}
