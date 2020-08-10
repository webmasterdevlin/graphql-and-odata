using GraphQL.Resolvers;
using GraphQL.Types;
using TheGameShop.Api.GraphQL.Messaging;
using TheGameShop.Api.GraphQL.Types;

namespace TheGameShop.Api.GraphQL
{
    public class TheGameShopSubscription : ObjectGraphType
    {
        public TheGameShopSubscription(ReviewMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageType),
                Resolver = new FuncFieldResolver<ReviewAddedMessage>(c => c.Source as ReviewAddedMessage),
                Subscriber = new EventStreamResolver<ReviewAddedMessage>(c => messageService.GetMessages())
            });
        }
    }
}