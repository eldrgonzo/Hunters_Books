namespace Hunters_Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration25 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_ID", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_ID" });
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Books", "Author_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Author_ID", c => c.Int());
            DropColumn("dbo.Books", "Author");
            CreateIndex("dbo.Books", "Author_ID");
            AddForeignKey("dbo.Books", "Author_ID", "dbo.Authors", "ID");
        }
    }
}
