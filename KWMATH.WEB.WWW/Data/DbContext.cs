using KWMATH.WEB.WWW.Models;
using Microsoft.EntityFrameworkCore;

namespace KWMATH.WEB.WWW.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Member> MemberList { get; set; }
    }
}