using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Handle { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}