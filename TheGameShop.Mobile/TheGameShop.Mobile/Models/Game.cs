using System;
using System.Collections.Generic;
using System.Text;

namespace TheGameShop.Mobile.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
    }
}