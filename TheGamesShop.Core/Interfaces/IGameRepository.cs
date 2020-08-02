using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheGamesShop.Core.Entities;

namespace TheGamesShop.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();

        Task<Game> GetOne(int id);
    }
}