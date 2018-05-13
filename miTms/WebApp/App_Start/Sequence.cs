using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public static class DbSequence
    {
        public static string GetNextOrderNo() {
          var db = SqlHelper2.DatabaseFactory.CreateDatabase() ;
           var result= db.ExecuteScalar<object>("SELECT NEXT VALUE FOR [dbo].[DBSEQUENCE]");
            return Convert.ToInt32(result).ToString("00000000");






        }
    }
}