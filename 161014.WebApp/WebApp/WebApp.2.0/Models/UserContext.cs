﻿//------------------------------------------------------------------------------
// <auto-generated>
// gen by lotusviet.vn
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Security;
    using System.Linq;
    using System.Linq.Dynamic;


    public partial class UserContext
    {
        private SenContext _db;
        private int _newmessage;
        private MembershipUser _user;
        private SenUser _senuser;
        private string _fullname;

        public UserContext(SenContext db, MembershipUser user)
        {
            this._db = db;
            this._user = user;
            Guid userid = Guid.Parse(user.ProviderUserKey.ToString());
            this._senuser = this._db.SenUsers.Where(m => m.UserId == userid).SingleOrDefault();
            ResetMessage();
            ResetSenUser();
        }

        public MembershipUser User { get { return _user; } set { _user = value; } }
        public int NewMessage { get { return _newmessage; } set { _newmessage = value; } }
        public string FullName { get { return _fullname; } set { _fullname = value; } }

        //public virtual UserProfile 
        public SenUser SenUser { get { return _senuser; } set { _senuser = value; } }
        private void ResetMessage()
        {
            _newmessage = _db.SenPrivateMessages.Where(m => m.ToUser.UserName == User.UserName && m.IsRead == false &&m.IsDeletedByRecipient==false).Count();
        }
        private void ResetSenUser()
        {
            var userid = Guid.Parse(this._user.ProviderUserKey.ToString());
            var senuser = this._db.SenUsers.Where(m => m.UserId == userid).SingleOrDefault();
            if (senuser == null)
            {
                senuser = new SenUser() { UserId = userid, FullName =this._user.UserName };
            }

            this.FullName = senuser.FullName ?? this._user.UserName;
        }


    }
}