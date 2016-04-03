using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;

namespace Xeromatic.Services
{
    public class TwitterApiService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "r1GXVFf5TyeMHxAebwhPdPdHQ",
                ConsumerSecret = "8JiB5vYAB4zQWRjOw09xgoJQZ5zJk12iFjy9AxLAGdQGDzQH97",
                AccessToken = "14047222-EqjZFAGFPsQ4MgVUlIszuc48bUsa9gzmYOCOJa07I",
                AccessTokenSecret = "VpUiegbJFau3srchduacXQQWMwSh4ZkFGxEzt1tVs0hOp"
            };
        }

        public IEnumerable<ITweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () =>
            {
                return Timeline.GetHomeTimeline();
            });

            return tweets;
        }

    }
}