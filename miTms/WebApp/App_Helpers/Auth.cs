using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public static class Auth
    {
        /// <summary>
        /// 获取当前登录用户名
        /// </summary>
        public static string UserName {

            get {
                string fullName = string.Empty;
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    fullName = HttpContext.Current.User.Identity.Name;
                }
                else {
                    fullName = "Demo";
                }


                return fullName;
            }
        }
        public static int PlatformId {
            get {
                var username = HttpContext.Current.User.Identity.Name;
                var db = SqlHelper2.DatabaseFactory.CreateDatabase();
                var companyid = db.ExecuteScalar<int>("select top 1 [Id] from [dbo].[Companies] ",null);
                return companyid;
            }

        }
        public static int ShipperId {

            get {
                var username = HttpContext.Current.User.Identity.Name;
                var db = SqlHelper2.DatabaseFactory.CreateDatabase();
                var companyid = db.ExecuteScalar<string>("select CompanyCode from[dbo].[AspNetUsers] where UserName = @username and AccountType = 2",new { username});
                return Convert.ToInt32( companyid);
                
               
            }
        }
        public static int CarrierId
        {

            get
            {
                var username = HttpContext.Current.User.Identity.Name;
                var db = SqlHelper2.DatabaseFactory.CreateDatabase();
                var companyid = db.ExecuteScalar<string>("select CompanyCode from[dbo].[AspNetUsers] where UserName = @username and AccountType = 1", new { username });
                return Convert.ToInt32(companyid);


            }
        }
        public static string GetRole(string userName) {
            string sql = @"select t1.[Name]  from dbo.[AspNetRoles] t1 ,dbo.[AspNetUserRoles] t2,dbo.[AspNetUsers] t3
                            where t1.Id = t2.RoleId and t2.UserId = t3.Id and t3.UserName = @userName";
            var db = SqlHelper2.DatabaseFactory.CreateDatabase();
            var role = db.ExecuteScalar<string>(sql, new { userName });
            return role;
        }
        public static string GetRoleDescription(string userName)
        {

            var role = GetRole(userName);
            switch (role)
            {
                case "Shipper":
                    return "托运人";
                case "Carrier":
                    return "承运人";
                default:
                    return "平台";
            }
         
        }

        public static string GetUserIdByName(string username) {
          var db=  SqlHelper2.DatabaseFactory.CreateDatabase();
            var userid = db.ExecuteScalar<string>("select [id] from [dbo].[AspNetUsers] where [username]=@username", new { username });
            return userid;
        }
        public static string GetAvatarsByName(string username, int size = 50) {
            var db = SqlHelper2.DatabaseFactory.CreateDatabase();
            var photopath = "";
            if (size==50)
                photopath = db.ExecuteScalar<string>("select [AvatarsX50] from [dbo].[AspNetUsers] where [username]=@username", new { username });
            else
                photopath = db.ExecuteScalar<string>("select [AvatarsX120] from [dbo].[AspNetUsers] where [username]=@username", new { username });
            return photopath;
        }
    }
}