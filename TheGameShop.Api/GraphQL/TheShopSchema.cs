using GraphQL;
using GraphQL.Types;
using TheGameShop.GraphQL.GraphQL;

namespace TheGameShop.Api.GraphQL
{
    public class TheGameShopSchema : Schema
    {
        public TheGameShopSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TheGameShopQuery>();
            Mutation = resolver.Resolve<TheGameShopMutation>();
            Subscription = resolver.Resolve<TheGameShopSubscription>();
        }
    }
}