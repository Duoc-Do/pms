using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using System.Web.Http;

namespace PMSContract
{
    public class DataFunction
    {
        DataContext db = new DataContext();

        public List<ContractModel> ViewList()
        {
            return db.CONTRACTS.OrderBy(s => s.ContractID).ToList();
        }
        public long Insert(ContractModel entity)
        {
            db.CONTRACTS.Add(entity);
            db.SaveChanges();
            return entity.ContractID;
        }

    /*    public void Update(ContractModel contract)
        {
            var ct = db.CONTRACTS.FirstOrDefault(c => c.ContractID == contract.ContractID);
            ct.ContractIDERP = contract.ContractIDERP;
            ct.CCE_ID = contract.CCE_ID;
            ct.ContractCode = contract.ContractCode;
            ct.ContractDate = contract.ContractDate;
            ct.CommencementDate = contract.CommencementDate;
            ct.Description = contract.Description;
            ct.Description_VN = contract.Description_VN;
            ct.ContractFormat = contract.ContractFormat;
            ct.FCAmount = contract.FCAmount;
            ct.LCAmount = contract.LCAmount;
            ct.FCAmountExtension = contract.FCAmountExtension;
            ct.LCAmountExtension = contract.LCAmountExtension;
            ct.ContractorID = contract.ContractorID;
            ct.DurationInDays = contract.DurationInDays;
            ct.ExtensionInDays = contract.ExtensionInDays;
            ct.ModifyDate = contract.ModifyDate;
            ct.CurrencyCode = contract.CurrencyCode;
            ct.Status = contract.Status;
            ct.ForOrdering = contract.ForOrdering;
            db.SaveChanges();
        }
        public void Delete(int contractId)
        {
            var ct = (from c in db.CONTRACTS
                      where c.ContractID == contractId
                      select c).FirstOrDefault();
            //Delete it from memory
            db.DeleteObject(ct);
            //Save to database
            db.SaveChanges();
        }*/
        //public IHttpActionResult ListAllPaging()
        //{
        //    var loaddt = db.CONTRACTS.Skip(1).Take(10).ToList();
        //    return ;
        //}
        //public ContractModel GetById(string contractid)
        //{
        //    return db.CONTRACTS.SingleOrDefault(x => x.ContractID == contractid);
        //}
        public bool Update(ContractModel contract)
        {
            try
            {
                var ct = db.CONTRACTS.Find(contract.ContractID);
                ct.ContractIDERP = contract.ContractIDERP;
                ct.CCE_ID = contract.CCE_ID;
                ct.ContractCode = contract.ContractCode;
                ct.ContractDate = contract.ContractDate;
                ct.CommencementDate = contract.CommencementDate;
                ct.Description = contract.Description;
                ct.Description_VN = contract.Description_VN;
                ct.ContractFormat = contract.ContractFormat;
                ct.FCAmount = contract.FCAmount;
                ct.LCAmount = contract.LCAmount;
                ct.FCAmountExtension = contract.FCAmountExtension;
                ct.LCAmountExtension = contract.LCAmountExtension;
                ct.ContractorID = contract.ContractorID;
                ct.DurationInDays = contract.DurationInDays;
                ct.ExtensionInDays = contract.ExtensionInDays;
                ct.ModifyDate = contract.ModifyDate;
                ct.CurrencyCode = contract.CurrencyCode;
                ct.Status = contract.Status;
                ct.ForOrdering = contract.ForOrdering;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public ContractModel ViewDetail(int id)
        {
            return db.CONTRACTS.Find(id);
        }
    }
}