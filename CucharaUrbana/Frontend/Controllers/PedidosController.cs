using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PedidosController : Controller
    {

        IPedidosHelper pedidosHelper;


        public PedidosController(IPedidosHelper _pedidosHelper)

        {
            pedidosHelper = _pedidosHelper;
        }

        public ActionResult Index()
        {
           

            List<PedidosViewModel> pedidos = pedidosHelper.GetAll();

            return View(pedidos);
        }

        public ActionResult Details(int id)
        {
            PedidosViewModel pedidos = pedidosHelper.GetById(id);
            return View(pedidos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidosViewModel pedidos)
        {
            try
            {
                pedidosHelper.AddCategory(pedidos);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            PedidosViewModel pedidos = pedidosHelper.GetById(id);
            return View(pedidos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidosViewModel pedidos)
        {
            try
            {
                PedidosViewModel pedidosViewModel = pedidosHelper.EditPedidos(pedidos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            PedidosViewModel pedidos = pedidosHelper.GetById(id);
            return View(pedidos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PedidosViewModel pedidos)
        {
            try
            {
                pedidosHelper.DeletePedidos(pedidos.PedidosId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
