using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentBuilder.Models
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}