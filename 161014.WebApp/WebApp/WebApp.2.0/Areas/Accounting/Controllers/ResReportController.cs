using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Accounting.Models;
using WebApp.Areas.Accounting.Services;

namespace WebApp.Areas.Accounting.Controllers
{
    [Authorize]
    public class ResReportController : AppAccountingController
    {
        //
        // GET: /Accounting/Home/
        public ActionResult Index()
        {
            return PartialView();
        }


    }
}
