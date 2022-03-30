using KWMATH.WEB.WWW.Models;
using Microsoft.EntityFrameworkCore;

namespace KWMATH.WEB.WWW.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Member> MemberList { get; set; }
        public DbSet<ReturnInt> UserCheck { get; set; }
    }
}