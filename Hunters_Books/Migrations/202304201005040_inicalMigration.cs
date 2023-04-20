namespace Hunters_Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Genre = c.String(nullable: false, maxLength: 50),
                        GenreID = c.Int(nullable: false),
                        Author_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.Author_ID)
                .Index(t => t.Author_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_ID", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_ID" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
