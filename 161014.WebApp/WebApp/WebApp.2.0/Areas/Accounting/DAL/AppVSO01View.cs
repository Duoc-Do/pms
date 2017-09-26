﻿using System;
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
    public partial class AppVSO01View : SenVietVoucherObject
    {
        public AppVSO01View(HttpRequestBase request) : base(request) { }
        public override void InitObject()
        {
            this._businesscode = "AppVSO01ViewEdit";
            this._keyfieldmaster = "DocumentID";
            this._keyfieldline = "DocumentLineID";
            this._keyfieldvat = "DocumentVATID";

            this._metaname = "AppVSO01View";
            this._metalinename = "AppVSO01LineView";
            this._metavatname = "AppVSO01VATView";


            //this._storeNameI = @"sp_AppVSO01ViewI @DocumentID OUTPUT,@ParentID,@VoucherID,@CurrencyID,@ExchangeRate,@VoucherDate,@VoucherNumber,@CustomerID,@Address,@Contact,@Description,@PostType,@IsFixPrice,@AccountDebitID,@DueDate,@CreatedBy,@CreatedDateTime,@ModifiedBy,@ModifiedDateTime";
            //this._storeNameU = @"sp_AppVSO01ViewU @DocumentID OUTPUT,@ParentID,@VoucherID,@CurrencyID,@ExchangeRate,@VoucherDate,@VoucherNumber,@CustomerID,@Address,@Contact,@Description,@PostType,@IsFixPrice,@AccountDebitID,@DueDate,@CreatedBy,@CreatedDateTime,@ModifiedBy,@ModifiedDateTime,@Original_DocumentID";
            this._storeNameI = @"sp_AppVSO01ViewI @DocumentID OUTPUT,@ParentID,@VoucherID,@CurrencyID,@ExchangeRate,@VoucherDate,@VoucherNumber,@CustomerID,@Address,@Contact,@Description,@PostType,@IsFixPrice,@AccountDebitID,@DueDate,@CreatedBy,@CreatedDateTime,@ModifiedBy,@ModifiedDateTime,@ExMObject01ID,@ExMObject02ID,@ExMObject03ID,@ExMObject04ID,@ExMObject05ID,@ExMObject06ID,@ExMObject07ID,@ExMObject08ID,@ExMObject09ID,@ExMObject10ID,@ExMDate01,@ExMDate02,@ExMDate03,@ExMDate04,@ExMDate05,@ExMDate06,@ExMString01,@ExMString02,@ExMString03,@ExMString04,@ExMString05,@ExMString06,@ExMNumeric01,@ExMNumeric02,@ExMNumeric03,@ExMNumeric04,@ExMNumeric05,@ExMNumeric06,@ExMNumeric07,@ExMNumeric08,@ExMNumeric09,@ExMNumeric10,@ExMObject11ID,@ExMObject12ID,@ExMObject13ID,@ExMObject14ID,@ExMObject15ID,@ExMObject16ID,@ExMObject17ID,@ExMObject18ID,@ExMObject19ID,@ExMObject20ID";
            this._storeNameU = @"sp_AppVSO01ViewU @DocumentID OUTPUT,@ParentID,@VoucherID,@CurrencyID,@ExchangeRate,@VoucherDate,@VoucherNumber,@CustomerID,@Address,@Contact,@Description,@PostType,@IsFixPrice,@AccountDebitID,@DueDate,@CreatedBy,@CreatedDateTime,@ModifiedBy,@ModifiedDateTime,@ExMObject01ID,@ExMObject02ID,@ExMObject03ID,@ExMObject04ID,@ExMObject05ID,@ExMObject06ID,@ExMObject07ID,@ExMObject08ID,@ExMObject09ID,@ExMObject10ID,@ExMDate01,@ExMDate02,@ExMDate03,@ExMDate04,@ExMDate05,@ExMDate06,@ExMString01,@ExMString02,@ExMString03,@ExMString04,@ExMString05,@ExMString06,@ExMNumeric01,@ExMNumeric02,@ExMNumeric03,@ExMNumeric04,@ExMNumeric05,@ExMNumeric06,@ExMNumeric07,@ExMNumeric08,@ExMNumeric09,@ExMNumeric10,@ExMObject11ID,@ExMObject12ID,@ExMObject13ID,@ExMObject14ID,@ExMObject15ID,@ExMObject16ID,@ExMObject17ID,@ExMObject18ID,@ExMObject19ID,@ExMObject20ID,@Original_DocumentID";

            this._storeNameD = @"sp_AppVSO01ViewD {0}";


            this._storeNameLineI = @"sp_AppVSO01LineViewI @DocumentID,@DocumentLineID OUTPUT,@DocumentLineType,@ParentLineID,@AccountDebitLine1ID,@AccountCreditLine1ID,@AccountDebitLineID,@AccountCreditLineID,@DescriptionLine,@WarehouseLineID,@ProductID,@ItemID,@UOMID,@Quantity0,@MeasureRate,@Quantity,@UnitPriceFC,@UnitPrice,@Amount,@AmountFC,@DisCount,@DisCountFC,@DisCountPercentage,@UnitPriceSell,@UnitPriceSellFC,@AmountSell,@AmountSellFC,@ExObject01ID,@ExObject02ID,@ExObject03ID,@ExObject04ID,@ExObject05ID,@ExObject06ID,@ExObject07ID,@ExObject08ID,@ExObject09ID,@ExObject10ID,@ExDate01,@ExDate02,@ExDate03,@ExDate04,@ExDate05,@ExDate06,@ExString01,@ExString02,@ExString03,@ExString04,@ExString05,@ExString06,@ExNumeric01,@ExNumeric02,@ExNumeric03,@ExNumeric04,@ExNumeric05,@ExNumeric06,@ExNumeric07,@ExNumeric08,@ExNumeric09,@ExNumeric10,@ExObject11ID,@ExObject12ID,@ExObject13ID,@ExObject14ID,@ExObject15ID,@ExObject16ID,@ExObject17ID,@ExObject18ID,@ExObject19ID,@ExObject20ID";
            this._storeNameLineU = @"sp_AppVSO01LineViewU @DocumentID,@DocumentLineID OUTPUT,@DocumentLineType,@ParentLineID,@AccountDebitLine1ID,@AccountCreditLine1ID,@AccountDebitLineID,@AccountCreditLineID,@DescriptionLine,@WarehouseLineID,@ProductID,@ItemID,@UOMID,@Quantity0,@MeasureRate,@Quantity,@UnitPriceFC,@UnitPrice,@Amount,@AmountFC,@DisCount,@DisCountFC,@DisCountPercentage,@UnitPriceSell,@UnitPriceSellFC,@AmountSell,@AmountSellFC,@ExObject01ID,@ExObject02ID,@ExObject03ID,@ExObject04ID,@ExObject05ID,@ExObject06ID,@ExObject07ID,@ExObject08ID,@ExObject09ID,@ExObject10ID,@ExDate01,@ExDate02,@ExDate03,@ExDate04,@ExDate05,@ExDate06,@ExString01,@ExString02,@ExString03,@ExString04,@ExString05,@ExString06,@ExNumeric01,@ExNumeric02,@ExNumeric03,@ExNumeric04,@ExNumeric05,@ExNumeric06,@ExNumeric07,@ExNumeric08,@ExNumeric09,@ExNumeric10,@ExObject11ID,@ExObject12ID,@ExObject13ID,@ExObject14ID,@ExObject15ID,@ExObject16ID,@ExObject17ID,@ExObject18ID,@ExObject19ID,@ExObject20ID,@Original_DocumentLineID";
            this._storeNameLineD = @"sp_AppVSO01LineViewD {0}";
            this._storeNameVATI = @"sp_AppVSO01VATViewI @DocumentID,@DocumentVATID OUTPUT,@DocumentVATType,@VATDate,@VATNumber,@VATSerial,@VATTemplate,@CustomerName,@CustomerAddress,@TaxCode,@ItemName,@AmountVAT,@AmountVATFC,@Percentage,@Amount,@AmountFC,@DescriptionVAT,@SalesTaxID,@AccountDebitLineID,@AccountCreditLineID,@ProductID,@ExObject01ID,@ExObject02ID,@ExObject03ID,@ExObject04ID,@ExObject05ID,@ExObject06ID,@ExObject07ID,@ExObject08ID,@ExObject09ID,@ExObject10ID,@ExDate01,@ExDate02,@ExDate03,@ExDate04,@ExDate05,@ExDate06,@ExString01,@ExString02,@ExString03,@ExString04,@ExString05,@ExString06,@ExNumeric01,@ExNumeric02,@ExNumeric03,@ExNumeric04,@ExNumeric05,@ExNumeric06,@ExNumeric07,@ExNumeric08,@ExNumeric09,@ExNumeric10,@ExObject11ID,@ExObject12ID,@ExObject13ID,@ExObject14ID,@ExObject15ID,@ExObject16ID,@ExObject17ID,@ExObject18ID,@ExObject19ID,@ExObject20ID";
            this._storeNameVATU = @"sp_AppVSO01VATViewU @DocumentID,@DocumentVATID OUTPUT,@DocumentVATType,@VATDate,@VATNumber,@VATSerial,@VATTemplate,@CustomerName,@CustomerAddress,@TaxCode,@ItemName,@AmountVAT,@AmountVATFC,@Percentage,@Amount,@AmountFC,@DescriptionVAT,@SalesTaxID,@AccountDebitLineID,@AccountCreditLineID,@ProductID,@ExObject01ID,@ExObject02ID,@ExObject03ID,@ExObject04ID,@ExObject05ID,@ExObject06ID,@ExObject07ID,@ExObject08ID,@ExObject09ID,@ExObject10ID,@ExDate01,@ExDate02,@ExDate03,@ExDate04,@ExDate05,@ExDate06,@ExString01,@ExString02,@ExString03,@ExString04,@ExString05,@ExString06,@ExNumeric01,@ExNumeric02,@ExNumeric03,@ExNumeric04,@ExNumeric05,@ExNumeric06,@ExNumeric07,@ExNumeric08,@ExNumeric09,@ExNumeric10,@ExObject11ID,@ExObject12ID,@ExObject13ID,@ExObject14ID,@ExObject15ID,@ExObject16ID,@ExObject17ID,@ExObject18ID,@ExObject19ID,@ExObject20ID,@Original_DocumentVATID";
            this._storeNameVATD = @"sp_AppVSO01VATViewD {0}";

            base.InitObject();
        }

        public override object FieldChange()
        {
            string fieldname = this._request.Params["fieldname"].ToString();
            string keyword = this._request.Params["keyword"].ToString();
            int type = int.Parse(this._request.Params["type"].ToString());
            DateTime voucherdate = this._request.Params["voucherdate"] != null ? DateTime.Parse(this._request["voucherdate"].ToString()) : DateTime.Today;
            string customercode = this._request.Params["customercode"] != null ? this._request.Params["customercode"].ToString() : "";

            int customerid = this._request.Params["customerid"] != null ? int.Parse(this._request.Params["customerid"].ToString()) : 0;
            int itemid = this._request.Params["itemid"] != null ? int.Parse(this._request.Params["itemid"].ToString()) : 0;
            int uomid = this._request.Params["uomid"] != null ? int.Parse(this._request.Params["uomid"].ToString()) : 0;
            decimal quantity0 = this._request.Params["quantity0"] != null ? decimal.Parse(this._request.Params["quantity0"].ToString()) : 0;

            decimal UnitPriceSell = 0;
            decimal UnitPriceSellFC = 0;
            object results = null;

            #region valid chứng từ

            if (type == 0)
            {
                switch (fieldname)
                {
                    case "IsoCode":
                        var appcurrencytable = this._db.AppCurrencyTables.Where(m => m.IsoCode == keyword).SingleOrDefault();
                        if (appcurrencytable != null)
                        {
                            decimal exchangerate = Services.Voucher.GetExchangeRate(appcurrencytable.CurrencyID, voucherdate);
                            results = (new { rows = new { ExchangeRate = exchangerate, CurrencyID = appcurrencytable.CurrencyID } });
                        }
                        break;

                    default:
                        results = Services.Data.GetByCode(fieldname, keyword);
                        break;
                }
            }
            #endregion

            #region valid hạch toán
            if (type == 1)
            {
                switch (fieldname)
                {
                    case "DisplayNumberLineCredit":
                        var appaccountview2 = this._db.AppAccountView2.Where(m => m.DisplayNumber == keyword).SingleOrDefault();
                        if (appaccountview2 != null)
                        {
                            decimal exchangerateline = Services.Voucher.GetExchangeRateLine(voucherdate, customercode, keyword);
                            results = (new { rows = new { ExchangeRateLine = exchangerateline, AccountID = appaccountview2.AccountID } });
                        }
                        break;
                    case "ItemCode":
                        var appitem = this._db.AppItemViews.Where(m => m.ItemCode == keyword).SingleOrDefault();
                        if (appitem != null)
                        {
                            UnitPriceSell = Services.Voucher.GetUnitPriceSell(customerid, appitem.ItemID, appitem.UOMID, quantity0, voucherdate);
                            UnitPriceSellFC = Services.Voucher.GetUnitPriceSell(customerid, appitem.ItemID, appitem.UOMID, quantity0, voucherdate);
                        }
                        results = (new { rows = appitem, extrows = new { UnitPriceSell = UnitPriceSell, UnitPriceSellFC = UnitPriceSellFC } });

                        break;
                    case "UOMCode":
                        var appuom = this._db.AppUnitOfMeasureTables.Where(m => m.UOMCode == keyword).SingleOrDefault();
                        if (appuom != null)
                        {
                            UnitPriceSell = Services.Voucher.GetUnitPriceSell(customerid, itemid, appuom.UOMID, quantity0, voucherdate);
                            UnitPriceSellFC = Services.Voucher.GetUnitPriceSell(customerid, itemid, appuom.UOMID, quantity0, voucherdate);
                        }
                        results = (new { rows = appuom, extrows = new { UnitPriceSell = UnitPriceSell, UnitPriceSellFC = UnitPriceSellFC } });

                        break;
                    case "Quantity0":

                        UnitPriceSell = Services.Voucher.GetUnitPriceSell(customerid, itemid, uomid, quantity0, voucherdate);
                        UnitPriceSellFC = Services.Voucher.GetUnitPriceSell(customerid, itemid, uomid, quantity0, voucherdate);
                        results = (new { extrows = new { UnitPriceSell = UnitPriceSell, UnitPriceSellFC = UnitPriceSellFC } });
                        break;
                    default:
                        results = Services.Data.GetByCode(fieldname, keyword);
                        break;
                }
            }
            #endregion

            #region valid thuế
            if (type == 2)
            {
                switch (fieldname)
                {
                    case "VATDate":
                        results = (new { rows = new { VATNumber = Services.Voucher.GetVATNumber(voucherdate), VATSerial = Services.Voucher.GetVATSerial(voucherdate) } });
                        break;
                    default:
                        results = Services.Data.GetByCode(fieldname, keyword);
                        break;
                }
            }
            #endregion

            //base.FieldChange();
            return results;
        }

        public void Validate(Models.AppVSO01View data)
        {
            #region ki?m tra chi ti?t

            this._metaobject = Services.GlobalMeta.GetMetaObject(this._metalinename);
            this.ValidateLine(data.AppVSO01LineViews, data.AppVSO01LineViewz);

            #endregion

            #region ki?m tra thu?

            this._metaobject = Services.GlobalMeta.GetMetaObject(this._metavatname);
            this.ValidateVAT(data.AppVSO01VATViews, data.AppVSO01VATViewz);
            #endregion

            #region Business logic validate
            #region Object validate
            this._metaobject = Services.GlobalMeta.GetMetaObject(this._metaname);
            this.ValidateMaster(data);
            #endregion

            #endregion

            //if (Errors.Count > 0) throw new InvalidOperationException("l?i nh?p s? li?u");

        }

        public List<Models.AppVSO01View> GetData()
        {
            var model = Services.GridHelper.GetResults(this._request, this._metaname, Voucher.RoleFilter(this._db.AppVSO01Views));
            return model;
        }

        public Models.AppVSO01View GetById(long Id)
        {
            return this._db.AppVSO01Views.SingleOrDefault(m => m.DocumentID == Id);
        }

        public Models.AppVSO01View GetNew(long? id)
        {
            //ki?m tra quy?n n?u không cho thì ném exception
            if (id != null)
            {
                var model = GetById(id ?? 0);
                model.VoucherDate = DateTime.Today;
                model.VoucherNumber = Services.Voucher.GetVoucherNumber(model.VoucherID);
                return model;
            }
            return new Models.AppVSO01View();
        }

        public Models.AppVSO01View GetEdit(long id)
        {
            //ki?m tra quy?n n?u không cho thì ném exception
            return GetById(id);
        }

        public Models.AppVSO01View GetDelete(long id)
        {
            //ki?m tra quy?n n?u không cho thì ném exception
            return GetById(id);
        }

        public long Insert(Models.AppVSO01View data)
        {
            try
            {
                data.DocumentID = 0;
                //Ki?m tra thêm m?i ch?ng t? nhu trùng s? ho?c ngày khóa s?
                this.ValidateInsert(data);
                //Ki?m tra ki?u nh?p d? li?u
                this.Validate(data);

                #region x? lý master

                data.CreatedBy = GlobalVariant.GetAppUser().UserID;
                data.CreatedDateTime = DateTime.Now;

                SqlParameter[] parameters = ExConvert.Data2SqlParam(data, this._metaobject, this._paramnamemasteroutput).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameI, parameters);
                data.DocumentID = (long)parameters.GetValueSqlParam(this._paramnamemasteroutput);

                #endregion

                #region X? lý line
                this._metaobject = Services.GlobalMeta.GetMetaObject(this._metalinename);

                var appvso01lineviews = data.AppVSO01LineViews.ToList();
                var appvso01lineviewz = data.AppVSO01LineViewz.ToList();
                for (int i = 0; i < appvso01lineviews.Count; i++)
                {

                    var itemz = appvso01lineviewz[i];
                    if (itemz != -1)
                    {
                        var item = appvso01lineviews[i];
                        item.DocumentID = data.DocumentID;
                        item.AccountDebitLine1ID = data.AccountDebitID;
                        item.MeasureRate = item.MeasureRate ?? 1;
                        item.Quantity = item.Quantity0 * item.MeasureRate;
                        if (data.IsoCode == Services.GlobalVariant.GetSysOption()["IsoCode"].ToString())
                        {
                            //item.Debit = 0;
                            //item.Credit = 0;
                            //item.ExchangeRateLine = 0;
                            item.AmountFC = 0;
                        }

                        this.InsertLine(item);
                    }
                }

                #endregion

                #region X? lý VAT
                if (data.AppVSO01VATViews != null)
                {

                    this._metaobject = Services.GlobalMeta.GetMetaObject(this._metavatname);

                    var appvso01vatviews = data.AppVSO01VATViews.ToList();
                    var appvso01vatviewz = data.AppVSO01VATViewz.ToList();
                    for (int i = 0; i < appvso01vatviews.Count; i++)
                    {

                        var itemz = appvso01vatviewz[i];
                        if (itemz != -1)
                        {
                            var item = appvso01vatviews[i];
                            item.DocumentID = data.DocumentID;
                            item.AccountDebitLineID = data.AccountDebitID;
                            if (data.IsoCode == Services.GlobalVariant.GetSysOption()["IsoCode"].ToString())
                            {
                                item.AmountFC = 0;
                                item.AmountVATFC = 0;
                            }

                            this.InsertVAT(item);
                        }
                    }
                }

                #endregion

                this._metaobject = Services.GlobalMeta.GetMetaObject(this._metaname);

                //Post vào sổ sách
                Services.Voucher.PostStoreProcedure(data.VoucherID, data.DocumentID);
                //cập nhật số chứng từ
                Services.Voucher.SaveVoucherNumber(data.VoucherID, data.VoucherNumber);
                return data.DocumentID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long InsertLine(Models.AppVSO01LineView data)
        {
            try
            {
                SqlParameter[] parameters = ExConvert.Data2SqlParam(data, this._metaobject, this._paramnamelineoutput).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameLineI, parameters);
                data.DocumentLineID = (long)parameters.GetValueSqlParam(this._paramnamelineoutput);

                return data.DocumentLineID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long InsertVAT(Models.AppVSO01VATView data)
        {
            try
            {
                SqlParameter[] parameters = ExConvert.Data2SqlParam(data, this._metaobject, this._paramnamevatoutput).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameVATI, parameters);
                data.DocumentVATID = (long)parameters.GetValueSqlParam(this._paramnamevatoutput);

                return data.DocumentVATID;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public long Update(Models.AppVSO01View data)
        {
            try
            {
                this.ValidateUpdate(data);
                this.Validate(data);

                data.ModifiedBy = GlobalVariant.GetAppUser().UserID;
                data.ModifiedDateTime = DateTime.Now;

                SqlParameter pOriginal = ExConvert.ParseSqlParam(data, this._metaobject.GetMetaByColumnName(this._paramnamemasteroutput), this._paramnamemasterupdate);
                var parameters = ExConvert.Data2SqlParam(data, this._metaobject, pOriginal).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameU, parameters);

                #region X? lý line
                this._metaobject = Services.GlobalMeta.GetMetaObject(this._metalinename);


                var appvso01lineviews = data.AppVSO01LineViews.ToList();
                var appvso01lineviewz = data.AppVSO01LineViewz.ToList();
                for (int i = 0; i < appvso01lineviews.Count; i++)
                {

                    var itemz = appvso01lineviewz[i];
                    var item = appvso01lineviews[i];

                    if (itemz != -1)
                    {
                        //có 2 tru?ng h?p: 1 - thêm m?i thu?ng DocumentLineID==0, 2 - s?a d? li?u cu DocumentLineID<>0
                        item.DocumentID = data.DocumentID;
                        item.AccountDebitLine1ID = data.AccountDebitID;
                        item.MeasureRate = item.MeasureRate ?? 1;
                        item.Quantity = item.Quantity0 * item.MeasureRate;
                        if (data.IsoCode == Services.GlobalVariant.GetSysOption()["IsoCode"].ToString())
                        {
                            //item.Debit = 0;
                            //item.Credit = 0;
                            //item.ExchangeRateLine = 0;
                            item.AmountFC = 0;
                        }


                        if (item.DocumentLineID == 0)
                        {
                            this.InsertLine(item);
                        }
                        else
                        {
                            this.UpdateLine(item);
                        }
                    }
                    else
                    {
                        //n?u xóa có 2 tru?ng h?p : 1 - xóa d? li?u có tru?c DocumentLineID<>0, 2 - xóa d? li?u m?i thêm DocumentLineID ==0
                        if (item.DocumentLineID > 0)
                        {
                            this.DeleteLine(item.DocumentLineID);
                        }
                    }
                }


                #endregion

                #region X? lý thu?
                if (data.AppVSO01VATViews != null)
                {


                    this._metaobject = Services.GlobalMeta.GetMetaObject(this._metavatname);


                    var appvso01vatviews = data.AppVSO01VATViews.ToList();
                    var appvso01vatviewz = data.AppVSO01VATViewz.ToList();
                    for (int i = 0; i < appvso01vatviews.Count; i++)
                    {

                        var itemz = appvso01vatviewz[i];
                        var item = appvso01vatviews[i];

                        if (itemz != -1)
                        {
                            //có 2 tru?ng h?p: 1 - thêm m?i thu?ng DocumentLineID==0, 2 - s?a d? li?u cu DocumentLineID<>0
                            item.DocumentID = data.DocumentID;
                            item.AccountDebitLineID = data.AccountDebitID;
                            if (data.IsoCode == Services.GlobalVariant.GetSysOption()["IsoCode"].ToString())
                            {
                                item.AmountFC = 0;
                                item.AmountVATFC = 0;
                            }


                            if (item.DocumentVATID == 0)
                            {
                                this.InsertVAT(item);
                            }
                            else
                            {
                                this.UpdateVAT(item);
                            }
                        }
                        else
                        {
                            //n?u xóa có 2 tru?ng h?p : 1 - xóa d? li?u có tru?c DocumentLineID<>0, 2 - xóa d? li?u m?i thêm DocumentLineID ==0
                            if (item.DocumentVATID > 0)
                            {
                                this.DeleteVAT(item.DocumentVATID);
                            }
                        }
                    }
                }


                #endregion

                this._metaobject = Services.GlobalMeta.GetMetaObject(this._metaname);

                Services.Voucher.PostStoreProcedure(data.VoucherID, data.DocumentID);

                return data.DocumentID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long UpdateLine(Models.AppVSO01LineView data)
        {
            try
            {

                SqlParameter pOriginal = ExConvert.ParseSqlParam(data, this._metaobject.GetMetaByColumnName(this._paramnamelineoutput), this._paramnamelineupdate);
                var parameters = ExConvert.Data2SqlParam(data, this._metaobject, pOriginal).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameLineU, parameters);

                return data.DocumentLineID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long UpdateVAT(Models.AppVSO01VATView data)
        {
            try
            {

                SqlParameter pOriginal = ExConvert.ParseSqlParam(data, this._metaobject.GetMetaByColumnName(this._paramnamevatoutput), this._paramnamevatupdate);
                var parameters = ExConvert.Data2SqlParam(data, this._metaobject, pOriginal).ToArray();
                this._db.Database.ExecuteSqlCommand(this._storeNameVATU, parameters);

                return data.DocumentVATID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long Id)
        {
            try
            {
                this.ValidateDelete(Id);
                this._db.Database.ExecuteSqlCommand(this._storeNameD, Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLine(long Id)
        {
            try
            {
                this._db.Database.ExecuteSqlCommand(this._storeNameLineD, Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteVAT(long Id)
        {
            try
            {
                this._db.Database.ExecuteSqlCommand(this._storeNameVATD, Id);
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
    }
}