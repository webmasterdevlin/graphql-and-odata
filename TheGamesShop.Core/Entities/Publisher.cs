using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheGamesShop.Core.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }
}