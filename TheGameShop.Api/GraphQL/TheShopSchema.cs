using GraphQL;
using GraphQL.Types;

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