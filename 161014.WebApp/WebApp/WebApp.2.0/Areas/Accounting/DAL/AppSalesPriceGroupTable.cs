﻿
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Accounting.Services;

namespace WebApp.Areas.Accounting.DAL
{
    public partial class AppSalesPriceGroupTable : SenVietListObject
    {
        public AppSalesPriceGroupTable(HttpRequestBase request) : base(request) { }

        public override void InitObject()
        {
            this._businesscode = "AppSalesPriceGroupTable";
            this._metaname = "AppSalesPriceGroupTable";
            this._keyfield = "SalesPriceGroupID";
            this._storeNameI = @"sp_AppSalesPriceGroupTableI @SalesPriceGroupID OUTPUT,@SalesPriceGroupCode,@Name,@IsActive,@CreatedBy,@CreatedDateTime,@ModifiedBy,@ModifiedDateTime";
            this._storeNameU = @"sp_AppSalesPriceGroupTableU @SalesPriceGroupID OUTPUT,@SalesPriceGroupCode,@Name,@IsActive,@CreatedBy,@CreatedDateTime,@ModifiedBy,@ModifiedDateTime,@Original_SalesPriceGroupID";
            this._storeNameD = @"sp_AppSalesPriceGroupTableD {0}";
            base.InitObject();
        }

        public List<Models.AppSalesPriceGroupTable> GetData()
        {
            var model = Services.GridHelper.GetResults(this._request, this._metaname, this._db.AppSalesPriceGroupTables);
            return model;
        }

        public Models.AppSalesPriceGroupTable GetById(int Id)
        {
            return this._db.AppSalesPriceGroupTables.SingleOrDefault(m => m.SalesPriceGroupID == Id);
        }

        public Models.AppSalesPriceGroupTable GetNew(int? id)
        {
            if (id != null) return GetById(id ?? 0);
            return new Models.AppSalesPriceGroupTable();
        }

        public Models.AppSalesPriceGroupTable GetEdit(int id)
        {
            return GetById(id);
        }

        public Models.AppSalesPriceGroupTable GetDelete(int id)
        {
            return GetById(id);
        }

        public int Insert(Models.AppSalesPriceGroupTable data)
        {
            try
            {
                this.Validate(data);

                data.CreatedBy = GlobalVariant.GetAppUser().UserID;
                data.CreatedDateTime = DateTime.Now;

                SqlParameter[] parameters = ExConvert.Data2SqlParam(data, this._metaobject, this._paramnameoutput).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameI, parameters);

                return (int)parameters.GetValueSqlParam(this._paramnameoutput);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Models.AppSalesPriceGroupTable data)
        {
            try
            {
                this.Validate(data);

                data.ModifiedBy = GlobalVariant.GetAppUser().UserID;
                data.ModifiedDateTime = DateTime.Now;

                SqlParameter pOriginal = ExConvert.ParseSqlParam(data, this._metaobject.GetMetaByColumnName(this._paramnameoutput), this._paramnameupdate);
                var parameters = ExConvert.Data2SqlParam(data, this._metaobject, pOriginal).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameU, parameters);

                return data.SalesPriceGroupID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                this._db.Database.ExecuteSqlCommand(this._storeNameD, Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override byte[] ExportToExcel()
        {
            byte[] bytes = null;
            using (var stream = new MemoryStream())
            {
                Export.ExportToXlsx(stream, this.GetData(), this._metaobject.GetMetaTable());
                bytes = stream.ToArray();
            }
            return bytes;
        }

        public override void ImportFromExcel(Stream stream)
        {

            var metatable = this._metaobject.MetaTable;//lấy meta của bảng gốc

            // ok, we can run the real code of the sample now
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("No worksheet found");

                //the columns
                Dictionary<int, string> properties = new Dictionary<int, string>();

                int iCol = 1;
                #region lấy header column
                while (true)
                {
                    bool allColumnsAreEmpty = true;
                    if (worksheet.Cells[1, iCol].Value != null && !String.IsNullOrEmpty(worksheet.Cells[1, iCol].Value.ToString()))
                    {
                        properties.Add(iCol, worksheet.Cells[1, iCol].Value.ToString());
                        allColumnsAreEmpty = false;
                    }
                    if (allColumnsAreEmpty) break;
                    iCol++;
                }
                #endregion


                int iRow = 2;
                while (true)
                {
                    var newitem = this.GetNew(null);
                    int allColumnsAreEmpty = properties.Count;
                    for (var i = 1; i <= properties.Count; i++)
                    {
                        if (worksheet.Cells[iRow, i].Value != null && !String.IsNullOrEmpty(worksheet.Cells[iRow, i].Value.ToString()))
                        {
                            string fieldmap = properties[i];
                            var value = worksheet.Cells[iRow, i].Value.ToString();
                            var itemfield = metatable.Find(m => m.ColumnName == fieldmap || m.Des == fieldmap);
                            if (itemfield != null)
                            {
                                var objvalue = Services.ExConvert.String2Data(value, Services.ExConvert.Sqltype2Systemtype(itemfield.DATA_TYPE));
                                newitem.GetType().GetProperty(itemfield.ColumnName).SetValue(newitem, objvalue, null);
                            }
                        }
                        else
                        {
                            allColumnsAreEmpty--;
                        }
                    }
                    try
                    {
                        this.MapCode2Id(newitem);
                        this.Insert(newitem);
                    }
                    catch (Exception)
                    {
                    }

                    if (allColumnsAreEmpty <= 0) break;

                    //next object
                    iRow++;
                }
            }

        }
    }
}