using Microsoft.EntityFrameworkCore;
using TheGameShop.Api.Data.Entities;

namespace TheGameShop.Api.Data
{
    public class TheGameShopDbContext : DbContext
    {
        public TheGameShopDbContext(DbContextOptions<TheGameShopDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }
    }
}