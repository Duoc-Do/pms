using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PMSContract.Controllers
{
    public class ContractController : Controller
    {
        DataFunction db = new DataFunction();
        const int recordsPerPage = 48;
        // GET: Contract
        [System.Web.Http.HttpGet]
        public ActionResult Index()
        {
            return View(db.ViewList());
        }
        [System.Web.Http.HttpGet]
        public ActionResult testpaging(int page = 1, int pageSize = 200, int isjson = 0)
        {
            DataContext db = new DataContext();
            var skipRecords = page * pageSize;
            var loaddb = db.CONTRACTS.Where(x => x.ContractCode != null)
                .OrderBy(x => x.ContractID).Skip(skipRecords).Take(pageSize).ToList();
            if (isjson == 1)
            {
                return Json(new { rows = loaddb, status = 1, message = "completed" }, JsonRequestBehavior.AllowGet);
            }


            if (isjson == 2)
            {
                return PartialView("_ContractPartial", loaddb);
            }

            ViewBag.aa = "Contract List";

            return View("testpaging", loaddb);

        }
        public ActionResult Paging(int? id)
        {
            DataContext db = new DataContext();
            var page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ContractPartial", GetPaginatedContracts(page));
            }
            return View("Paging", db.CONTRACTS.Where(x => x.ContractCode != null).Take(recordsPerPage));
        }
        public List<ContractModel> GetPaginatedContracts(int page = 1)
        {
            DataContext db = new DataContext();
            var skipRecords = page * recordsPerPage;

            return db.CONTRACTS.Where(x => x.ContractCode != null)
                .OrderBy(x => x.ContractID)
                .Skip(skipRecords)
                .Take(recordsPerPage).ToList();
        }
        /*   [System.Web.Http.HttpGet, System.Web.Http.Route("Create")]
        public ActionResult Create()
        {
            var model = new ContractModel() { ModifyDate = DateTime.Now };
            return View(model);
        }
        [System.Web.Http.HttpPost, System.Web.Http.Route("Create")]
        public ActionResult Create(ContractModel contract)
        {
            if (ModelState.IsValid)
            {

                long id = db.Insert(contract);
                if (id > 0)
                {
                    return RedirectToAction("Create", "Contract");
                }
                else
                {
                    ModelState.AddModelError("", "Them thanh cong");
                }
            }

            return View("Create");
        }*/
  

          public ActionResult Create(ContractModel contract)
          {
              return View("Create");
          }
        public ActionResult Insert(ContractModel contract)
        {

            if (ModelState.IsValid)
            {

                long id = db.Insert(contract);
                if (id > 0)
                {
                    return RedirectToAction("testpaging", "Contract");
                }
                else
                {
                    ModelState.AddModelError("", "Completeted");
                }

            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            DataContext db = new DataContext();
            var ct = db.CONTRACTS.Find(id);
            return View(ct);
        }
        public ActionResult Update(ContractModel contract)
        {

            if (ModelState.IsValid)
            {

                var result = db.Update(contract);
                if (result)
                {
                    return RedirectToAction("Index", "Contract");
                }
                else
                {
                    ModelState.AddModelError("", "Updated");
                }

            }
            return View("Index");
        }
    }
}