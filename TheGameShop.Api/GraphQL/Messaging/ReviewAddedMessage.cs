namespace TheGameShop.Api.GraphQL.Messaging
{
    public class ReviewAddedMessage
    {
        public int GameId { get; set; }
        public string Title { get; set; }
    }
}