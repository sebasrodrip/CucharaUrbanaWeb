using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System;
using System.Collections.Generic;

namespace Frontend.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        IPedidoHelper pedidoHelper;
        IProductoHelper productoHelper; // Asegúrate de tener este helper si es necesario



        public PedidoController(IPedidoHelper _pedidoHelper, IProductoHelper _productoHelper)
        {
            pedidoHelper = _pedidoHelper;
            productoHelper = _productoHelper;
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
            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Productos = productoHelper.GetAll(); // Ajusta esto según tu lógica

            return View(pedido);
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
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                return View();
            }
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            PedidoViewModel pedido = pedidoHelper.GetById(id);
            pedido.Productos = productoHelper.GetAll(); // Ajusta esto según tu lógica

            return View(pedido);
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedido)
        {
            try
            {
                pedidoHelper.EditPedido(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
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
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                return View();
            }
        }
    }
}
