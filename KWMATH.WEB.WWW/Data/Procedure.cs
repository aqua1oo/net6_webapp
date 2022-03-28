using KWMATH.WEB.WWW.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace KWMATH.WEB.WWW.Data
{
    public class Procedure
    {
        private readonly ApplicationDbContext _db;
        public Procedure(ApplicationDbContext db)
        {            
            _db = db;
        }

        public List<Member> Member(string sql, List<SqlParameter> parms)
        {
            #region DB처리          
            List<Member> memberList;            
            memberList = _db.MemberList.FromSqlRaw<Member>(sql, parms.ToArray()).ToList();            
            Debugger.Break();
            #endregion

            return memberList;
        }
    }
}