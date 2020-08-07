using GraphQL.Types;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.GraphQL.Types
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Field(t => t.Id);
            Field(t => t.Type);
        }
    }
}