using GraphQL.Types;
using TheGameShop.Api.GraphQL.Messaging;

namespace TheGameShop.Api.GraphQL.Types
{
    public class ReviewAddedMessageType : ObjectGraphType<ReviewAddedMessage>
    {
        public ReviewAddedMessageType()
        {
            Field(t => t.GameId);
            Field(t => t.Title);
        }
    }
}