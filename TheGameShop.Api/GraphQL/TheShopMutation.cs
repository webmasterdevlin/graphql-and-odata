using GraphQL.Types;
using TheGameShop.Api.Data.Entities;
using TheGameShop.Api.GraphQL.Types;
using TheGameShop.Api.Repositories;
using TheGameShop.GraphQL.GraphQL.Messaging;

namespace TheGameShop.Api.GraphQL
{
    public class TheGameShopMutation : ObjectGraphType
    {
        public TheGameShopMutation(GameReviewRepository reviewRepository, ReviewMessageService messageService)
        {
            FieldAsync<GameReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<GameReviewInputType>> { Name = "review" }),

                resolve: async context =>
                {
                    var review = context.GetArgument<GameReview>("review");
                    await reviewRepository.AddReview(review);
                    messageService.AddReviewAddedMessage(review);

                    return review;
                });
        }
    }
}