using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TournamentBuilder.Domain.Core
{
    public class TournamentSettings:IModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TournamentSystemId { get; set; }
        public bool IsTeamMode { get; set; }
    }
}
