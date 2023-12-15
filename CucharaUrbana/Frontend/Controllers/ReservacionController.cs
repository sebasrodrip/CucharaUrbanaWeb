﻿using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ReservacionController : Controller
    {

        IReservacionHelper reservacionHelper;

        public string Token { get; set; }

        public ReservacionController(IReservacionHelper _reservacionHelper)

        {
            reservacionHelper = _reservacionHelper;
        }



        // GET: ReservacionController
        [Authorize]
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            reservacionHelper.Token = Token;

            List<ReservacionViewModel> reservaciones = reservacionHelper.GetAll();

            return View(reservaciones);
        } 

        // GET: ReservacionController/Details/5
        public ActionResult Details(int id)
        {
            ReservacionViewModel reservacion = reservacionHelper.GetById(id);
            return View(reservacion);
        }

        // GET: ReservacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservacionViewModel reservacion)
        {
            try
            {
                reservacionHelper.AddReservacion(reservacion);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservacionController/Edit/5
        public ActionResult Edit(int id)
        {
            ReservacionViewModel reservacion = reservacionHelper.GetById(id);
            return View(reservacion);
        }

        // POST: ReservacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservacionViewModel reservacion)
        {
            try
            {
                ReservacionViewModel reservacionViewModel = reservacionHelper.EditReservacion(reservacion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservacionController/Delete/5
        public ActionResult Delete(int id)
        {
            ReservacionViewModel reservacion = reservacionHelper.GetById(id);
            return View(reservacion);
        }

        // POST: ReservacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReservacionViewModel reservacion)
        {
            try
            {
                reservacionHelper.DeleteReservacion(reservacion.ReservacionId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
