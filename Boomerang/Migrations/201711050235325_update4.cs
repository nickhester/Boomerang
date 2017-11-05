namespace Boomerang.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        CurrentMoodId = c.Int(),
                        RelatedPostId = c.Int(),
                        DomainId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                    { 
                        "TenantAwareAnnotation",
                        new AnnotationValues(oldValue: null, newValue: "DomainId")
                    },
                });
            
        }
        
        public override void Down()
        {
            AlterTableAnnotations(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        CurrentMoodId = c.Int(),
                        RelatedPostId = c.Int(),
                        DomainId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteAnnotation",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                    { 
                        "TenantAwareAnnotation",
                        new AnnotationValues(oldValue: "DomainId", newValue: null)
                    },
                });
            
        }
    }
}
