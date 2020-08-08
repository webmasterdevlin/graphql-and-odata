using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheGamesShop.Core.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }
}