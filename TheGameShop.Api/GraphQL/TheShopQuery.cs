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
                description: "All video games of The Game Shop",
                resolve: context => gameRepository.GetAll()
            );

            Field<GameType>(
                "game",
                description: "a game",
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

            Field<ListGraphType<DeveloperType>>(
                "developers",
                description: "All video game developers of this game",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "gameId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("gameId");

                    return gameRepository.GetDevelopedByForGame(id);
                });
        }
    }
}