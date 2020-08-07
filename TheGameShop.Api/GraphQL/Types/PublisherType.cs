using GraphQL.Types;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.GraphQL.Types
{
    public class PublisherType : ObjectGraphType<Publisher>
    {
        public PublisherType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}