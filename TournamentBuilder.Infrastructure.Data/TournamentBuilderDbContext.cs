using TournamentBuilder.Domain.Core;
using System.Data.Entity;
using System.Collections.Generic;

namespace TournamentBuilder.Infrastructure.Data
{
    public class TournamentBuilderDbContext:DbContext
    {
        
        public TournamentBuilderDbContext() : base("TournamentBuilderConnection")
        { }

        //dbset
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentSettings> TournamentSettings { get; set; }
        public DbSet<TournamentGameResults> GameResults { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Team>()
            //.HasMany(t => t.Players)
            //.WithOptional(p => p.Team)
            //.HasForeignKey(k => k.TeamId)
            //.WillCascadeOnDelete(true);


        }
        public static TournamentBuilderDbContext Instance()
        {
              return new TournamentBuilderDbContext();
        }
    }
}
