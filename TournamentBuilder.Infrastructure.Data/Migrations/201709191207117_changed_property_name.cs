namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_property_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Players", "NickName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "NickName", c => c.String(nullable: false));
            DropColumn("dbo.Players", "Name");
        }
    }
}
