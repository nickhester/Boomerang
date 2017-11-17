using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Boomerang.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boomerang.Models
{
    [SoftDelete("IsDeleted")]
    [TenantAware("DomainId")]
    public class Post
    {
        public Post()
        {
            RelatedPosts = new HashSet<Post>();
            //DynamicProperties = new HashSet<DynamicProperty>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public int? CurrentMoodId { get; set; }
        public virtual Feeling CurrentMood { get; set; }
        public int? RelatedPostId { get; set; }
        public virtual Post RelatedPost { get; set; }
        public virtual ICollection<Post> RelatedPosts { get; set; }
        public int DomainId { get; set; }
        public bool IsDeleted { get; set; }

        //private IDictionary<string, object> _properties;
        public IDictionary<string, object> Properties { get; set; }
        //{
        //    get
        //    {
        //        if (_properties == null)
        //        {
        //            _properties = new Dictionary<string, object>();
        //            foreach (var dynamicProperty in DynamicProperties)
        //            {
        //                _properties.Add(dynamicProperty.Key, dynamicProperty.Value);
        //            }
        //        }
        //        return _properties;
        //    }
        //    set
        //    {
        //        _properties = value;
        //    }
        //}

        //[NotMapped]
        //public ICollection<DynamicProperty> DynamicProperties { get; set; }
    }
}