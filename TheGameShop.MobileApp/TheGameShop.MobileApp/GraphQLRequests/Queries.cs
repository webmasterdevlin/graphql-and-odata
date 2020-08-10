using GraphQL;

namespace TheGameShop.MobileApp.GraphQLRequests
{
    public class Queries
    {
        public static GraphQLRequest GAMES_QUERY()
        {
            return new GraphQLRequest
            {
                Query = @"
                        query {
                          games {
                            id
                            name
                            price
                            description
                            image: photoFileName # image is an alias
                          }
                        }
                       "
            };
        }
    }
}