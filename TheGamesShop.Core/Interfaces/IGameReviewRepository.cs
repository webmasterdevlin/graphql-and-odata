using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheGamesShop.Core.Entities;

namespace TheGamesShop.Core.Interfaces
{
    public interface IGameReviewRepository
    {
        Task<IEnumerable<GameReview>> GetForGame(int gameId);

        Task<ILookup<int, GameReview>> GetForGames(IEnumerable<int> gameIds);

        Task<GameReview> AddReview(GameReview review);
    }
}