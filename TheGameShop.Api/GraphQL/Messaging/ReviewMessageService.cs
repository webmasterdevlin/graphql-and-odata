using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.GraphQL.Messaging
{
    public class ReviewMessageService
    {
        private readonly ISubject<ReviewAddedMessage> _messageStream = new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(GameReview review)
        {
            var message = new ReviewAddedMessage
            {
                GameId = review.GameId,
                Title = review.Title
            };
            _messageStream.OnNext(message);

            return message;
        }

        public IObservable<ReviewAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}