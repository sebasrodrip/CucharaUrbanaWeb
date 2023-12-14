using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Frontend.Controllers
{
    [Authorize]
    public class FacturaController : Controller
    {

        IFacturaHelper facturaHelper;
        ICarritoHelper carritoHelper;
        /*ITipoPagoHelper tipopagoHelper;*/

        public string Token { get; set; }

        public FacturaController(IFacturaHelper _facturaHelper
                                   , ICarritoHelper _carritoHelper
                )
        {
            facturaHelper = _facturaHelper;
            carritoHelper = _carritoHelper;
        }


        // GET: FacturaController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            facturaHelper.Token = Token;

            List<FacturaViewModel> facturas = facturaHelper.GetAll();

            return View(facturas);
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {

            FacturaViewModel factura = facturaHelper.GetById(id);

            return View(factura);
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {


            FacturaViewModel factura = new FacturaViewModel();
            factura.Carrito = carritoHelper.GetAll();



            return View(factura);
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel factura)
        {
            try
            {
                facturaHelper.AddFactura(factura);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            FacturaViewModel factura = facturaHelper.GetById(id);
            factura.Carrito = carritoHelper.GetAll();

            return View(factura);
        }


        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturaViewModel factura)
        {
            try
            {

                facturaHelper.EditFactura(factura);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            FacturaViewModel factura = facturaHelper.GetById(id);

            return View(factura);
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FacturaViewModel factura)
        {
            try
            {
                facturaHelper.DeleteFactura(factura.FacturaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
