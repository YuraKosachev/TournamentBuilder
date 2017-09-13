using TournamentBuilder.Domain.Core;
using System.Data.Entity;

namespace TournamentBuilder.Infrastructure.Data
{
    public class TournamentBuilderDbContext:DbContext
    {
        public TournamentBuilderDbContext() : base("TournamentBuilderConnection")
        { }

        //dbset
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        //public DbSet<Tournament> Tournaments { get; set; }
        //public DbSet<TournamentSettings> TournamentSettings { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public static TournamentBuilderDbContext Instance()
        {
            return new TournamentBuilderDbContext();
        }
    }
}
