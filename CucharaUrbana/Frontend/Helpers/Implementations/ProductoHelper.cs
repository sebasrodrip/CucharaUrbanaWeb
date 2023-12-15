using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Helpers.Implementations;

public class ProductoHelper : IProductoHelper
{
    public string Token { get; set; }
    IServiceRepository _repository;

    public ProductoHelper(IServiceRepository serviceRepository)
    {
        _repository = serviceRepository;
    }

    public ProductoViewModel AddProducto(ProductoViewModel ProductoViewModel)
    {
        ProductoViewModel producto = new ProductoViewModel();
        HttpResponseMessage responseMessage = _repository.PostResponse("api/Producto", ProductoViewModel);
        if (responseMessage != null)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);
        }

        return producto;
    }

    public void DeleteProducto(int id)
    {
        HttpResponseMessage responseMessage = _repository.DeleteResponse("api/Producto/" + id.ToString());
        if (responseMessage != null)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
        }
    }

    public ProductoViewModel EditProducto(ProductoViewModel ProductoViewModel)
    {
        ProductoViewModel producto = new ProductoViewModel();
        HttpResponseMessage responseMessage = _repository.PutResponse("api/Producto", ProductoViewModel);
        if (responseMessage != null)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);
        }
        return producto;
    }

    public List<ProductoViewModel> GetAll()
    {
        List<ProductoViewModel> lista = new List<ProductoViewModel>();

        HttpResponseMessage responseMessage = _repository.GetResponse("api/Producto");
        if (responseMessage != null)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<ProductoViewModel>>(content);
        }
        return lista;
    }

    public ProductoViewModel GetById(int id)
    {
        ProductoViewModel Producto = new ProductoViewModel();
        HttpResponseMessage responseMessage = _repository.GetResponse("api/Producto/" + id.ToString());
        if (responseMessage != null)
        {
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);
        }

        return Producto;
    }
}
