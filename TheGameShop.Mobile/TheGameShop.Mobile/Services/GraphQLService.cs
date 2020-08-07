using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Polly;
using TheGameShop.Mobile.Constants;
using TheGameShop.Mobile.Models;

namespace TheGameShop.Mobile.Services
{
    public static class GraphQLService
    {
        private static readonly Lazy<GraphQLHttpClient> _clientHolder = new Lazy<GraphQLHttpClient>(CreateGraphQLClient);

        private static GraphQLHttpClient Client => _clientHolder.Value;

        public static async Task<List<Game>> GetGames()
        {
            var graphQLRequest = new GraphQLRequest
            {
                Query = "query { games  { id, name } }"
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
            var response = await Policy.Handle<Exception>().WaitAndRetryAsync(numRetries, pollyRetryAttempt).ExecuteAsync(action).ConfigureAwait(false);

            if (response.Errors != null && response.Errors.Count() > 1)
                throw new AggregateException(response.Errors.Select(x => new Exception(x.ToString())));
            else if (response.Errors != null && response.Errors.Any())
                throw new Exception(response.Errors.First().ToString());

            return response.Data;

            static TimeSpan pollyRetryAttempt(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber));
        }
    }
}