using AireLogicBugTrackingApi.Data;
using AireLogicBugTrackingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AireLogicBugTrackingApi
{
    public class ApplicationDbContext: DbContext, IApplicationDBContext
    {
        public DbSet<BugsModel> Bugs { get; set; }
        public DbSet<UserModel> Users { get; set ; }
        public DbSet<AssignedStatus> AssignedStatus { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    } 
}
