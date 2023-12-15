using Entities.Entities;
using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Frontend.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {



        IProductoHelper productoHelper;
        ICategoriumHelper categoriaHelper;
        ICarritoHelper carritoHelper;

        public string Token { get; set; }

        public ProductoController(IProductoHelper _productoHelper
                                   ,ICategoriumHelper _categoriaHelper, ICarritoHelper _carritoHelper
                )
        {
            productoHelper = _productoHelper;
            categoriaHelper = _categoriaHelper;
            carritoHelper = _carritoHelper;
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            productoHelper.Token = Token;

            List<ProductoViewModel> productos = productoHelper.GetAll();

            return View(productos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {


            ProductoViewModel producto = productoHelper.GetById(id);

            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {

            ProductoViewModel producto = new ProductoViewModel();
            producto.Categorium = categoriaHelper.GetAll();


            return View(producto);
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {
            try
            {
                productoHelper.AddProducto(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarAlCarrito(int productoId)
        {
            try
            {
                // Obtener el producto por ID
                ProductoViewModel producto = productoHelper.GetById(productoId);

                // Crear un elemento del carrito y asignar valores
                CarritoViewModel carritoItem = new CarritoViewModel
                {
                    ProductoId = producto.ProductoId,
                    Cantidad = 1, // Puedes ajustar la cantidad según tus necesidades
                    PrecioUnitario = producto.Precio
                    // Otros campos del carrito si los tienes
                };

                // Agregar el elemento al carrito
                carritoHelper.AddCarrito(carritoItem);

                // Redirigir a la acción Index del controlador Carrito
                return RedirectToAction("Index", "Carrito");
            }
            catch
            {
                // Manejar cualquier excepción
                return View("Error");
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoViewModel producto = productoHelper.GetById(id);
            producto.Categorium = categoriaHelper.GetAll();

            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            try
            {

                productoHelper.EditProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoViewModel producto = productoHelper.GetById(id);

            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoViewModel producto)
        {
            try
            {
                productoHelper.DeleteProducto(producto.ProductoId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
