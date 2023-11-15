using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ReservacionController : Controller
    {



        IReservacionHelper reservacionHelper;
        IPedidosHelper pedidosHelper;


        public ReservacionController(IReservacionHelper _reservacionHelper
                                    , IPedidosHelper _pedidosHelper

                )
        {
            reservacionHelper = reservacionHelper;
            pedidosHelper = pedidosHelper;
        }

        public ActionResult Index()
        {
            List<ReservacionViewModel> reservaciones = reservacionHelper.GetAll();

            return View(reservaciones);
        }


        public ActionResult Details(int id)
        {


            ReservacionViewModel reservaciones = reservacionHelper.GetById(id);

            return View(reservaciones);
        }

    
        public ActionResult Create()
        {


            ReservacionViewModel reservaciones = new ReservacionViewModel();
            reservaciones.Pedidos= pedidosHelper.GetAll() ;  



            return View(reservaciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservacionViewModel reservacion)
        {
            try
            {
                reservacionHelper.AddProduct(reservacion);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ReservacionViewModel reservacion = reservacionHelper.GetById(id);
            reservacion.Productos = productoHelper.GetAll();

            return View(reservacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservacionViewModel reservacion)
        {
            try
            {

                reservacionHelper.EdiProduct(reservacion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            ReservacionViewModel reservacion = reservacionHelper.GetById(id);

            return View(reservacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReservacionViewModel reservacion)
        {
            try
            {
                reservacionHelper.DeleteReservacion(reservacion.ReservacionID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
