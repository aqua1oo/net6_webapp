using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KWMATH.WEB.WWW.Models
{
    [Keyless]
    public class UserParam
    {
        [Required]
        public string user_id { get; set; } = string.Empty;
        public string user_pass { get; set; } = string.Empty;
        public string site_id { get; set; } = string.Empty;
        public string client_ip { get; set; } = string.Empty;
        public string guid { get; set; } = string.Empty;
        public string return_url { get; set; } = "/";

        public string EntityNm()
        {
            return "UserParam";
        }
    }

    public class User : IdentityUser
    {
        public string name { get; set; } = default!;        
    }
}