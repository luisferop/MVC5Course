namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGenreList : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres(id,name) values(1,'Comedy')");
            Sql("insert into genres(id,name) values(2,'Drama')");
            Sql("insert into genres(id,name) values(3,'Action')");
            Sql("insert into genres(id,name) values(4,'Family')");
            Sql("insert into genres(id,name) values(5,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
