using GraphQL.Types;

namespace TheGameShop.Api.GraphQL.Types
{
    public class GameReviewInputType : InputObjectGraphType
    {
        public GameReviewInputType()
        {
            Name = "reviewInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("review");
            Field<IntGraphType>("gameId");
        }
    }
}