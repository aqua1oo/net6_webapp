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
            #endregion

            return memberList;
        }

        public int UserInt(string sql, List<SqlParameter> parms)
        {
            #region DB처리         
            List<ReturnInt> result;
            result = _db.UserCheck.FromSqlRaw<ReturnInt>(sql, parms.ToArray()).ToList();
            #endregion

            return result[0].count;
        }
    }
}