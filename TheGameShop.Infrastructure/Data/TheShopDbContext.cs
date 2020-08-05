using Microsoft.EntityFrameworkCore;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Infrastructure.Data
{
    public class TheGameShopDbContext : DbContext
    {
        public TheGameShopDbContext(DbContextOptions<TheGameShopDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}