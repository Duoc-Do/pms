using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,CRM")]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Khu vực quản trị.";

            return View();
        }
    }
}
