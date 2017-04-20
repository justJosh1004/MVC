using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.Models
{
    public class Tweet
    {
        public int TweetID { get; set; }
        public string Text { get; set; }
        public int UserID { get; set; }
        public DateTime TweetDate { get; set; }

        public Tweet()
        {
            TweetDate = DateTime.Now;
        }

        public virtual User User { get; set; }
    }
}