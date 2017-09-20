using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentBuilder.Models
{
    public class ShortTournamentViewModel
    {
        public Guid Id { get; set; }
        public Guid OwnId { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
    }
    public class TournamentViewModel
    {
        public Guid Id { get; set; }
        public Guid OwnId { get; set; }
        public Guid? ImageId { get; set; }
        public Guid? CMSSettingsId { get; set; }
        public Guid? ResultsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }

        public TournamentSettingsViewModel TournamentSetting { get; set; }
        public IEnumerable<PlayerViewModel> Players { get; set; }
        public IEnumerable<TeamViewModel> Teams { get; set; }
        public IEnumerable<TournamentGameResultsViewModel> Result { get; set; }
    }
}