using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IProductoHelper
    {
        string Token { get; set; }
        List<ProductoViewModel> GetAll();
        ProductoViewModel GetById(int id);
        ProductoViewModel AddProducto(ProductoViewModel ProductoViewModel);
        ProductoViewModel EditProducto(ProductoViewModel ProductoViewModel);
        void DeleteProducto(int id);
    }
}
