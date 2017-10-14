namespace Boomerang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelatedPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feelings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                        CurrentMoodId = c.Int(),
                        RelatedPostId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.RelatedPostId)
                .ForeignKey("dbo.Feelings", t => t.CurrentMoodId)
                .Index(t => t.CurrentMoodId)
                .Index(t => t.RelatedPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CurrentMoodId", "dbo.Feelings");
            DropForeignKey("dbo.Posts", "RelatedPostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "RelatedPostId" });
            DropIndex("dbo.Posts", new[] { "CurrentMoodId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Feelings");
        }
    }
}
