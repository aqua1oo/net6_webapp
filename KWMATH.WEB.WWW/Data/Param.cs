using KWMATH.WEB.WWW.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace KWMATH.WEB.WWW.Data
{
    public class Param
    {
        #region User param
        public List<SqlParameter> UserValidateParam(UserParam user)
        {
            var parms = new List<SqlParameter> {
                new SqlParameter("@user_id", user.user_id),
                new SqlParameter("@user_pass", user.user_pass),
                new SqlParameter("@site_id", user.site_id),
                new SqlParameter("@client_ip",user.client_ip),
                new SqlParameter("@guid", Guid.NewGuid().ToString())
            };

            return parms;
        }
        #endregion

        #region Member Param
        public List<SqlParameter> MemberListParam(MemberParam member)
        {
            var parms = new List<SqlParameter> {
                new SqlParameter("@status_cd", member.status_cd),
                new SqlParameter("@grade_cd", member.grade_cd),
                new SqlParameter("@search_type", member.search_type),
                new SqlParameter("@search_value", member.search_value),
                new SqlParameter("@site_user_id", member.site_user_id),
                new SqlParameter("@organ_inf_cd", member.organ_inf_cd),
                new SqlParameter("@user_type", member.user_type)
            };

            return parms;
        }
        #endregion
    }
}