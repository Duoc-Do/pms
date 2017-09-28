﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using WebApp.Areas.Accounting.DAL;

namespace WebApp.Areas.Accounting.Controllers
{
    public class AppEmployeeBalanceTableController : AppAccountingListController
    {
        DAL.AppEmployeeBalanceTable _dataobject;

        protected override IActionInvoker CreateActionInvoker()
        {
            _dataobject = new DAL.AppEmployeeBalanceTable(Request);
            this.InitData(_dataobject);
            return base.CreateActionInvoker();
        }

        public ActionResult AutoComplete()
        {
            DAL.AppEmployeeBalanceTable _dataobject = new DAL.AppEmployeeBalanceTable(Request);
            return Json(_dataobject.AutoComplete(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FieldChange()
        {
            DAL.AppEmployeeBalanceTable _dataobject = new DAL.AppEmployeeBalanceTable(Request);
            return Json(_dataobject.FieldChange(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return PartialView(this._indexview, _dataobject.GetData());
        }

        public ActionResult Create(int? id)
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            return PartialView(this._updateview, _dataobject.GetNew(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.AppEmployeeBalanceView collection)
        {
            try
            {
                int outputId = _dataobject.Insert(collection);
                return RedirectToAction(this.ActionReturn());
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return PartialView(this._updateview, collection);
            }
        }

        public ActionResult Edit(int id)
        {
            if (!_dataobject.sysbusinessrole.IsEdit) return PartialView(this._roleview);
            return PartialView(this._updateview, _dataobject.GetEdit(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.AppEmployeeBalanceView collection)
        {
            try
            {
                int outputId = _dataobject.Update(collection);
                return RedirectToAction(this.ActionReturn());
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return PartialView(this._updateview, collection);
            }
        }

        public ActionResult Delete(int id)
        {
            if (!_dataobject.sysbusinessrole.IsDelete) return PartialView(this._roleview);
            return PartialView(this._deleteview, _dataobject.GetDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
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