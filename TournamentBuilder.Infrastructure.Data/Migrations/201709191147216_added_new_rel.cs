namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_rel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamTournaments",
                c => new
                    {
                        Team_Id = c.Guid(nullable: false),
                        Tournament_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Tournament_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.Tournament_Id);
            
            CreateTable(
                "dbo.PlayerTournaments",
                c => new
                    {
                        Player_Id = c.Guid(nullable: false),
                        Tournament_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Tournament_Id })
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.Tournament_Id);
            
            DropColumn("dbo.Tournaments", "TournamentSettingsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tournaments", "TournamentSettingsId", c => c.Guid());
            DropForeignKey("dbo.PlayerTournaments", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.PlayerTournaments", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.TeamTournaments", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.TeamTournaments", "Team_Id", "dbo.Teams");
            DropIndex("dbo.PlayerTournaments", new[] { "Tournament_Id" });
            DropIndex("dbo.PlayerTournaments", new[] { "Player_Id" });
            DropIndex("dbo.TeamTournaments", new[] { "Tournament_Id" });
            DropIndex("dbo.TeamTournaments", new[] { "Team_Id" });
            DropTable("dbo.PlayerTournaments");
            DropTable("dbo.TeamTournaments");
        }
    }
}
