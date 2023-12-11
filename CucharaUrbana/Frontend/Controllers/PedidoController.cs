using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class PedidoController : Controller
    {

        IPedidoHelper pedidoHelper;


        public PedidoController(IPedidoHelper _pedidoHelper)

        {
            pedidoHelper = _pedidoHelper;
        }



        // GET: PedidoController
        public ActionResult Index()
        {


            List<PedidoViewModel> pedidos = pedidoHelper.GetAll();

            return View(pedidos);
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            PedidoViewModel pedido = pedidoHelper.GetById(id);
            return View(pedido);
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedido)
        {
            try
            {
                pedidoHelper.AddPedido(pedido);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            PedidoViewModel pedido = pedidoHelper.GetById(id);
            return View(pedido);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedido)
        {
            try
            {
                PedidoViewModel pedidoViewModel = pedidoHelper.EditPedido(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            PedidoViewModel pedido = pedidoHelper.GetById(id);
            return View(pedido);
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PedidoViewModel pedido)
        {
            try
            {
                pedidoHelper.DeletePedido(pedido.PedidoId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
