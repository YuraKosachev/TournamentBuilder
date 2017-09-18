using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentBuilder.Models
{
    public class TournamentSettingsViewModel
    {
        public Guid Id { get; set; }
        public Guid TournamentSystemId { get; set; }
        public bool IsTeamMode { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPrivate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}