using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CategoriumController : Controller
    {

        ICategoriumHelper categoriumHelper;


        public CategoriumController(ICategoriumHelper _categoriumHelper)

        {
            categoriumHelper = _categoriumHelper;
        }



        // GET: CategoriumController
        public ActionResult Index()
        {
           

            List<CategoriumViewModel> categories = categoriumHelper.GetAll();

            return View(categories);
        }

        // GET: CategoriumController/Details/5
        public ActionResult Details(int id)
        {
            CategoriumViewModel categorium = categoriumHelper.GetById(id);
            return View(categorium);
        }

        // GET: CategoriumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriumViewModel categorium)
        {
            try
            {
                categoriumHelper.AddCategorium(categorium);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriumViewModel categorium = categoriumHelper.GetById(id);
            return View(categorium);
        }

        // POST: CategoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriumViewModel categorium)
        {
            try
            {
                CategoriumViewModel categoriumViewModel = categoriumHelper.EditCategorium(categorium);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriumViewModel categorium = categoriumHelper.GetById(id);
            return View(categorium);
        }

        // POST: CategoriumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriumViewModel categorium)
        {
            try
            {
                categoriumHelper.DeleteCategorium(categorium.CategoriaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
