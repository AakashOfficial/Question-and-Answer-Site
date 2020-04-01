namespace DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Tags", new[] { "QuestionId" });
            DropPrimaryKey("dbo.Tags");
            AddColumn("dbo.Questions", "QuestionTitle", c => c.String());
            AddColumn("dbo.Questions", "QuestionImage", c => c.String());
            AddColumn("dbo.Questions", "TagId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "TagId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tags", "TagId");
            CreateIndex("dbo.Questions", "TagId");
            AddForeignKey("dbo.Questions", "TagId", "dbo.Tags", "TagId", cascadeDelete: true);
            DropColumn("dbo.Tags", "QuestionTagId");
            DropColumn("dbo.Tags", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "QuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "QuestionTagId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Questions", "TagId", "dbo.Tags");
            DropIndex("dbo.Questions", new[] { "TagId" });
            DropPrimaryKey("dbo.Tags");
            DropColumn("dbo.Tags", "TagId");
            DropColumn("dbo.Questions", "TagId");
            DropColumn("dbo.Questions", "QuestionImage");
            DropColumn("dbo.Questions", "QuestionTitle");
            AddPrimaryKey("dbo.Tags", "QuestionTagId");
            CreateIndex("dbo.Tags", "QuestionId");
            AddForeignKey("dbo.Tags", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
