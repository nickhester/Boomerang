using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Boomerang.Models;

namespace Boomerang.Contexts
{
    public class PostsContext : DbContext
    {
        public DbSet<Post> PostDbSet { get; set; }
        public DbSet<Feeling> FeelingDbSet { get; set; }

        public PostsContext()
        {
            Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feeling>()
                .HasMany(p => p.Posts)
                .WithOptional(p => p.CurrentMood)
                .HasForeignKey(p => p.CurrentMoodId);

            modelBuilder.Entity<Post>()
                .HasOptional(p => p.RelatedPost)
                .WithMany(p => p.RelatedPosts)
                .HasForeignKey(p => p.RelatedPostId);
        }
    }
}