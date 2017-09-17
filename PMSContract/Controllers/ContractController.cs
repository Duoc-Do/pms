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
        // GET: Contract
        [System.Web.Http.HttpGet]
        public ActionResult Index()
        {
            return View(db.ViewList());
        }
        [System.Web.Http.HttpGet]
        public ActionResult Paging(int page = 1,int pageSize=10,int isjson=0)
        {
            DataContext db = new DataContext();
            var loaddb = db.CONTRACTS.OrderByDescending(s=>s.ContractID).Skip(page).Take(pageSize).ToList();
            if (isjson==1)
            {
                return Json(new { rows = loaddb, status = 1, message = "completed" }, JsonRequestBehavior.AllowGet);
            }
            

            if (isjson == 2)
            {
                return PartialView(loaddb);
            }

            ViewBag.aa = "dsghfjdshfgdjhfg";

            return View(loaddb);
        }
        public ActionResult PageScroll(int? id)
        {
            DataContext db = new DataContext();
            var page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Contracts", GetPaginatedContracts(page));
            }
            return View("Index", db.CONTRACTS.Where(x => x.ContractID != null).Take(recordsPerPage));
        }

        [System.Web.Http.HttpGet]
        public ActionResult Create()
        {
            var model = new ContractModel() { ModifyDate = DateTime.Now };
            return View(model);
        }
        [System.Web.Http.HttpPost]
        public ActionResult Create(ContractModel contract)
        {
          
            if (ModelState.IsValid)
            {
              
                long id = db.Insert(contract);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Contract");
                }
                else
                {
                    ModelState.AddModelError("", "Them thanh cong");
                }
            }

            return View("Index");
        }

    }
}