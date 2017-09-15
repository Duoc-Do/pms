using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSContract.Controllers
{  
    public class ContractController : Controller
    {
        DataFunction db = new DataFunction();
        // GET: Contract
        public ActionResult Index()
        {
            return View(db.ViewList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ContractModel() { ModifyDate = DateTime.Now };
            return View(model);
        }
        [HttpPost]
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