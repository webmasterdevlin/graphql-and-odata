using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheGameShop.Infrastructure.Data;
using TheGamesShop.Core.Entities;
using TheGamesShop.Core.Interfaces;

namespace TheGameShop.Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly TheGameShopDbContext _dbContext;

        public GameRepository(TheGameShopDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Game>> GetAll() => await _dbContext.Games.ToListAsync();

        public async Task<Game> GetOne(int id) => await _dbContext.Games.SingleOrDefaultAsync(g => g.Id == id);
    }
}