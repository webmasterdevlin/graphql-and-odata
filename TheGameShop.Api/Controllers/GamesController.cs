using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheGameShop.Infrastructure.Data;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.Controllers
{
    public class GamesController : ControllerBase
    {
        private readonly TheGameShopDbContext _context;

        public GamesController(TheGameShopDbContext context) => _context = context;

        /// <summary>
        /// Sample OData query
        /// https://localhost:5001/odata/games?$select=Name,Rating&$OrderBy=Name&$Filter=Rating gt 8
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames() => await _context.Games.ToListAsync();
    }
}