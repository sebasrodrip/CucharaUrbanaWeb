using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FacturaController : Controller
    {

        IFacturaHelper facturaHelper;


        public FacturaController(IFacturaHelper _facturaHelper)

        {
            facturaHelper = _facturaHelper;
        }



        // GET: FacturaController
        public ActionResult Index()
        {


            List<FacturaViewModel> categories = facturaHelper.GetAll();

            return View(categories);
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
            return View();
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
            return View(factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturaViewModel factura)
        {
            try
            {
                FacturaViewModel facturaViewModel = facturaHelper.EditFactura(factura);
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
