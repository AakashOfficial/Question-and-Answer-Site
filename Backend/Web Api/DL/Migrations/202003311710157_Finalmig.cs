namespace DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Finalmig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Tags", new[] { "QuestionId" });
            AddColumn("dbo.Questions", "QuestionTitle", c => c.String());
            AddColumn("dbo.Questions", "QuestionImage", c => c.String());
            AddColumn("dbo.Questions", "QuestionTagId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "QuestionTagId");
            AddForeignKey("dbo.Questions", "QuestionTagId", "dbo.Tags", "QuestionTagId", cascadeDelete: true);
            DropColumn("dbo.Tags", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "QuestionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "QuestionTagId", "dbo.Tags");
            DropIndex("dbo.Questions", new[] { "QuestionTagId" });
            DropColumn("dbo.Questions", "QuestionTagId");
            DropColumn("dbo.Questions", "QuestionImage");
            DropColumn("dbo.Questions", "QuestionTitle");
            CreateIndex("dbo.Tags", "QuestionId");
            AddForeignKey("dbo.Tags", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
