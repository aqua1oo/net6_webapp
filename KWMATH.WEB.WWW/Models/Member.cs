using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KWMATH.WEB.WWW.Models
{
    [Keyless]
    public class MemberParam
    {
        [Required]  
        public string status_cd { get; set; } = string.Empty;
        public string grade_cd { get; set; } = string.Empty;
        public string search_type { get; set; } = string.Empty;
        public string search_value { get; set; } = string.Empty;
        public int site_user_id { get; set; } = 0;
        public string organ_inf_cd { get; set; } = string.Empty;
        public string user_type { get; set; } = string.Empty;

        public string EntityNm()
        {
            return "MemberParam";
        }
    }

    [Keyless]
    public class Member
    {
        [Required]
        public string grade_nm { get; set; }
        public string user_nm { get; set; }
    }
}