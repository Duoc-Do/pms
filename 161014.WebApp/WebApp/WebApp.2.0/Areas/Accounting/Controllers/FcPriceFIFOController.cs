﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using WebApp.Areas.Accounting.DAL;

namespace WebApp.Areas.Accounting.Controllers
{
    public class FcPriceFIFOController : AppAccountingFunctionController
    {

        DAL.SenVietGeneralObject _dataobject;

        protected override IActionInvoker CreateActionInvoker()
        {
            _dataobject = new DAL.SenVietGeneralObject(Request, "FcPriceFIFO");
            this.InitData(_dataobject);
            return base.CreateActionInvoker();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Edit2");
        }

        public ActionResult Edit2()
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            return PartialView("Update2");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(FormCollection collection)
        {
            //var db = new Models.WebAppAccEntities(Services.GlobalVariant.GetConnection());
            var lockdate = DateTime.Parse(Services.GlobalVariant.GetSysOption()["LockDate"].ToString());

            var month = int.Parse(collection["month"].ToString());
            var year = int.Parse(collection["year"].ToString());

            if (year < lockdate.Year|| (year == lockdate.Year && month < lockdate.Month)) { ModelState.AddModelError("", "Ngày đã khóa sổ không được phép thực hiện."); }

            if (!ModelState.IsValid) return PartialView("Update2");

            try
            {
                _dataobject._db.Database.ExecuteSqlCommand(string.Format("sp_FcPriceFIFO {0},{1}", month, year));
                ViewBag.FcMessage = "Đã thành công";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return PartialView("Update2");
        }
    }
}