using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Accounting.Models;

namespace WebApp.Areas.Accounting.Controllers
{
    [Authorize]
    public class ResHomeController : AppAccountingController
    {
        //
        // GET: /Accounting/Home/
        public ActionResult Index()
        {
            return PartialView();
        }

        //
        // GET: /Accounting/Home/
        public ActionResult Kitchen()
        {
            return PartialView();
        }

    }
}
