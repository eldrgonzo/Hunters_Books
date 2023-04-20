namespace Hunters_Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookID");
        }
    }
}
