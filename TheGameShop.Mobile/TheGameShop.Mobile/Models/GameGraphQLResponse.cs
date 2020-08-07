using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameShop.Mobile.Models
{
    public class GameGraphQLResponse
    {
        public GameGraphQLResponse(IEnumerable<Game> games) => Games = games.ToList();

        public List<Game> Games { get; }
    }
}