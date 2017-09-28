using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApp.Areas.PMSContracts.Controllers
{
    public class GeneralController : Controller
    {
        //
        // GET: /PMSContracts/General/
        PMSDataContext objContext = new PMSDataContext();
        public ActionResult Index()
        {
            var tbGeneral = objContext.CONTRACTS_CONDITIONS_GENERAL.OrderByDescending(s => s.ContractID).Take(10).ToList();
            return View(tbGeneral);
        }
        public ActionResult Import()
        {
            return View();
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbGeneral = objContext.CONTRACTS_CONDITIONS_GENERAL.Find(id);
            if (tbGeneral == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneral);
        }
        //
        // GET: /PMSContracts/General/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PMSContracts/General/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PMSContracts/General/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PMSContracts/General/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PMSContracts/General/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PMSContracts/General/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
