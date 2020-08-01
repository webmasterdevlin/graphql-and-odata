using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheGameShop.Api.Data;
using TheGameShop.Api.Data.Entities;

namespace TheGameShop.Api.Repositories
{
    public class GameReviewRepository
    {
        private readonly TheGameShopDbContext _dbContext;

        public GameReviewRepository(TheGameShopDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<GameReview>> GetForGame(int gameId) =>
            await _dbContext.GameReviews.Where(gr => gr.GameId == gameId).ToListAsync();

        public async Task<ILookup<int, GameReview>> GetForGames(IEnumerable<int> gameIds)
        {
            var reviews = await _dbContext.GameReviews.Where(gr => gameIds.Contains(gr.GameId)).ToListAsync();
            return reviews.ToLookup(r => r.GameId);
        }

        public async Task<GameReview> AddReview(GameReview review)
        {
            await _dbContext.GameReviews.AddAsync(review);

            await _dbContext.SaveChangesAsync();

            return review;
        }
    }
}