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
        [ForeignKey("Tournament")]
        public Guid Id { get; set; }
        public Guid TournamentSystemId { get; set; }
        public bool IsTeamMode { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPrivate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //navi settings
        public virtual Tournament Tournament { get; set; }
    }
}
