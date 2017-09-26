using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using WebApp.Areas.Accounting.Services;
using WebApp.Areas.Accounting.DAL;

namespace WebApp.Areas.Accounting.Controllers
{
    public class RpGLJournal1Controller : AppAccountingReportController
    {
        DAL.RpGLJournal1 _dataobject;

        protected override IActionInvoker CreateActionInvoker()
        {
            _dataobject = new DAL.RpGLJournal1(Request);
            this.InitData(_dataobject);
            return base.CreateActionInvoker();
        }

        public ActionResult Print(int sysreportid, string reporttype = "PDF")
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            var result = _dataobject.GetDataCacheAll<Models.RpGLJournal1>();
            var reportparameter = _dataobject.GetReportParameter();
            return Services.Report.Print.PrintReport(this, result, sysreportid, reporttype, reportparameter);
        }

        public ActionResult Index()
        {
            if (!_dataobject.sysbusinessrole.IsAdd) return PartialView(this._roleview);
            var result = _dataobject.GetData();
            var para = _dataobject.GetParamCache();
            ViewBag.ReportParams = para;
            return PartialView(result);
        }
    }
}