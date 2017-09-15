using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.Security;
using WebAPI.Class;
using WebAPI.Models;
using System.Web.Http.Cors;
namespace WebAPI.Controllers
{
    [Authorize]
    public class SenNotificationsController : ApiController
    {
        private Membership_Dbcontext db = new Membership_Dbcontext();
        ////[Authorize]
        ////GET: api/GetNotification
        //[System.Web.Http.HttpGet]
        //public List<SenNotification> GetNotification(string user)
        //{
        //    return db.SenNotifications.Where(s => s.UserName == user).ToList();
        //}
        //[Authorize]
        //[Authorize]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetNotification(int pageNo, string user, int pageSize = 10)
        {
            int total = db.SenNotifications.Where(s => s.UserName == user).Count();
            int page = Convert.ToInt32(Math.Ceiling(total / (Double)pageSize));
            int skip = 0;
            if ((total % pageSize != 0))
            {
                page++;
            }
            if (pageNo <= page)
            {
                skip = pageNo - 1;
                var notification1 = db.SenNotifications.Where(s => s.UserName == user).OrderByDescending(s => s.CreatedDate).Skip((skip) * pageSize).Take(pageSize).ToList();
                return Ok(notification1);
            }

            return Ok(new List<Models.SenNotification>());
        }

        //[Authorize]IQueryable
        //[ResponseType(typeof(SenNotification))]
        //public IHttpActionResult GetNotification (int id)
        //{
        //    SenNotification noti = db.SenNotification.Find(id);

        //    if (noti == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(noti);
        //}
        //[Authorize]
        //PUT: api/PutNotification
        [System.Web.Http.HttpGet]
        public IHttpActionResult PutNotification(long id, string state = "seen")
        {
            try
            {

                string username = new List<System.Security.Claims.Claim>(((System.Security.Claims.ClaimsIdentity)User.Identity).Claims).Where(m => m.Type == "username").SingleOrDefault().Value;
                var noti = db.SenNotifications.Where(s => s.NotificationId == id && s.UserName == username).SingleOrDefault();
                noti.NotificationState = state;
                db.Entry(noti).State = System.Data.Entity.EntityState.Modified;//gan trang thai thay doi cho database
                db.SaveChanges();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return Ok("Logout sucessful");
        }
        //[Authorize]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUserInfo(string email)
        {
            var Sennoti = from asp in db.aspnet_Membership
                          from su in db.SenUser
                          where su.UserId == asp.UserId && asp.Email == email
                          select new { su.FullName, su.Avatar, asp.UserId, su.Address, su.Telephone };
            return Ok(Sennoti);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetNotiState(int pageNoS, int pagesizeS, string userS, string state)
        {
            int total = db.SenNotifications.Where(s => s.UserName == userS && s.NotificationState == state).Count();
            int page = Convert.ToInt32(Math.Ceiling(total / (Double)pagesizeS));
            int skip = 0;

            if ((total % pagesizeS != 0))
            {
                page++;
            }
            if (pageNoS <= page)
            {
                skip = pageNoS - 1;
                var notification1 = db.SenNotifications.Where(s => s.UserName == userS && s.NotificationState == state).OrderByDescending(s => s.CreatedDate).Skip((skip) * pagesizeS).Take(pagesizeS).ToList();
                return Ok(notification1);
            }
            return Ok(new List<Models.SenNotification>());
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult Search_Sender(string searchName, string receiveUser, int pageno)
        {
            int pagesize = 10;
            int total = db.SenNotifications.Where(s => s.UserName == receiveUser && s.Sender.StartsWith(searchName)).Count();
            int page = Convert.ToInt32(Math.Ceiling(total / (Double)pagesize));
            int skip = 0;
            if (total == 1)
            {
                pagesize = 1;
            }
            if ((total % pagesize != 0))
            {
                page++;
            }
            if (pageno <= page)
            {
                skip = pageno - 1;
                var notification1 = db.SenNotifications.Where(s => s.Sender.StartsWith(searchName) && s.UserName == receiveUser).OrderByDescending(s => s.CreatedDate).Skip((skip) * pagesize).Take(pagesize).ToList();
                return Ok(notification1);
            }

            return Ok(new List<Models.SenNotification>());
            //var search_sender = db.SenNotifications.Where(s => s.Sender.StartsWith(searchName) && s.UserName == receiveUser).OrderByDescending(s => s.CreatedDate).Skip(pageno).Take(10).ToList();
            //return Ok(search_sender);
        }
    }
}
