using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VideoGameSales.Domain.Entities.Conectors;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.Entities.Sales;

namespace VideoGameSales.Infrastructure
{
    public class VideoGameSalesDbContext : DbContext
    {
        public VideoGameSalesDbContext(DbContextOptions<VideoGameSalesDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GamesToPlataform>()
                .HasOne(b => b.Games)
                .WithMany(ba => ba.Platform)
                .HasForeignKey(bi => bi.Games_id);
            
            modelBuilder.Entity<GamesToPlataform>()
                .HasOne(b => b.Platform)
                .WithMany(ba => ba.GameToPlatform)
                .HasForeignKey(bi => bi.Platform_id);

            modelBuilder.Entity<PublishersToGames>()
                .HasOne(b => b.Publisher)
                .WithMany(ba => ba.GamesToPublisher)
                .HasForeignKey(bi => bi.Publishers_id);
             modelBuilder.Entity<PublishersToGames>()
                .HasOne(b => b.Games)
                .WithOne(ba => ba.Publisher)
                .HasForeignKey<PublishersToGames>(bi => bi.Publishers_id);
            

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamesToPlataform> GamesToPlataform { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<PublishersToGames> PublishersToGames { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
