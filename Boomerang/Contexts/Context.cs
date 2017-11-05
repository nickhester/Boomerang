using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Boomerang.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Boomerang.EntityFramework;

namespace Boomerang.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Post> PostDbSet { get; set; }
        public DbSet<Feeling> FeelingDbSet { get; set; }

        public Context()
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

            //var conv = new AttributeToTableAnnotationConvention<EntityFramework.SoftDeleteAttribute, string>(
            //    SoftDeleteAttribute.SoftDeleteAnnotation,
            //    (type, attributes) => attributes.Single().ColumnName);
            //modelBuilder.Conventions.Add(conv);

            //var conv2 = new AttributeToTableAnnotationConvention<EntityFramework.TenantAwareAttribute, string>(
            //    TenantAwareAttribute.TenantAwareAnnotation,
            //    (type, attributes) => attributes.Single().ColumnName);
            //modelBuilder.Conventions.Add(conv2);

            AnnotationConventionRegister.RegisterAnnotationConventions(ref modelBuilder);
        }
    }
}