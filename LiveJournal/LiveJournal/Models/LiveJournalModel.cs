using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LiveJournal.Models
{
    public class JournalUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Handle { get; set; }
        public string ProfilePic { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }

    public class Submission
    {
        public int SubmissionID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Display(Name = "Submission Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionTime { get; set; }

        [Display(Name = "Journal User")]
        public virtual JournalUser JournalUser { get; set; }
    }

    public class JournalDbContext : DbContext
    {
        public DbSet<JournalUser> JournalUsers { get; set; }
        public DbSet<Submission> Submissions { get; set; }
    }
}