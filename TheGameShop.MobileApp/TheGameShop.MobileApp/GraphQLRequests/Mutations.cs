using GraphQL;

namespace TheGameShop.MobileApp.GraphQLRequests
{
    public class Mutations
    {
        public static GraphQLRequest CREATE_REVIEW()
        {
            return new GraphQLRequest()
            {
                Query = @"
                          mutation CreateReview($review: reviewInput!) {
                            createReview(review: $review) {
                              id
                              title
                              review
                            }
                          }
                        "
            };
        }
    }
}