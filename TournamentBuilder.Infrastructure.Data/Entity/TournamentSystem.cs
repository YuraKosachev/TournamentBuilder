using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Interfaces;

namespace TournamentBuilder.Infrastructure.Data.Entity
{
    public class TournamentSystem:IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Decriptions { get; set; }
    }
}
