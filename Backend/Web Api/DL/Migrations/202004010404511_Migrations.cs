namespace DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        AnswerName = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        AnswerActive = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId);
            
            CreateTable(
                "dbo.UserReactions",
                c => new
                    {
                        ReactionId = c.Int(nullable: false, identity: true),
                        ReactionType = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ReactionActive = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReactionId)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionName = c.String(nullable: false),
                        QuestionTitle = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        QuestionActive = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        QuestionImage = c.String(),
                        QuestionTagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        QuestionTagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        TagActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionTagId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserFirstName = c.String(nullable: false),
                        UserLastName = c.String(),
                        UserEmail = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserProfilePicture = c.String(),
                        UserActive = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReactions", "AnswerId", "dbo.Answers");
            DropIndex("dbo.UserReactions", new[] { "AnswerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Questions");
            DropTable("dbo.UserReactions");
            DropTable("dbo.Answers");
        }
    }
}
