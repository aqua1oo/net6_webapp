using KWMATH.WEB.WWW.Data;
using KWMATH.WEB.WWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace KWMATH.WEB.WWW.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MemberController(ApplicationDbContext db)
        {            
            _db = db;
        }

        public IActionResult MemberList(MemberParam member)
        {
            member.status_cd = "2";
            member.site_user_id = 161156;
            member.organ_inf_cd = "00002780";
            #region DB처리              
            var parms = new List<SqlParameter> {
                new SqlParameter("@status_cd", member.status_cd),
                new SqlParameter("@grade_cd", member.grade_cd),
                new SqlParameter("@search_type", member.search_type),
                new SqlParameter("@search_value", member.search_value),
                new SqlParameter("@site_user_id", member.site_user_id),
                new SqlParameter("@organ_inf_cd", member.organ_inf_cd),
                new SqlParameter("@user_type", member.user_type)
            };
            string sql = "EXEC UP_TN_MEMBER_LIST_C_SEL @status_cd, @grade_cd, @search_type, @search_value, @site_user_id, @organ_inf_cd, @user_type";            

            Procedure pro = new Procedure(_db);
            List<Member> memberList = pro.Member(sql, parms);
            #endregion

            return View(memberList);
        }
    }
}