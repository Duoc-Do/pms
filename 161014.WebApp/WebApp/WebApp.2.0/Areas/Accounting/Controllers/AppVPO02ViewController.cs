﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Accounting.Services;
using WebApp.Areas.Accounting.DAL;

namespace WebApp.Areas.Accounting.Controllers
{
    public class AppVPO02ViewController : AppAccountingVoucherController
    {
        DAL.AppVPO02View _dataobject;

        protected override IActionInvoker CreateActionInvoker()
        {
            _dataobject = new DAL.AppVPO02View(Request);
            this.InitData(_dataobject);
            return base.CreateActionInvoker();
        }
        public ActionResult AutoComplete()
        {
            return Json(_dataobject.AutoComplete(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult FieldChange()
        {
            return Json(_dataobject.FieldChange(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Print(long id, int sysreportid, string reporttype = "PDF")
        {
            return Services.Report.Print.PrintVoucher<Models.AppVPO02PrintView>(this, id, sysreportid, reporttype, new System.Collections.Hashtable());
        }
        public ActionResult Index()
        {
            return PartialView(_dataobject.GetData());
            //return PartialView(this._indexview, _dataobject.GetData());
        }

        public ActionResult CreateBy(int createtype)
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            return PartialView(createtype);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBy(FormCollection collection)
        {
            var DateFrom = DateTime.Parse(collection["DateFrom"].ToString());
            var DateTo = DateTime.Parse(collection["DateTo"].ToString());
            var VoucherNumber = collection["VoucherNumber"];
            var datavoucher =  _dataobject._db.AppDocumentTables.Where(m => m.VoucherDate >= DateFrom && m.VoucherDate <= DateTo && m.VoucherNumber == VoucherNumber).FirstOrDefault();
            long DocumentID = 0;
            if (datavoucher!=null)
            {
                DocumentID = datavoucher.DocumentID;
            }

            // TODO: Add insert logic here
            return RedirectToAction("Create", new { action_return = "Index", documentid = DocumentID });

        }


        public ActionResult Create(long? id)
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            if (Request.Params["documentid"] != null)
            {
                var dataline = _dataobject._db.Database.SqlQuery<Models.AppVPO02LineView>(string.Format("sp_AppVPO0201LineViewSByKey2 'ParentID={0}'", Request.Params["documentid"])).ToList();

                var newobject = _dataobject.GetNew(id);
                newobject.AppVPO02LineViews = dataline;
                return PartialView(this._updateview, newobject);
            }
            return PartialView(this._updateview, _dataobject.GetNew(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.AppVPO02View collection)
        {
            // TODO: Add insert logic here
            try
            {
                long outputId = _dataobject.Insert(collection);
                return RedirectToAction(this.ActionReturn());
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return PartialView(this._updateview, collection);
            }

        }
        public ActionResult Edit(long id)
        {
            if (!_dataobject.sysbusinessrole.IsEdit) return PartialView(this._roleview);
            return PartialView(this._updateview, _dataobject.GetEdit(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, Models.AppVPO02View collection)
        {
            // TODO: Add insert logic here
            try
            {
                long outputId = _dataobject.Update(collection);
                return RedirectToAction(this.ActionReturn());
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return PartialView(this._updateview, collection);
            }
        }

        public ActionResult Delete(long id)
        {
            if (!_dataobject.sysbusinessrole.IsDelete) return PartialView(this._roleview);
            return PartialView(this._deleteview, _dataobject.GetDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                _dataobject.Delete(id);
                return RedirectToAction(this.ActionReturn());
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return PartialView(this._deleteview, _dataobject.GetDelete(id));
            }
        }
    }
}

//----- Phần Update
