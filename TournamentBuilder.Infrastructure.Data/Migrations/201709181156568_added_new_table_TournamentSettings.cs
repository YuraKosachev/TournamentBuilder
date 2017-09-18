namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_table_TournamentSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TournamentSystemId = c.Guid(nullable: false),
                        IsTeamMode = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournaments", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentSettings", "Id", "dbo.Tournaments");
            DropIndex("dbo.TournamentSettings", new[] { "Id" });
            DropTable("dbo.TournamentSettings");
        }
    }
}
