using System.Security.Claims;
using GraphQL.DataLoader;
using GraphQL.Types;
using TheGameShop.Api.Repositories;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.GraphQL.Types
{
    public class GameType : ObjectGraphType<Game>
    {
        public GameType(GameReviewRepository reviewRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the game was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<GameTypeEnumType>("Type", "The type of game");

            Field<ListGraphType<GameReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var user = (ClaimsPrincipal)context.UserContext;
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, GameReview>(
                            "GetReviewsByGameId", reviewRepository.GetForGames);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}