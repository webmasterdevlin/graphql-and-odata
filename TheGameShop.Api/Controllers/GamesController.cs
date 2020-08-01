using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheGameShop.Api.Data;
using TheGameShop.Api.Data.Entities;

namespace TheGameShop.Api.Controllers
{
    public class GamesController : ControllerBase
    {
        private readonly TheGameShopDbContext _context;

        public GamesController(TheGameShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames() => await _context.Games.ToListAsync();
    }
}