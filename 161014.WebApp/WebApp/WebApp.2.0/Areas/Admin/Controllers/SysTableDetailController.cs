﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using WebApp.Areas.Admin.DAL;

namespace WebApp.Areas.Admin.Controllers
{
    public class SysTableDetailController : AppAdminListController
    {
        DAL.SysTableDetail _dataobject;

        protected override IActionInvoker CreateActionInvoker()
        {
            _dataobject = new DAL.SysTableDetail(Request);
            this.InitData(_dataobject);
            return base.CreateActionInvoker();
        }

        public ActionResult AutoComplete()
        {
            DAL.SysTableDetail _dataobject = new DAL.SysTableDetail(Request);
            return Json(_dataobject.AutoComplete(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FieldChange()
        {
            DAL.SysTableDetail _dataobject = new DAL.SysTableDetail(Request);
            return Json(_dataobject.FieldChange(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string tablename)
        {
            if (string.IsNullOrEmpty(tablename))
            {
                return PartialView(this._indexview,_dataobject.GetData());

            }
            return PartialView(this._indexview, _dataobject.GetData(tablename));
        }


        [HttpPost]
        public ActionResult Update(string tablename,string[] columns, bool[] columnvalues,int[] columnorders)
        {
            try
            {
                for (int i = 0; i < columns.Count(); i++)
                {
                    var row = _dataobject.GetEdit(tablename, columns[i]);
                    if (row!=null)
                    {
                        row.GridViewShow = columnvalues[i];
                        row.GridViewOrder = columnorders[i];
                        int outputId = _dataobject.Update(row);
                    }
                }
                return Json(new { ketqua = "success" });
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return Json(new { ketqua = "fail",message=ex.Message });
            }
        }

        public ActionResult Create(string TableName, string ColumnName)
        {
            //if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);        
            return PartialView(this._updateview, _dataobject.GetNew(TableName, ColumnName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.SysTableDetail collection)
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

        public ActionResult Edit(string TableName, string ColumnName)
        {
            //if (!_dataobject.sysbusinessrole.IsEdit) return PartialView(this._roleview);        
            return PartialView(this._updateview, _dataobject.GetEdit(TableName, ColumnName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string TableName, string ColumnName, Models.SysTableDetail collection)
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

        public ActionResult Delete(string TableName, string ColumnName)
        {
            //if (!_dataobject.sysbusinessrole.IsDelete) return PartialView(this._roleview);        
            return PartialView(this._deleteview, _dataobject.GetDelete( TableName,  ColumnName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string TableName, string ColumnName, FormCollection collection)
        {
            try
            {
                _dataobject.Delete( TableName,  ColumnName);
                return RedirectToAction(this.ActionReturn()); 
            }
            catch (Exception ex)
            {
                Services.GlobalErrors.Parse(ModelState, _dataobject.Errors, ex);
                return PartialView(this._deleteview, _dataobject.GetDelete( TableName,  ColumnName));
            }
        }
    }
}