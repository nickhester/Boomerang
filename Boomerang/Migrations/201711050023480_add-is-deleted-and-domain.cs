namespace Boomerang.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addisdeletedanddomain : DbMigration
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
                        "globalFilter_NotMoodOne",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.Feelings", "DomainId", c => c.Int(nullable: false));
            AddColumn("dbo.Feelings", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "DomainId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsDeleted");
            DropColumn("dbo.Posts", "DomainId");
            DropColumn("dbo.Feelings", "IsDeleted");
            DropColumn("dbo.Feelings", "DomainId");
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
                        "globalFilter_NotMoodOne",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
                    },
                });
            
        }
    }
}
