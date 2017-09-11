using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Core
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public Guid OwnId { get; set; }
        public Guid? ImageId { get; set; }
        public Guid? TournamentSettingsId { get; set; }
        public Guid? CMSSettingsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
