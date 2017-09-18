namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table_TournamentGameResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentGameResults",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TornamentId = c.Guid(nullable: false),
                        FirstParticipantId = c.Guid(nullable: false),
                        SecondeParticipantId = c.Guid(nullable: false),
                        FirstParticipantScore = c.Int(nullable: false),
                        SecondeParticipantScore = c.Int(nullable: false),
                        GameDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournaments", t => t.TornamentId, cascadeDelete: true)
                .Index(t => t.TornamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentGameResults", "TornamentId", "dbo.Tournaments");
            DropIndex("dbo.TournamentGameResults", new[] { "TornamentId" });
            DropTable("dbo.TournamentGameResults");
        }
    }
}
