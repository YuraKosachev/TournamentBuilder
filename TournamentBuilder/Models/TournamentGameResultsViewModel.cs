using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentBuilder.Models
{
    public class TournamentGameResultsViewModel
    {
        public Guid Id { get; set; }
        public Guid TornamentId { get; set; }
        public Guid FirstParticipantId { get; set; }
        public Guid SecondeParticipantId { get; set; }
        //match results
        public int FirstParticipantScore { get; set; }
        public int SecondeParticipantScore { get; set; }



        public DateTime? GameDateTime { get; set; }
    }
}