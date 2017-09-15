namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "NickName", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "Name", c => c.String());
            AlterColumn("dbo.Players", "Email", c => c.String());
            AlterColumn("dbo.Players", "NickName", c => c.String());
        }
    }
}
