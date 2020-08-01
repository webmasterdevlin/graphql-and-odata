using GraphQL.Types;
using TheGameShop.Api.Data.Entities;

namespace TheGameShop.Api.GraphQL.Types
{
    public class GameReviewType : ObjectGraphType<GameReview>
    {
        public GameReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}