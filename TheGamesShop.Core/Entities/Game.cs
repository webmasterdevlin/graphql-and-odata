using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheGamesShop.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        public List<Developer> DevelopedBy { get; set; }
        public List<Publisher> PublishedBy { get; set; }
        public List<Genre> Genre { get; set; }

        public GameTypeEnum Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }

        [StringLength(100)]
        public string PhotoFileName { get; set; }

        public List<GameReview> GameReviews { get; set; }
    }
}