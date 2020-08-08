using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheGameShop.Infrastructure.Data;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.Repositories
{
    public class GameRepository
    {
        private readonly TheGameShopDbContext _dbContext;

        public GameRepository(TheGameShopDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Game>> GetAll()
        {
            var games = await _dbContext
                  .Games
                  .Include(g => g.DevelopedBy)
                  .Include(g => g.PublishedBy)
                  .Include(g => g.Genre)
                  .ToListAsync();

            return games;
        }

        public async Task<Game> GetOne(int id)
        {
            var game = await _dbContext
                .Games
                .Include(g => g.DevelopedBy)
                .Include(g => g.PublishedBy)
                .Include(g => g.Genre)
                .SingleOrDefaultAsync(g => g.Id == id);

            return game;
        }

        public async Task<IEnumerable<Developer>> GetDevelopedByForGame(int gameId) =>
            await _dbContext.Developers.Where(d => d.GameId == gameId).ToListAsync();
    }
}