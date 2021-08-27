using System;
using Microsoft.EntityFrameworkCore;
using VideoGameSales.Domain.Entities.Games;
using VideoGameSales.Domain.Entities.Platforms;
using VideoGameSales.Domain.Entities.Publishers;
using VideoGameSales.Domain.Entities.Sales;

namespace VideoGameSales.Infrastructure
{
    public class VideoGameSalesDbContext : DbContext
    {
        public VideoGameSalesDbContext(DbContextOptions<VideoGameSalesDbContext> options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
