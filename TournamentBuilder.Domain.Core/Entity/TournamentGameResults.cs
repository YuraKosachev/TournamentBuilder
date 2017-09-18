using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentBuilder.Domain.Core
{
    public class TournamentGameResults:IModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Tournament")]
        public Guid TornamentId { get; set; }
        public Guid FirstParticipantId { get; set; }
        public Guid SecondeParticipantId { get; set; }
        //match results
        public int FirstParticipantScore { get; set; }
        public int SecondeParticipantScore { get; set; }



        public DateTime? GameDateTime { get; set; }
        //navi setting
        public virtual Tournament Tournament { get; set; }

    }
}
