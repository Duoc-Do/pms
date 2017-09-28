﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using WebApp.Areas.Accounting.Services;

namespace WebApp.Areas.Accounting.DAL
{
    public partial class RpSalesLedger : SenVietReportObject
    {
        public RpSalesLedger(HttpRequestBase request) : base(request) { }
        public override void InitObject()
        {
            this._businesscode = "RpSalesLedger";
            this._metaname = "RpSalesLedger";
            this._keyfield = "DocumentID";
            this._storeName = @"sp_RpSalesLedger '{0}','{1}'";
            base.InitObject();
        }

        public System.Collections.Hashtable GetReportParameter()
        {
            var para = this.GetParamCache();
            System.Collections.Hashtable ReportParameter = new System.Collections.Hashtable();
            #region tham so co ban cua bao cao
            ReportParameter.Add("DateFrom", ((DateTime)para["DateFrom"]).ToShortDateString());
            ReportParameter.Add("DateTo", ((DateTime)para["DateTo"]).ToShortDateString());
            #endregion
            return ReportParameter;
        }

        public List<Models.RpSalesLedger> GetData()
        {
            var datefrom = DateTime.Today;
            var dateto = DateTime.Today;
            Uti.Date.SetDateRange(this._request, out datefrom, out dateto);

            _params.Add("DateFrom", datefrom);
            _params.Add("DateTo", dateto);

            string strProcedure = string.Format(this._storeName, datefrom.ToString("yyyyMMdd"), dateto.ToString("yyyyMMdd"));
            List<Models.RpSalesLedger> result = null;
            if (!this.IsSession())
            {
                result = this._db.Database.SqlQuery<Models.RpSalesLedger>(strProcedure).ToList();
            }
            else
            {
                var resultsession = this.GetDataCache<Models.RpSalesLedger>();
                var parasession = this.GetParamCache();

                if (!(this._params["DateFrom"].Equals(parasession["DateFrom"]) && this._params["DateTo"].Equals(parasession["DateTo"])))
                {
                    result = this._db.Database.SqlQuery<Models.RpSalesLedger>(strProcedure).ToList();
                }
                else
                {
                    result = resultsession;
                }
            }
            this.SetDataCache(result);
            var model = Services.GridHelper.GetResults(this._request, this._metaname, result.AsQueryable<Models.RpSalesLedger>());
            this.SetParamCache(_params);

            return model;
        }

        public override byte[] ExportToExcel()
        {
            byte[] bytes = null;
            using (var stream = new MemoryStream())
            {
                Export.ExportToXlsx(stream, this.GetDataCacheAll<Models.RpSalesLedger>(), this._metaobject.GetMetaTable());
                bytes = stream.ToArray();
            }
            return bytes;
        }
    }
}