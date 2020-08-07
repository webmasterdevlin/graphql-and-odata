using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Polly;
using TheGameShop.MobileApp.Constants;
using TheGameShop.MobileApp.Models;

namespace TheGameShop.MobileApp.Services
{
    public static class GraphQLServices
    {
        private static readonly Lazy<GraphQLHttpClient> ClientHolder = new Lazy<GraphQLHttpClient>(CreateGraphQLClient);

        private static GraphQLHttpClient Client => ClientHolder.Value;

        public static async Task<List<Game>> GetGames()
        {
            var graphQLRequest = new GraphQLRequest
            {
                Query = "query { games  { id, name, price, description } }"
            };

            var data = await AttemptAndRetry(() => Client
                    .SendQueryAsync<GameGraphQLResponse>(graphQLRequest))
                .ConfigureAwait(false);

            return data.Games;
        }

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

        private static async Task<T> AttemptAndRetry<T>(Func<Task<GraphQLResponse<T>>> action, int numRetries = 2)
        {
            var response = await Policy.Handle<Exception>().WaitAndRetryAsync(numRetries, PollyRetryAttempt).ExecuteAsync(action).ConfigureAwait(false);

            if (response.Errors != null && response.Errors.Count() > 1)
                throw new AggregateException(response.Errors.Select(x => new Exception(x.ToString())));
            else if (response.Errors != null && response.Errors.Any())
                throw new Exception(response.Errors.First().ToString());

            return response.Data;

            static TimeSpan PollyRetryAttempt(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(10, attemptNumber));
        }
    }
}