namespace Kirjakortisto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.Books", "Name");
            CreateIndex("dbo.Books", "Author");
            CreateIndex("dbo.Books", "PurchaseDate");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "PurchaseDate" });
            DropIndex("dbo.Books", new[] { "Author" });
            DropIndex("dbo.Books", new[] { "Name" });
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Description", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
        }
    }
}
