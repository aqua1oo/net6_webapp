using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KWMATH.WEB.WWW.Models
{
    [Keyless]
    public class ReturnInt
    {
        [Required]
        public int count { get; set; } = 0;
    }
}