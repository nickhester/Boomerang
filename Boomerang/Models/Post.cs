using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boomerang.Models
{
    public class Post
    {
        public Post()
        {
            RelatedPosts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public DateTime Time { get; set; }
        public int? CurrentMoodId { get; set; }
        public virtual Feeling CurrentMood { get; set; }
        public int? RelatedPostId { get; set; }
        public virtual Post RelatedPost { get; set; }
        public virtual ICollection<Post> RelatedPosts { get; set; }
    }
}