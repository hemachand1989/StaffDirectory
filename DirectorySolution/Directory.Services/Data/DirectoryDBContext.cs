using Directory.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Directory.Services.Data
{
    public class DirectoryDBContext:DbContext
    {
        public DirectoryDBContext(DbContextOptions<DirectoryDBContext> options) : base(options)
        {
        }

        public DbSet<StaffDirectory> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffDirectory>().ToTable("Staff");
        }
        
    }
}
