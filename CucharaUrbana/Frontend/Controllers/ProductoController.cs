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
        // ICategoriumHelper categoriaHelper;

        public string Token { get; set; }

        public ProductoController(IProductoHelper _productoHelper
                                  //  , ICategoriumHelper _categoriaHelper
                )
        {
            productoHelper = _productoHelper;
           // categoriaHelper = _categoriaHelper;
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
            //producto.Categorium = categoriaHelper.GetAll();



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

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoViewModel producto = productoHelper.GetById(id);
           // producto.Categorium = categoriaHelper.GetAll();

            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            try
            {

                productoHelper.EdiProducto(producto);
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
