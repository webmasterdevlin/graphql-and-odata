using System.ComponentModel.DataAnnotations;

namespace TheGameShop.Api.Data.Entities
{
    public class GameReview
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }

        [StringLength(200), Required]
        public string Title { get; set; }

        public string Review { get; set; }
    }
}