using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boomerang.Models
{
    public class Feeling
    {
        public Feeling()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public int DomainId { get; set; }
        public bool IsDeleted { get; set; }
    }
}