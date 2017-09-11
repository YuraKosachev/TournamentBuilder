using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Interfaces;

namespace TournamentBuilder.Infrastructure.Data.Entity
{
   
        public class Tournament:IModel
        {
            public Guid Id { get; set; }
            public Guid OwnId { get; set; }
            public Guid? ImageId { get; set; }
            public Guid? TournamentSettingsId { get; set; }
            public Guid? CMSSettingsId { get; set; }
            public Guid? ResultsId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsPublished { get; set; }
            public bool IsPrivate { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }

        }
}
