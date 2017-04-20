using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Twitter.Models;

namespace Twitter.DAL
{
    public class TweetInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<TwitterContext>
    {
        protected override void Seed(TwitterContext context)
        {
            var users = new List<User>
            {
                new User{ID=1, Name="Josh", Handle="justJosh"},
                new User{ID=2, Name="Whitney", Handle="runWhitney" }
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var tweets = new List<Tweet>
            {
                new Tweet{Text="This is a test", UserID=1},
                new Tweet{Text="This is another test", UserID=1},
                new Tweet{Text="one more test", UserID=1},
                new Tweet{Text="I am also testing", UserID=2},
                new Tweet{Text="I guess i'll do one more test", UserID=2}
            };

            tweets.ForEach(s => context.Tweets.Add(s));
            context.SaveChanges();
        }
    }
}