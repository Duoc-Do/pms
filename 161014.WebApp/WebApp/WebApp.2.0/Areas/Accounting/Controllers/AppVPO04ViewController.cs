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
    public class AppVPO04ViewController : AppAccountingVoucherController
    {
        DAL.AppVPO04View _dataobject;

        protected override IActionInvoker CreateActionInvoker()
        {
            _dataobject = new DAL.AppVPO04View(Request);
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
            return Services.Report.Print.PrintVoucher<Models.AppVPO04PrintView>(this, id, sysreportid, reporttype, new System.Collections.Hashtable());
        }
        public ActionResult Index()
        {
            return PartialView(this._indexview, _dataobject.GetData());
        }
        public ActionResult Create(long? id)
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            return PartialView(this._updateview, _dataobject.GetNew(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.AppVPO04View collection)
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
        public ActionResult Edit(long id, Models.AppVPO04View collection)
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

//@Html.svHiddenFor(model => model.VoucherID)
//@Html.svHiddenFor(model => model.ParentID)
//@Html.svHiddenFor(model => model.DocumentID)
//@Html.svHiddenFor(model => model.CustomerID)
//@Html.svHiddenFor(model => model.CurrencyID)
//@Html.svHiddenFor(model => model.AccountDebitID)
//@Html.svHiddenFor(model => model.AccountCreditID)
//@Html.bsEditorFor(model => model.VoucherNumber)
//@Html.bsEditorFor(model => model.VoucherName)
//@Html.bsEditorFor(model => model.VoucherDate)
//@Html.bsEditorFor(model => model.VoucherCode)
//@Html.bsEditorFor(model => model.SumTotalFC)
//@Html.bsEditorFor(model => model.SumTotal)
//@Html.bsEditorFor(model => model.SumAmountVATFC)
//@Html.bsEditorFor(model => model.SumAmountVAT)
//@Html.bsEditorFor(model => model.SumAmountFC)
//@Html.bsEditorFor(model => model.SumAmount)
//@Html.bsEditorFor(model => model.PostType)
//@Html.bsEditorFor(model => model.IsoCode)
//@Html.bsEditorFor(model => model.ExchangeRate)
//@Html.bsEditorFor(model => model.DueDate)
//@Html.bsEditorFor(model => model.DisplayNumberDebit)
//@Html.bsEditorFor(model => model.DisplayNumberCredit)
//@Html.bsEditorFor(model => model.Description)
//@Html.bsEditorFor(model => model.CustomerName)
//@Html.bsEditorFor(model => model.CustomerCode)
//@Html.bsEditorFor(model => model.Contact)
//@Html.bsEditorFor(model => model.Address)