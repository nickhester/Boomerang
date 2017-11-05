namespace Boomerang.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_NotMoodOne",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.Filters.FilterDefinition")
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
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "globalFilter_NotMoodOne",
                        new AnnotationValues(oldValue: "EntityFramework.Filters.FilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
