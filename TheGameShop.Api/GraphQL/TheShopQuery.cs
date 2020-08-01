using GraphQL.Types;
using TheGameShop.Api.GraphQL.Types;
using TheGameShop.Api.Repositories;

namespace TheGameShop.Api.GraphQL
{
    public class TheGameShopQuery : ObjectGraphType
    {
        public TheGameShopQuery(GameRepository gameRepository, GameReviewRepository reviewRepository)
        {
            Field<ListGraphType<GameType>>(
                "games",
                resolve: context => gameRepository.GetAll()
            );

            Field<GameType>(
                "game",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return gameRepository.GetOne(id);
                }
            );

            Field<ListGraphType<GameReviewType>>(
                "reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "gameId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("gameId");
                    return reviewRepository.GetForGame(id);
                });
        }
    }
}