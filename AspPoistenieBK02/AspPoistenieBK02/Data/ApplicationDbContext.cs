using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspPoistenieBK02.Models;

namespace AspPoistenieBK02.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AspPoistenieBK02.Models.UserModel> UserModel { get; set; }
        public DbSet<AspPoistenieBK02.Models.InsuranceModel> InsuranceModel { get; set; }
    }
}