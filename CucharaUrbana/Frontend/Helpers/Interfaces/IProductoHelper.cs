using Frontend.Models;

namespace Frontend.Helpers.Interfaces
{
    public interface IProductoHelper
    {

        List<ProductoViewModel> GetAll();
        ProductoViewModel GetById(int id);
        ProductoViewModel AddProducto(ProductoViewModel ProductoViewModel);
        ProductoViewModel EdiProducto(ProductoViewModel ProductoViewModel);

        void DeleteProducto(int id);
    }
}
