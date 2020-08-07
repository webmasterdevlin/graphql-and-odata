using System.Collections.Generic;
using System.Linq;

namespace TheGameShop.MobileApp.Models
{
    public class GameGraphQLResponse
    {
        public GameGraphQLResponse(IEnumerable<Game> games) => Games = games.ToList();

        public List<Game> Games { get; }
    }
}