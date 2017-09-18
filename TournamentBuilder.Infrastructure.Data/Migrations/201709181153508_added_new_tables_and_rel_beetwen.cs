namespace TournamentBuilder.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_tables_and_rel_beetwen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OwnId = c.Guid(nullable: false),
                        ImageId = c.Guid(),
                        TournamentSettingsId = c.Guid(),
                        CMSSettingsId = c.Guid(),
                        ResultsId = c.Guid(),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tournaments");
        }
    }
}
