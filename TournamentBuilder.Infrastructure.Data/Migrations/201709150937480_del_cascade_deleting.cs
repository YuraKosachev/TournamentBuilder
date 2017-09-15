namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class del_cascade_deleting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            AddForeignKey("dbo.Players", "TeamId", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            AddForeignKey("dbo.Players", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
