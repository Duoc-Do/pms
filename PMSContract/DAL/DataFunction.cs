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
            return db.CONTRACTS.OrderByDescending(s=>s.ContractID).ToList();
        }
        public long Insert(ContractModel entity)
        {
            db.CONTRACTS.Add(entity);
            db.SaveChanges();
            return entity.ContractID;
        }
        //public IHttpActionResult ListAllPaging()
        //{
        //    var loaddt = db.CONTRACTS.Skip(1).Take(10).ToList();
        //    return ;
        //}
        //public ContractModel GetById(string contractid)
        //{
        //    return db.CONTRACTS.SingleOrDefault(x => x.ContractID == contractid);
        //}

    }
}