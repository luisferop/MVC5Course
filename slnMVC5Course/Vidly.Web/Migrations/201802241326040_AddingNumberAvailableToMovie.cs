namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            Sql("update movies set NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
