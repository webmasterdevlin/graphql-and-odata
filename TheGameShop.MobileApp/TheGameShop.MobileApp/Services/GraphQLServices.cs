using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TheGameShop.MobileApp.Constants;
using TheGameShop.MobileApp.Models;

using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace TheGameShop.MobileApp.Services
{
    public static class GraphQLServices
    {
        public static async Task<List<Game>> GetGames()
        {
            var GAMES_QUERY = new GraphQLRequest
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

            var response = await Client.SendQueryAsync<GameGraphQLResponse>(GAMES_QUERY);

            return response.Data.Games;
        }

        private static GraphQLHttpClient Client => ClientHolder.Value;

        private static readonly Lazy<GraphQLHttpClient> ClientHolder = new Lazy<GraphQLHttpClient>(CreateGraphQLClient);

        private static GraphQLHttpClient CreateGraphQLClient()
        {
            var options = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(BackendConstants.GraphQLApiUrl),
#if !DEBUG
                HttpMessageHandler = new ModernHttpClient.NativeMessageHandler()
#endif
            };

            return new GraphQLHttpClient(options, new NewtonsoftJsonSerializer());
        }
    }
}