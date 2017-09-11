using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Interfaces;

namespace TournamentBuilder.Infrastructure.Data.Entity
{
    public class TournamentSettings:IModel
    {
        public Guid Id { get; set; }
        public Guid TournamentSystemId { get; set; }

    }
}
