
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    public class FootballLeageDBContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-F69UTG1; Initial Catalog=FootballLeage_EFCore; Encrypt=False;");
            optionsBuilder.UseSqlite($"Data Source=FootballLeage_EFCore.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                
            new Team
            {
                TeamId = 1,
                CraetedDate = DateTimeOffset.UtcNow.DateTime,
                Name = "Tivoli Gardens FC"
            },
            new Team
            {
                TeamId = 2,
                CraetedDate = DateTimeOffset.UtcNow.DateTime,
                Name = "Waterhouse F.C."
            },
            new Team
            {
                TeamId = 3,
                CraetedDate = DateTimeOffset.UtcNow.DateTime,
                Name = "Humble Lins F.C."
            });
        }

        
    }
}
