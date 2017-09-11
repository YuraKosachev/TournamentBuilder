using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Core
{
    public class Discipline
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
