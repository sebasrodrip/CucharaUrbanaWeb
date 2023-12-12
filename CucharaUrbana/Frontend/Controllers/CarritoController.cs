using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CarritoController : Controller
    {

        ICarritoHelper carritoHelper;

        public CarritoController(ICarritoHelper _carritoHelper

                )
        {
            carritoHelper = _carritoHelper;

        }
        // GET: CarritoController
        public ActionResult Index()
        {
            List<CarritoViewModel> carritos = carritoHelper.GetAll();

            return View(carritos);
        }

        // GET: CarritoController/Details/5
        public ActionResult Details(int id)
        {


            CarritoViewModel carrito = carritoHelper.GetById(id);

            return View(carrito);
        }

        // GET: CarritoController/Create
        public ActionResult Create()
        {


            CarritoViewModel carrito = new CarritoViewModel(); 



            return View(carrito);
        }

        // POST: CarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarritoViewModel carrito)
        {
            try
            {
                carritoHelper.AddCarrito(carrito);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            CarritoViewModel carrito = carritoHelper.GetById(id);

            return View(carrito);
        }

        // POST: CarritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarritoViewModel carrito)
        {
            try
            {

                carritoHelper.EditCarrito(carrito);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarritoController/Delete/5
        public ActionResult Delete(int id)
        {
            CarritoViewModel carrito = carritoHelper.GetById(id);

            return View(carrito);
        }

        // POST: CarritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarritoViewModel carrito)
        {
            try
            {
                carritoHelper.DeleteCarrito(carrito.CarritoId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
